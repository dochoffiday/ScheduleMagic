namespace ScheduleMagic
{
    public class Scheduler
    {
        /// <summary>
        /// Schedules the IScheduledTask to run on the ISchedule schedule.
        /// </summary>
        /// <typeparam name="T">The scheduled task (must implement IScheduledTask).</typeparam>
        /// <param name="schedule">The schedule on which to run the scheduled task (must implement ISchedule)</param>
        public static void Schedule<T>(ISchedule schedule) where T : IScheduledTask
        {
            Helper.Insert<T>(schedule);
        }
    }
}