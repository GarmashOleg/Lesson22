using System;
using System.Threading;

namespace Lesson22_threads
{
    public class Program
    {
        readonly object locker = new object();

        public static void Main(string[] args)
        {
            var testExample = new Program();

            var threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(testExample.PrintNumbers);
                threads[i].Name = "Tread " + i;
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        public void PrintNumbers()
        {
            lock (locker)
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine($"Value {i} was created by {Thread.CurrentThread.Name}");
                }
                Console.WriteLine("===================================================");
            }
        }
    }
}
