using System.Collections.Generic;

namespace PM.Utill.Date
{
    class DateModel
    {
        public int day, month, year;

        private readonly string[] stringMonths = {"January", "February", "March", "April",
            "May", "June", "July", "August", "September", "October", "November", "December"};

        private readonly List<int> monthsWith30Days = new List<int> {4, 6, 9, 11};

        public DateModel(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public bool IsMonth30Days(int month)
        {
            return monthsWith30Days.Contains(month);
        }

        public string DateToString(int type)
        {
            return type switch
            {
                0 => string.Format("{0}/{1}/{2}", day, month, year),
                1 => string.Format("{0}/{1}/{2}", day, stringMonths[month--], year),
                _ => "Error date TYPE not recognized or not passed correctly",
            };
        } 
    }
}
