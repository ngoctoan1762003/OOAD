using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAd
{
    public partial class AddAppointmentForm : Form
    {
        public static TimeSpan startTime, endTime;
        public static String newAppointmentName;

        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            dtpTime.Value = new DateTime(Form1.static_year, Form1.static_month, UserControlDays.static_day);
            dtpTime.Format = DateTimePickerFormat.Custom;
            dtpTime.CustomFormat = "yyyy.MM.dd HH:mm";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "HH:mm";
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Form1.appointment.Count; i++)
            {
                DateTime day = ((Appointment)Form1.appointment[i]).GetDateMeeting();
                if (day.Year == dtpTime.Value.Date.Year &&
                    day.Month == dtpTime.Value.Date.Month &&
                    day.Day == dtpTime.Value.Date.Day &&
                    (
                    (dtpTime.Value.Hour <= ((Appointment)Form1.appointment[i]).GetEndTime().Hours &&
                    dtpTime.Value.Hour >= ((Appointment)Form1.appointment[i]).GetStartTime().Hours)
                    ||
                    (dtpEnd.Value.Hour >= ((Appointment)Form1.appointment[i]).GetStartTime().Hours &&
                    dtpEnd.Value.Hour <= ((Appointment)Form1.appointment[i]).GetEndTime().Hours)
                    ))
                {
                    Form1.overlappedIndex = i;
                    startTime = new TimeSpan(dtpTime.Value.Hour, dtpTime.Value.Minute, dtpTime.Value.Second);
                    endTime = new TimeSpan(dtpEnd.Value.Hour, dtpEnd.Value.Minute, dtpEnd.Value.Second);
                    ErrorForm errorForm = new ErrorForm();
                    errorForm.Show();
                    return;
                }
            }

            newAppointmentName = txtTitle.Text;

            SqlConnection conn = null;

            string strConn = @"SERVER = DESKTOP-K4P8URK\SQLEXPRESS; Database = Appointment; User Id=sa; pwd = 123456";

            conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddAppointment";

            command.Parameters.AddWithValue("@name", txtTitle.Text);
            command.Parameters.AddWithValue("@date", dtpTime.Value.Date);
            command.Parameters.AddWithValue("@time", dtpTime.Value.TimeOfDay);
            bool isGroup;
            if (radioButton1.Checked)
            {
                command.Parameters.AddWithValue("@isGroup", false);
                isGroup = false;
            }
            else
            {
                command.Parameters.AddWithValue("@isGroup", true);
                isGroup = true;
            }
            command.Parameters.AddWithValue("@endTime", dtpEnd.Value.TimeOfDay);
            command.Parameters.AddWithValue("@isReminded", false);

            int ret = command.ExecuteNonQuery();

            if (ret > 0)
                MessageBox.Show("Thêm thành công");
            else
                MessageBox.Show("not oke");

            MessageBox.Show("Đã lưu");

            Form1.appointment.Add(new Appointment(txtTitle.Text, dtpTime.Value.Date, new TimeSpan(dtpTime.Value.Hour, dtpTime.Value.Minute, dtpTime.Value.Second), new TimeSpan(dtpEnd.Value.Hour, dtpEnd.Value.Minute, dtpEnd.Value.Second), isGroup, false));

            AddReminderForm reminderForm = new AddReminderForm();
            reminderForm.Show();

            command.Dispose();
            conn.Close();
            this.Close();
        }

    }
}
