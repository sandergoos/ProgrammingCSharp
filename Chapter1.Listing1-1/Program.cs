using System;
using System.Threading;

namespace Chapter1.Listing1_1
{
    public class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // Used to let windows know thread is finished
                Thread.Sleep(0);
            }
        }

        public static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("MainThread do some work.");
                Thread.Sleep(0);
            }

            t.Join();

            Console.Read();
        }
    }
}
