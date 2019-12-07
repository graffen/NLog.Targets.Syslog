// Licensed under the BSD license
// See the LICENSE file in the project root for more information

using System;
using System.Threading;
using System.Threading.Tasks;

namespace NLog.Targets.Syslog.Extensions
{
    internal static class TaskExtensions
    {
        public static Task<TResult> Then<TResult>(this Task task, Func<Task, TResult> continuationFunction, CancellationToken token)
        {
            return task
                .ContinueWith(t =>
                {
                    var tcs = new TaskCompletionSource<TResult>();

                    if (t.IsCanceled)
                        tcs.SetCanceled();
                    else if (t.Exception != null) // t.IsFaulted is true
                        tcs.SetException(t.Exception.GetBaseException());
                    else
                        tcs.SetResult(continuationFunction(t));

                    return tcs.Task;
                }, token, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Current)
                .Unwrap();
        }
    }
}