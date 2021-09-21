
namespace PM.Time_Date_System.Models
{
    class TimeModel
    {
        public int hou, min, sec;

        public TimeModel(int hou, int min, int sec)
        {
            this.hou = hou;
            this.min = min;
            this.sec = sec;
        }

        public override string ToString() =>
            string.Format($"{hou.ToString("00")}:{min.ToString("00")}.{sec.ToString("00")}");
    }
}