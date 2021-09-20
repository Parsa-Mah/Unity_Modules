using System;

namespace Time_Date_System
{
    using System;
    using UnityEngine;

    namespace Unity_DLLs
    {
        public class TimeDateSystem
        {
            // Structs
            private struct GameTimeSystem
            {
                public int hou, min, sec;

                public GameTimeSystem(int hou, int min, int sec = 0)
                {
                    this.sec = sec;
                    this.min = min;
                    this.hou = hou;
                }

                public readonly override string ToString() =>
                    string.Format($"{hou.ToString("00")}:{min.ToString("00")}.{sec.ToString("00")}");
            }

            private struct GameDateSystem
            {
                public int day, month, year;

                public GameDateSystem(int day, int month, int year)
                {
                    this.day = day;
                    this.month = month;
                    this.year = year;
                }

                public override string ToString() => string.Format("{0}/{1}/{2}", day, month, year);
            }

            // Variables
            [SerializeField] string realTimeDebug = ""; // TODO: Debug code
            [SerializeField] [Range(0, 100)] float secondsForAGameMin = 1;
            [SerializeField] string gameTimeDebug = ""; // TODO: Debug code
            [SerializeField] string gameDateDebug = ""; // TODO: Debug code
            [SerializeField] public bool isItWorking = true; // TODO: Debug code
            public bool isItNew = true;

            // Cached variables
            private int gameTimeCache = 0;
            private int realTimeCache = 0;

            // Variables
            GameTimeSystem realTime;
            GameTimeSystem gameTime;
            GameDateSystem gameDate;

            void Start()
            {
                realTime = new GameTimeSystem(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                gameTime = new GameTimeSystem(8, 5);
                gameDate = new GameDateSystem(4, 6, 2020);
                gameDateDebug = gameDate.ToString();

                Time.timeScale = secondsForAGameMin;

                realTimeCache = (int)Time.realtimeSinceStartup;
                gameTimeCache = (int)Time.time;
            }


            private void Update()
            {
                Time.timeScale = secondsForAGameMin;
                TimeSystem();
                DateSystem();
            }

            private void TimeSystem()
            {
                if ((int)Time.realtimeSinceStartup > realTimeCache)
                {
                    realTimeCache = (int)Time.realtimeSinceStartup;

                    realTime.sec++;

                    if (realTime.sec >= 60)
                    {
                        realTime.sec = 0;
                        realTime.min++;
                        if (realTime.min >= 60)
                        {
                            realTime.min = 0;
                            realTime.hou++;
                            if (realTime.hou >= 24)
                            {
                                realTime.hou = 0;
                            }
                        }
                    }
                }

                if ((int)Time.time > gameTimeCache)
                {
                    gameTimeCache = (int)Time.time;

                    gameTime.min++;

                    if (gameTime.min >= 60)
                    {
                        gameTime.min = 0;
                        gameTime.hou++;
                        if (gameTime.hou >= 24)
                        {
                            gameTime.hou = 0;
                        }
                    }
                }

                realTimeDebug = realTime.ToString();
                gameTimeDebug = gameTime.ToString().Substring(0, 5);
            }

            private void DateSystem()
            {
                if ((int)Time.realtimeSinceStartup > realTimeCache)
                {
                    gameDate.day++;

                    if (gameDate.day >= 8)
                    {
                        gameDate.day = 0;
                        gameDate.month++;

                        if (gameDate.month >= 13)
                        {
                            gameDate.year++;
                        }
                    }
                    gameDateDebug = gameDate.ToString();
                }
            }
        }

    }

}
