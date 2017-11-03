using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentStack
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (var i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (var i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    Interlocked.Decrement(ref n);
                }
            }

            up.Wait();

            Console.WriteLine(n);
            Console.Read();

        }
    }
}
