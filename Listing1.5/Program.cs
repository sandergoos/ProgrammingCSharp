using System;
using System.Threading;

namespace Listing1._5
{
    public class Program
    {
        [ThreadStatic]
        public static int _field;
        public static void Main(string[] args)
        {
            // Each thread will have its own value of _field to
            // work with because of ThreadStatic Attribute
            new Thread(() =>
            {
                for (var x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine($"Thread A: {_field}");
                }
            }).Start();

            new Thread(() =>
            {
                for (var x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine($"Thread B: {_field}");
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
