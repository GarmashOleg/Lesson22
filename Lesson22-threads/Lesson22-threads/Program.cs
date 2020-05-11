using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson22_threads
{
    public class Program
    {


        public static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";

            Console.WriteLine("Simple array");
            for (int i=0; i<10; i++)
            {
                Console.WriteLine($"Index {i} was printed by {Thread.CurrentThread.Name}");
                Thread.Sleep(500);
            }

            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("Parallel processing");

            Parallel.For(0, 10, count =>
            {
                Console.WriteLine($"Index {count} was printed by {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            });
        }
    }
}
