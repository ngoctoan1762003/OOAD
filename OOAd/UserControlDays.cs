using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOAd
{
    public partial class UserControlDays : UserControl
    {
        public static int static_day;

        public UserControlDays()
        {
            InitializeComponent();

        }

        public void days(int numday)
        {
            lblDay.Text = numday + "";
            displayEvent();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = Int32.Parse(lblDay.Text);
            //start timer
            timer1.Start();
            AddAppointmentForm eventForm = new AddAppointmentForm();
            eventForm.Show();
        }

        private void displayEvent()
        {
            string strConn = @"SERVER = DESKTOP-K4P8URK\SQLEXPRESS; Database = Appointment; User Id=sa; pwd = 123456";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAppointmentAtDay";

            DateTime date = DateTime.ParseExact(convertToDate(Form1.static_month, Int32.Parse(lblDay.Text), Form1.static_year).ToString(), "MM/dd/yyyy", null);
            command.Parameters.AddWithValue("@date", date);
            SqlDataReader reader = command.ExecuteReader();

            StringBuilder eventString = new StringBuilder();
            while (reader.Read())
            {
                eventString.Append(reader["appointment_Name"].ToString() + "\n");
            }
            lblEvent.Text = eventString.ToString();
            reader.Close();
            command.Dispose();
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }

        private String convertToDate(int month, int day, int year)
        {
            if(month < 10 && day < 10)
            {
                return "0" + month + "/0" + day + "/" + year;
            }
            else if(month < 10 && day >= 10)
            {
                return "0" + month + "/" + day + "/" + year;
            }
            else if(month >= 10 && day < 10)
            {
                return month + "/0" + day + "/" + year;
            }
            return month + "/" + day + "/" + year;
        }
    }
}
