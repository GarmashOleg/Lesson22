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
                customers[i].Name = $"Thread {i}";
            }

            foreach(var thread in customers)
            {
                thread.Start();
            }
        }

        public class Shop
        {
            readonly Semaphore semaphore = new Semaphore(3, 3);

            public void EnterShop()
            {
                semaphore.WaitOne();

                Console.WriteLine($"The thread entered the shop: {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
                Console.WriteLine($"The thread {Thread.CurrentThread.Name} left the shop");

                semaphore.Release();
            }
        }
    }
}
