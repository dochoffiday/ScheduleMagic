using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleMagic.Example.ScheduledTasks
{
    public class GenericTask : IScheduledTask
    {
        public void DoWork()
        {
            // do something
        }
    }
}