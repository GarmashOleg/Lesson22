using System;
using System.Threading;

namespace Lesson22_threads
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var shop = new Shop();

            var customers = new Thread[15];
            for(int i=0; i< customers.Length; i++)
            {
                customers[i] = new Thread(shop.EnterShop);
                //customers[i].Name = $"Thread {i}";
            }

            for(int i =0; i < customers.Length; i++)
            {
                customers[i].Start($"Thread {i}");
            }
        }

        public class Shop
        {
            readonly Semaphore semaphore = new Semaphore(1, 1);

            public void EnterShop(object param)
            {
                var threadName = (string)param;
                semaphore.WaitOne();

                Console.WriteLine($"The thread entered the shop: {threadName}");
                Thread.Sleep(1000);
                Console.WriteLine($"The thread {threadName} left the shop");

                semaphore.Release();
            }
        }
    }
}
