using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_17
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel
                .For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.Write("Breaking loop");
                        loopState.Break();
                    }
                });

            Console.Read();
        }
    }
}
