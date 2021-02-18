using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sakura.EmailContact.Features.BackgroudJobs
{
    public interface IBackgroundJobManager
    {
        string Enqueue<T>(Expression<Action<T>> methodCall);
        string Schedule<T>(Expression<Func<T, Task>> methodCall, DateTime enqueueAt);
    }
}
