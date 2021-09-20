using PM.Utill.Time;
using PM.Utill.Date;

namespace PM.Utill.Presenter
{
    /// <summary>
    /// The core system for the custom time system
    /// </summary>
    public class TimeDatePresenter : ITimeDatePresenter
    {
        TimeModel timeModel;
        DateModel dateModel;

        bool hasDate = false;
        int tempTime;

        public TimeDatePresenter(int time)
        {
            timeModel = new TimeModel(0, 0, 0);
            dateModel = new DateModel(0, 0, 0);
            tempTime = time;
        }

        /// <summary>
        /// Sets the time object to hour:minutes.seconds *ALL INT*
        /// </summary>
        /// <param name="hou"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        public void SetTime(int hou, int min, int sec)
        {
            timeModel.hou = hou;
            timeModel.min = min;
            timeModel.sec = sec;
        }

        /// <summary>
        /// Sets the date object to day/month/year *ALL INT*
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public void SetDate(int day, int month, int year)
        {
            dateModel.day = day;
            dateModel.month = month;
            dateModel.year = year;
            hasDate = true;
        }

        /// <summary>
        /// Sets the time to 00:00.00
        /// </summary>
        public void ResetTime()
        {
            timeModel.hou = 0;
            timeModel.min = 0;
            timeModel.sec = 0;
        }

        /// <summary>
        /// Starts the time
        /// </summary>
        /// <param name="time"></param>
        public void StartCountingTime(int time)
        {
            AddASec(time);
        }

        /*********************************************/

        /// <summary>
        /// *NEEDS* (int)Time.time for SCALED or (int)Time.realtimeSinceStartup for UNSCALED time
        /// </summary>
        /// <param name="time"></param>
        public void AddOneSecond(int time)
        {
            AddASec();
        }

        public void AddOneMinute()
        {
            AddAMin();
        }

        public void AddOneHour()
        {
            AddAhou();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// **DATE MUST BE SET**
        /// </summary>
        public string AddOneDay()
        {
            if (!hasDate)
            {
                return "*Error* Date not set, please set the date using SetDate()";
            }
            AddADay();
            return "All OK";
        }

        /// <summary>
        /// **DATE MUST BE SET**
        /// </summary>
        public string AddOneMonth()
        {
            if (!hasDate)
            {
                return "*Error* Date not set, please set the date using SetDate()";
            }
            AddAMonth();
            return "All OK";
        }

        /// <summary>
        /// **DATE MUST BE SET**
        /// </summary>
        public string AddOneYear()
        {
            if (!hasDate)
            {
                return "*Error* Date not set, please set the date using SetDate()";
            }
            AddAYear();
            return "All Ok";
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~
        /// <summary>
        /// Returns the time in format of hh:mm:ss
        /// </summary>
        /// <returns></returns>
        public string GetTime()
        {
            return timeModel.ToString();
        }

        /// <summary>
        /// <para>*NEEDS TYPE (0 OR 1)*</para>
        /// <para>Type 0 returns all numbers like 22/4/2021 and 1 returns month as a name like 26/september/2024</para>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetDate(int type)
        {
            if (hasDate)
            {
                return dateModel.DateToString(type);
            }
            return "*Error* Date MUST be set using SetDate()";
        }

        /************************************************/

        private void AddASec(int time)
        {
            if (time > tempTime)
            {
                this.tempTime = time;

                timeModel.sec++;

                if (timeModel.sec >= 60)
                {
                    timeModel.sec = 0;
                    AddAMin();
                }
            }
        }

        private void AddASec()
        {
            timeModel.sec++;

            if (timeModel.sec >= 60)
            {
                timeModel.sec = 0;
                AddAMin();
            }
        }

        private void AddAMin()
        {
            timeModel.min++;
            if (timeModel.min >= 60)
            {
                timeModel.min = 0;
                AddAhou();
            }
        }

        private void AddAhou()
        {
            timeModel.hou++;
            if (timeModel.hou >= 24)
            {
                timeModel.hou = 0;
                if (hasDate)
                {
                    AddADay();
                }
            }
        }

        /// <summary>
        /// **DATE MUST BE SET**
        /// </summary>
        private void AddADay()
        {
            dateModel.day++;

            if (dateModel.day > 27)
            {
                if (dateModel.month == 2 && dateModel.day == 29 && !System.DateTime.IsLeapYear(dateModel.year))
                {
                    dateModel.day = 0;
                    AddAMonth();
                    return;
                }
                if (dateModel.month == 2 && dateModel.day == 30 && System.DateTime.IsLeapYear(dateModel.year))
                {
                    dateModel.day = 0;
                    AddAMonth();
                    return;
                }
                if (dateModel.day == 31 && dateModel.IsMonth30Days(dateModel.month))
                {
                    dateModel.day = 0;
                    AddAMonth();
                    return;
                }
                if (dateModel.day >= 32)
                {
                    dateModel.day = 0;
                    AddAMonth();
                    return;
                }
            }
        }

        /// <summary>
        /// **DATE MUST BE SET**
        /// </summary>
        private void AddAMonth()
        {
            dateModel.month++;
            if (dateModel.month >= 13)
            {
                dateModel.month = 0;
                AddAYear();
            }
        }

        /// <summary>
        /// **DATE MUST BE SET**
        /// </summary>
        private void AddAYear()
        {
            dateModel.year++;
        }
    }
}
