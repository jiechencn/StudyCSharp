using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest2
{
    class program
        {
        static void Main(string[] args)
        {
            MyMain1();//由于main方法无法定义成async,顾此定义一个方法MyMain来表示main方法。
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            MyMain2();
            
            Console.Read();
        }
        static async void MyMain1()
        {
            Console.WriteLine("----------------- main-1 1");
            AsyncAction1();
            Console.WriteLine("----------------- main-1 2");
            Console.WriteLine("----------------- main-1 3");
        }

        static async void MyMain2()
        {
            Console.WriteLine("---------------------------------- main-2 1");
            await AsyncAction2();
            Console.WriteLine("---------------------------------- main-2 2");
            Console.WriteLine("---------------------------------- main-2 3");
        }

        static async Task<string> AsyncAction1()
        {
            Console.WriteLine("----------------- AsyncAction-1 1");
            string result = await Task<string>.Run(() =>
            {
                Console.WriteLine("----------------- AsyncAction-1 1.5");
                Thread.Sleep(6000);
                Console.WriteLine("----------------- AsyncAction-1 2");
                return "hello async";
            });
            Console.WriteLine("----------------- AsyncAction-1 3 - {0}", result);
            return result;
        }

        static async Task<string> AsyncAction2()
        {
            Console.WriteLine("---------------------------------- AsyncAction-2 1");
            Thread.Sleep(5000);
            string result = await Task<string>.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("---------------------------------- AsyncAction-2 2");
                return "hello async";
            });
            Console.WriteLine("---------------------------------- AsyncAction-2 3 - {0}", result);
            return result;
        }
    }
}
