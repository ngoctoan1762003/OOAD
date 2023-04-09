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
    public partial class AddReminderForm : Form
    {
        public AddReminderForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ((Appointment)Form1.appointment[Form1.appointment.Count - 1]).SetIsReminded(true);
            Form1.reminderAppointment.Add((Appointment)Form1.appointment[Form1.appointment.Count - 1]);

            SqlConnection conn = null;

            string strConn = @"SERVER = DESKTOP-K4P8URK\SQLEXPRESS; Database = Appointment; User Id=sa; pwd = 123456";

            conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateReminderAppointment";

            command.Parameters.AddWithValue("@name", AddAppointmentForm.newAppointmentName);
            command.Parameters.AddWithValue("@isReminded", true);

            int ret = command.ExecuteNonQuery();

            if (ret > 0)
                MessageBox.Show("Thêm vào ghi nhớ thành công");
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
