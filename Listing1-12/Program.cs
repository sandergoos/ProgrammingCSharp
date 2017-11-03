using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1_12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var result = new Int32[3];
                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return result;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (int i in parentTask.Result)
                {
                    Console.WriteLine(i);
                }
            });

            finalTask.Wait();
            Console.Read();
        }
    }
}
