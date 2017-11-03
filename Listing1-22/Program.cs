using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_22
{
    class Program
    {
        static void Main(string[] args)
        {
            // Without ordering, running on multiple threads
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0);

            foreach (int num in parallelResult.Take(5))
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}
