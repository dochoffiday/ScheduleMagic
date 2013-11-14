using System;

namespace ScheduleMagic
{
    internal class CacheWrapper
    {
        public Guid ID;
        public String FullAssemblyName;
        public ISchedule Schedule;

        public CacheWrapper(String fullAssemblyName, ISchedule schedule)
        {
            ID = Guid.NewGuid();
            FullAssemblyName = fullAssemblyName;
            Schedule = schedule;
        }

        public override string ToString()
        {
            const string SUFFIX = "SCHEDULEMAGIC.SUFFIX.";

            return String.Format("{0}{1}", SUFFIX, ID);
        }
    }
}