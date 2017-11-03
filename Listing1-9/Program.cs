using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 23;
            });

            Console.WriteLine(t.Result);
            Console.ReadKey();
        }
    }
}
