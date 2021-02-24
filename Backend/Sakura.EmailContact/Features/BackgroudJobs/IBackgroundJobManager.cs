using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sakura.EmailContact.Features.BackgroudJobs
{
    public interface IBackgroundJobManager
    {
        string Enqueue<T>(Expression<Func<T, Task>> methodCall);
        string Schedule<T>(Expression<Func<T, Task>> methodCall, DateTime enqueueAt);
    }
}
