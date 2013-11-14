using System;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Caching;

namespace ScheduleMagic
{
    public class Helper
    {
        internal static void Insert<T>(ISchedule schedule) where T : IScheduledTask
        {
            var name = typeof(T).AssemblyQualifiedName.ToString();
            var wrapper = new CacheWrapper(name, schedule);

            Insert(wrapper);
        }

        internal static void Insert(CacheWrapper wrapper)
        {
            try
            {
                var onCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
                var expiration = wrapper.Schedule.GetUtcExpirationDate();

                HttpRuntime.Cache.Insert(
                    wrapper.ToString(),
                    wrapper,
                    null,
                    expiration,
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.NotRemovable,
                    onCacheRemove);
            }
            catch { }
        }

        internal static void CacheItemRemoved(String k, object v, CacheItemRemovedReason r)
        {
            var wrapper = v as CacheWrapper;
            if (wrapper != null)
            {
                if (r == CacheItemRemovedReason.Expired)
                {
                    var scheduledTask = GetUninitializedObject(wrapper);

                    if (IsType<IScheduledTask>(scheduledTask))
                    {
                        ((IScheduledTask)scheduledTask).DoWork();

                        Helper.Insert(wrapper);
                    }
                }
                else
                {
                    Helper.Insert(wrapper);
                }
            }
        }

        internal static object GetUninitializedObject(CacheWrapper wrapper)
        {
            return FormatterServices.GetUninitializedObject(Type.GetType(wrapper.FullAssemblyName));
        }

        internal static bool IsType<T>(object obj)
        {
            return typeof(T).IsAssignableFrom(obj.GetType());
        }
    }
}