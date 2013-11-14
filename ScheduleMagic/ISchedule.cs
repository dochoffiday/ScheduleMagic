using System;

namespace ScheduleMagic
{
    public interface ISchedule
    {
        DateTime GetUtcExpirationDate();
    }
}
