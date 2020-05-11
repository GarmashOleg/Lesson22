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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            var task = new Task(() =>
            {
                for (int i = 0; ; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    Console.WriteLine($"Index {i}");
                    Thread.Sleep(500);
                }
            });

            task.Start();

            Console.WriteLine("for stop press K");
            var key = Console.ReadLine();

            if (key.ToLower() == "k")
            {
                cancellationTokenSource.Cancel();
                return;
            }


            Console.Read();
        }
    }
}
