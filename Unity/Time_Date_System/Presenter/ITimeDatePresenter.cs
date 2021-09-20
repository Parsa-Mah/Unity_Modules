namespace PM.Utill.Presenter
{
    public interface ITimeDatePresenter
    {
        // Init both objects
        void SetDate(int day, int month, int year);
        void SetTime(int hou, int min, int sec);
        // Part of Time object
        void AddOneSecond(int time);
        void AddOneMinute();
        void AddOneHour();
        // Part of Date Object
        string AddOneDay();
        string AddOneMonth();
        string AddOneYear();
        // returns time and Date in string
        string GetTime();
        public string GetDate(int type);
        // Starts the time
        void StartCountingTime(int time);
    }
}