using System;

namespace ScheduleMagic.Schedules
{
    public class Daily : ISchedule
    {
        private int _hour;
        private int _minute;
        private String _timeZone;

        public Daily(int hour, int minute, String timeZone)
        {
            _hour = GetWithinRange<int>(hour, 0, 23);
            _minute = GetWithinRange<int>(hour, 0, 59);
            _timeZone = timeZone;
        }

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