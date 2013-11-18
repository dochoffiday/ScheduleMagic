using System;

namespace ScheduleMagic.Schedules
{
    /// <summary>
    /// A task with this schedule will run on an interval, which is set in seconds.
    /// </summary>
    public class Interval : ISchedule
    {
        private long _seconds;

        /// <summary>
        /// A task with this schedule will run on an interval, which is set in seconds.
        /// </summary>
        /// <param name="seconds">The interval amount, i.e. the number of seconds between executions.</param>
        public Interval(long seconds)
        {
            _seconds = seconds;
        }

        /// <summary>
        /// Returns the DateTime of the next execution in UTC time.
        /// </summary>
        /// <returns>The DateTime of the next execution in UTC time.</returns>
        public DateTime GetUtcExpirationDate()
        {
            return DateTime.UtcNow.AddSeconds(_seconds);
        }
    }
}