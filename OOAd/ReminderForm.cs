using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAd
{
    public partial class ReminderForm : Form
    {
        public ReminderForm()
        {
            InitializeComponent();
        }

        private void ReminderForm_Load(object sender, EventArgs e)
        {
            DisplayAll();
        }

        public void DisplayAll()
        {
            lsvAppointment.Clear();
            lsvAppointment.Columns.Add("Tên cuộc họp", 145);
            lsvAppointment.Columns.Add("Ngày", 150);
            lsvAppointment.Columns.Add("Thời gian bắt đầu", 110);
            lsvAppointment.Columns.Add("Thời gian kết thúc", 110);

            lsvAppointment.View = View.Details;

            for (int i = 0; i < Form1.reminderAppointment.Count; i++)
            {
                ListViewItem lsv = new ListViewItem(((Appointment)Form1.reminderAppointment[i]).GetTitle());
                lsv.SubItems.Add(((Appointment)Form1.reminderAppointment[i]).GetDateMeeting().ToString());
                lsv.SubItems.Add(((Appointment)Form1.reminderAppointment[i]).GetStartTime().ToString(@"hh\:mm\:ss"));
                lsv.SubItems.Add(((Appointment)Form1.reminderAppointment[i]).GetEndTime().ToString(@"hh\:mm\:ss"));

                lsvAppointment.Items.Add(lsv);
            }
        }
    }
}
