namespace ScheduleMagic
{
    public class Scheduler
    {
        public static void Schedule<T>(ISchedule schedule) where T : IScheduledTask
        {
            Helper.Insert<T>(schedule);
        }
    }
}