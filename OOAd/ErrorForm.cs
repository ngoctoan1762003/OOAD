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
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;

            string strConn = @"SERVER = DESKTOP-K4P8URK\SQLEXPRESS; Database = Appointment; User Id=sa; pwd = 123456";

            conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateAppointment";

            command.Parameters.AddWithValue("@name", ((Appointment)Form1.appointment[Form1.overlappedIndex]).GetTitle());
            command.Parameters.AddWithValue("@startTime", AddAppointmentForm.startTime);
            command.Parameters.AddWithValue("@endTime", AddAppointmentForm.endTime);

            int ret = command.ExecuteNonQuery();

            if (ret > 0)
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("not oke");

            AddReminderForm addReminderForm = new AddReminderForm();
            addReminderForm.Show();
        }
    }
}
