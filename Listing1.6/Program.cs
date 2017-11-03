using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listing1._6
{
    public class Program
    {
        // This will create a field for each thread individually
        public static ThreadLocal<int> _field = new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        public static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (var x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine($"Thread A: {x}");
                }
            }).Start();

            new Thread(() =>
            {
                for (var x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine($"Thread B: {x}");
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
