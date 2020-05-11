using System;
using System.Threading;

namespace Lesson22_threads
{
    public class Program
    {
        readonly object locker = new object();
        bool isDone;

        public static void Main(string[] args)
        {
            var testExample = new Program();

            Thread.CurrentThread.Name = "Main";


            //second thread
            var secondThread = new Thread(testExample.PrintNumbers);
            secondThread.Name = "second thread";
            secondThread.Start();

            var threadThread = new Thread(testExample.PrintNumbers);
            threadThread.Name = "third thread";
            threadThread.Start();

            testExample.PrintNumbers();
        }

        public void PrintNumbers()
        {
            //Console.WriteLine($"Current thread: " + Thread.CurrentThread.Name);

            lock (locker)
            {


                for (int i = 0; i < 10; i++)
                {
                    if (!isDone)
                    {
                        Console.WriteLine($"Value {i} was created by {Thread.CurrentThread.Name}");
                        Console.WriteLine($"Value {i} was finished {Thread.CurrentThread.Name}");
                        isDone = false;
                    }

                }
            }
        }
    }
}
