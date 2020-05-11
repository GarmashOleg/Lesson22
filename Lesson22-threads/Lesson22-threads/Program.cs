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
            Task<string> task = Task.Factory.StartNew<string>(() =>
            {
                using (var wc = new WebClient())
                {
                    return wc.DownloadString("http://in4.com.ua/");
                }
            });


            var secondRun = Task.Run<string>(() =>
            {
                using (var wc = new WebClient())
                {
                    return wc.DownloadString("http://in4.com.ua/");
                }
            });


            var thirdRun = new Task<string>(() =>
            {
                using (var wc = new WebClient())
                {
                    return wc.DownloadString("http://in4.com.ua/");
                }
            });
            thirdRun.RunSynchronously();


            //Console.WriteLine(task.Result);
            //Console.WriteLine(secondRun);
            Console.WriteLine(thirdRun);


            PrintNumbers();
        }

        public static void PrintNumbers()
        {
            for (var i =0; i<100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
