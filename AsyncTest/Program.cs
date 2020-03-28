using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var b = BusyMorning();
            b.Wait();
            
            Console.WriteLine("***********  busy morning is finished");

            Console.Read();
        }

        private static async Task<bool> BusyMorning()
        {
            var heatWaterTask = HeatWaterAsync(20);
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
            await Task.Run(() =>
            {
                Thread.Sleep(seconds * 1000);
            });
            Console.WriteLine("BrushTeeth  ----  done");
            return true;
        }
        static async Task<bool> WashFaceAsync(int seconds, bool brushed)
        {
            if (!brushed) return false;
            Console.WriteLine("WashFace " + seconds);
            await Task.Run(() =>
            {
                Thread.Sleep(seconds * 1000);
            });
            Console.WriteLine("WashFace  ----  done");
            return true;
        }
        static async Task<bool> CookNoodleAsync(int seconds, bool heated)
        {
            if (!heated) return false;
            Console.WriteLine("CookNoodle " + seconds);
            await Task.Run(() =>
            {
                Thread.Sleep(seconds * 1000);
            });
            Console.WriteLine("CookNoodle  ----  done");
            return true;
        }
        static async Task<bool> EatNoodleAsync(int seconds, bool cooked)
        {
            if (!cooked) return false;
            Console.WriteLine("EatNoodle " + seconds);
            await Task.Run(() =>
            {
                Thread.Sleep(seconds * 1000);
            }); 
            Console.WriteLine("EatNoodle  ----  done");
            return true;
        }

    }
}
