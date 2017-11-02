using System;
using System.Threading;

namespace Chapter1_Listing1_2
{
    class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            // When all foreground threads finish, CLR will close down application
            // so in this case the application will be shut down instantly
            t.IsBackground = true;
            t.Start();
        }
    }
}
