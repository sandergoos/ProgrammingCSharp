using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Listing1_16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers, number =>
            {
                Thread.Sleep(1000);
            });
        }
    }
}
