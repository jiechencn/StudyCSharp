using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeIsAsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var man = new Man();
            var worman = new Woman();
            man.Walk();
            worman.Walk();
            Console.WriteLine($"man.GetType() =  {man.GetType()}");
            Console.WriteLine($"typeof(Man) = {typeof(Man)}");
            Console.WriteLine($"man is Human ? {man is Human}");
            if (man is Woman)
            {
                Human man2 = man as Man;
                Console.WriteLine($"man2.GetType() = {man2.GetType()}");
            }

        }
    }
}
