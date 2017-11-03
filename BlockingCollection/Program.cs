using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockingCollection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bc = new BlockingCollection<string>();

            Task reader = Task.Run(() =>
            {
                foreach (string v in bc.GetConsumingEnumerable())
                {
                    Console.WriteLine(v);
                }
            });

            Task writer = Task.Run(() =>
            {
                while (true)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        break;
                    }
                    bc.Add(input);
                }
            });

            writer.Wait();
        }
    }
}
