﻿using System;

namespace ScheduleMagic.Schedules
{
    /// <summary>
    /// A task with this schedule will run once a day at the given hour/minute in the specified time zone.
    /// </summary>
    public class Daily : ISchedule
    {
        private int _hour;
        private int _minute;
        private String _timeZone;

        /// <summary>
        /// A task with this schedule will run once a day at the given hour/minute in the specified time zone.
        /// </summary>
        /// <param name="hour">0 based hour (0 - 23).</param>
        /// <param name="minute">0 based minute (0 - 59).</param>
        /// <param name="timeZone">Time zone (ex: "Eastern Standard Time").</param>
        public Daily(int hour, int minute, String timeZone)
        {
            _hour = GetWithinRange<int>(hour, 0, 23);
            _minute = GetWithinRange<int>(hour, 0, 59);
            _timeZone = timeZone;
        }

        /// <summary>
        /// Returns the DateTime of the next execution in UTC time.
        /// </summary>
        /// <returns>The DateTime of the next execution in UTC time.</returns>
        public DateTime GetUtcExpirationDate()
        {
            return GetNextOccurence(_hour, _minute, _timeZone);
        }

        private DateTime GetNextOccurence(int hour, int minute, String timeZone)
        {
            DateTime timeZoneCurrentTime = DateTimeHelper.GetCurrentDateTimeOfTimeZone(timeZone);
            DateTime nextOccurence = DateTimeHelper.GetNextOccurence(timeZoneCurrentTime, hour, minute);
            DateTime utcTime = DateTimeHelper.ToUtcTime(nextOccurence, timeZone);

            return utcTime;
        }

        private T GetWithinRange<T>(T value, T min, T max) where T : IComparable
        {
            return value.CompareTo(max) > 0 ? max : value.CompareTo(min) < 0 ? min : value;
        }
    }
}