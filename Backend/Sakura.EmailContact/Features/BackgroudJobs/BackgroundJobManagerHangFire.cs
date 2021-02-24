using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sakura.EmailContact.Features.BackgroudJobs
{
    public class BackgroundJobManagerHangFire : IBackgroundJobManager
    {

        public string Enqueue<T>(Expression<Func<T, Task>> methodCall)
        {
            return Hangfire.BackgroundJob.Enqueue<T>(methodCall);
        }

        public string Schedule<T>(Expression<Func<T, Task>> methodCall, DateTime enqueueAt)
        {
            return Hangfire.BackgroundJob.Schedule<T>(methodCall, enqueueAt);
        }
    }
}
