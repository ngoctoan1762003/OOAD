using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAd
{
    class Appointment
    {
        private String title;
        private DateTime date;
        private TimeSpan time;
        private TimeSpan endTime;
        private bool isGroupMeeting;
        private bool isReminded;

        public Appointment()
        {
        }

        public Appointment(String title, DateTime date, TimeSpan time, TimeSpan endTime, bool isGroup, bool isReminded)
        {
            this.title = title;
            this.date = date;
            this.time = time;
            this.endTime = endTime;
            this.isGroupMeeting = isGroup;
            this.isReminded = isReminded;
        }

        public void Show()
        {
            Console.WriteLine(title);
            Console.WriteLine(date);
            Console.WriteLine(time);
            Console.WriteLine(endTime);
            Console.WriteLine(isGroupMeeting);
        }

        public String GetTitle()
        {
            return title;
        }

        public DateTime GetDateMeeting()
        {
            return date;
        }

        public TimeSpan GetStartTime()
        {
            return time;
        }

        public TimeSpan GetEndTime()
        {
            return endTime;
        }

        public bool GetTypeMeeting()
        {
            return isGroupMeeting;
        }

        public bool GetIsReminded()
        {
            return isReminded;
        }

        public void SetIsReminded(bool isReminded)
        {
            this.isReminded = isReminded;
        }
    }
}
