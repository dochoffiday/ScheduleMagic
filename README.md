ScheduleMagic
===============

A simple task scheduler.

Create a Task
---------------

To create a task, simply create a class that implements IScheduledTask.

```csharp
public class GenericTask : IScheduledTask
{
    public void DoWork()
    {
        // do something
    }
}
```

Register the Task
---------------

To initialize the task (which is usually done when the application starts), invoke the scheduler with an instance of a schedule (you can use a default schedule, or create a schedule of your own).

```csharp
public class Global : System.Web.HttpApplication
{
	protected void Application_Start(object sender, EventArgs e)
	{
		Scheduler.Schedule<GenericTask>(new Daily(3, 30, "Eastern Standard Time"));
	}
}
```

(Optional) Create a Schedule
---------------
To create a new schedule, create a class that implements ISchedule.

```csharp
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
```