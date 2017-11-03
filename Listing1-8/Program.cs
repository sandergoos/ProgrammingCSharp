using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 10000; x++)
                {
                    Console.Write('*');
                }
            });

            t.Wait();

        }
    }
}
