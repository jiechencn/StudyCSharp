using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Program p = new Program();
            string health = await p.CaculatorAsync();

            Console.WriteLine(health);
            Console.Read();
        }

         
        async Task<string> CaculatorAsync()
        {
            Task<int> w = GetWeight(10);
            //_ = Talking(4);
            _ = Task.Run(() =>
            {
                _= Talking(10);
            });
            int age = GetAge(6);
            Task<int> h = GetHeight(3);
            Task<bool> b = CalculateHealth(age, await w, await h, 2);
            string health = "";
            if (await b)
            {
                health = "good";
            }
            else
            {
                health = "bad";
            }
            return health;
        }
        int GetAge(int a)
        {
            Console.WriteLine("---------------age-0");
            Thread.Sleep(a * 1000);
            Console.WriteLine("---------------age-1");
            return 20;
        }

        async Task<int> GetWeight(int w)
        {
            Console.WriteLine("--------------------------------weight-0");
            await Task.Run(() =>
            {
                Thread.Sleep(w * 1000);
            });
            Console.WriteLine("---------------- ---------------weight-1");
            return 102;
        }

        async Task<int> GetHeight(int h)
        {
            Console.WriteLine("-------------- - ------------------------------Height-0");
            await Task.Run(() =>
            {
                Thread.Sleep(h * 1000);
            });
            Console.WriteLine("-------------- - ------------------------------Height-1");
            return 160;
        }

        async Task<bool> CalculateHealth(int age, int weight, int height, int h)
        {
            Console.WriteLine("-------------- - ---------------------------------------------health-0");
            await Task.Run(() =>
            {
                Thread.Sleep(h * 1000);
            });
            Console.WriteLine("-------------- - ---------------------------------------------health-1");
            return true;
        }

        async Task Talking(int t)
        {
            Console.WriteLine("-------------- - ---------------------------------------------talking-0");
            await Task.Run(() =>
            {
                Thread.Sleep(t * 1000);
            });
            Console.WriteLine("-------------- - ---------------------------------------------talking-1");

        }
       
    }
}
