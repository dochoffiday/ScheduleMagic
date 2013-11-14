using ScheduleMagic.Example.ScheduledTasks;
using ScheduleMagic.Schedules;
using System;

namespace ScheduleMagic.Example
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Scheduler.Schedule<GenericTask>(new Daily(3, 30, "Eastern Standard Time"));
        }
    }
}