using System;

namespace ScheduleMagic
{
    public class DateTimeHelper
    {
        public static DateTime GetCurrentDateTimeOfTimeZone(String timeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }

        public static DateTime GetNextOccurence(DateTime dateTime, int hour, int minute)
        {
            DateTime today = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, 0);

            if (today < dateTime)
            {
                return today.AddDays(1);
            }

            return today;
        }

        public static DateTime ToLocalTime(DateTime dateTime, String timeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById(timeZone), TimeZoneInfo.Local);
        }

        public static DateTime ToUtcTime(DateTime dateTime, String timeZone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }
    }
}