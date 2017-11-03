using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listing1_19
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public Task SleepAsyncA(int milisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(milisecondsTimeout));
        }

        public Task SleepASyncB(int milisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(milisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}
