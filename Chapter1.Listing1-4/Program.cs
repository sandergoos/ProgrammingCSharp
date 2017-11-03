using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Chapter1.Listing1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stopped = false;
            var count = 0;

            List<Thread> threads = new List<Thread>();
            for(var i = 0; i < 1; i++)
            {
                var x = i;
                threads.Add(new Thread(new ThreadStart(() =>
                {
                    while (!stopped)
                    {
                        Console.WriteLine($"Thread {x}: count: {count++}");
                        Thread.Sleep(0);
                    }
                })));
            }

            foreach(Thread t in threads)
            {
                t.Start();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            // Using a global scope boolean variable to signal to the threads they need to stop.
            stopped = true;

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }
    }
}
