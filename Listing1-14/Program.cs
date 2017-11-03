﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Listing1_14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(1);
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(2);
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(3);
            });

            Task.WaitAll(tasks);
            Console.Read();
        }
    }
}
