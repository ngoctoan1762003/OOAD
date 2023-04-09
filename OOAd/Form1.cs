using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAd
{
    public partial class Form1 : Form
    {
        int month, year;
        public static int static_month, static_year, overlappedIndex;
        public static ArrayList appointment = new ArrayList();
        public static ArrayList reminderAppointment = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            ReminderForm reminderForm = new ReminderForm();
            reminderForm.Show();
        }

        public void displayDays()
        {
            string strConn = @"SERVER = DESKTOP-K4P8URK\SQLEXPRESS; Database = Appointment; User Id=sa; pwd = 123456";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAllAppointment";
            command.Connection = conn;

            SqlDataReader sqlReader = command.ExecuteReader();
            while(sqlReader.Read())
            {

                String name = sqlReader.GetString(0);
                DateTime date = sqlReader.GetDateTime(1);
                TimeSpan time = sqlReader.GetTimeSpan(2);
                TimeSpan endTime = sqlReader.GetTimeSpan(4);
                bool isGroup = sqlReader.GetBoolean(3);
                bool isRemind = sqlReader.GetBoolean(5);
                Appointment tempAppointment = new Appointment(name, date, time, endTime, isGroup, isRemind);
                appointment.Add(tempAppointment);
                if (isRemind)
                {
                    reminderAppointment.Add(tempAppointment);
                }
            }

            DateTime now = DateTime.Now;
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;

            static_month = month;
            static_year = year;

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            txtMonthYear.Text = monthName + " " + year;

            DateTime startOfTheMonth = new DateTime(now.Year, now.Month, 1);
            int days = DateTime.DaysInMonth(now.Year, now.Month);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
            for(int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }
            for(int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            month++;
            if(month > 12)
            {
                year++;
                month = 1;
            }

            static_month = month;
            static_year = year;

            dayContainer.Controls.Clear();

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            txtMonthYear.Text = monthName + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            month--;
            if(month <= 0)
            {
                month = 12;
                year--;
            }

            static_month = month;
            static_year = year;


            dayContainer.Controls.Clear();

            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            txtMonthYear.Text = monthName + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }
    }
}
