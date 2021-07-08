using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task b = MyMorningBegins();
            //b.Wait();
            //MyMorningBegins();
            Console.WriteLine("go to school....");

            Console.Read();
        }

        private static async Task MyMorningBegins()
        {
            await BusyMorning();
            Console.WriteLine("***********  busy morning is finished");

        }

        private static async Task<bool> BusyMorning()
        {
            Task<bool> heatWaterTask = HeatWaterAsync(20);
            var brushTeethTask = BrushTeethAsync(3);
            var washFaceTask = WashFaceAsync(3, await brushTeethTask);
            await washFaceTask;
            var cookNoodleTask = CookNoodleAsync(5, await heatWaterTask);
            var eatNoodleTask = EatNoodleAsync(6, await cookNoodleTask);
            await eatNoodleTask;
            return true;
        }
        static async Task<bool> HeatWaterAsync(int seconds)
        {
            Console.WriteLine("HeatWater " + seconds);
            await DoBusy(seconds);
            Console.WriteLine("HeatWater  ----  done");
            return true;
        }

        private static async Task DoBusy(int seconds)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(seconds * 1000);
            });
        }

        static async Task<bool> BrushTeethAsync(int seconds)
        {
            Console.WriteLine("BrushTeeth " + seconds);
            await DoBusy(seconds);
            Console.WriteLine("BrushTeeth  ----  done");
            return true;
        }
        static async Task<bool> WashFaceAsync(int seconds, bool brushed)
        {
            if (!brushed) return false;
            Console.WriteLine("WashFace " + seconds);
            await DoBusy(seconds);
            Console.WriteLine("WashFace  ----  done");
            return true;
        }
        static async Task<bool> CookNoodleAsync(int seconds, bool heated)
        {
            if (!heated) return false;
            Console.WriteLine("CookNoodle " + seconds);
            await DoBusy(seconds);
            Console.WriteLine("CookNoodle  ----  done");
            return true;
        }
        static async Task<bool> EatNoodleAsync(int seconds, bool cooked)
        {
            if (!cooked) return false;
            Console.WriteLine("EatNoodle " + seconds);
            await DoBusy(seconds);
            Console.WriteLine("EatNoodle  ----  done");
            return true;
        }

    }
}
