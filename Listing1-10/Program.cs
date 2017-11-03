using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((lastThread) =>
            {
                return lastThread.Result * 2;
            });

            Console.WriteLine(t.Result);
            Console.Read();
        }
    }
}
