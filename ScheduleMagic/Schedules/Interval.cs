using System;

namespace ScheduleMagic.Schedules
{
    public class Interval : ISchedule
    {
        private long _seconds;

        public Interval(long seconds)
        {
            _seconds = seconds;
        }

        public DateTime GetUtcExpirationDate()
        {
            return DateTime.UtcNow.AddSeconds(_seconds);
        }
    }
}