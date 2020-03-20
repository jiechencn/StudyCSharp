using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateTest
{
    public delegate double Calc(double x, double y);
    public delegate void Print(string x);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********* normal delegate");
            // 普通委托, 委托类声明的方法有什么样的参数和返回类型，被委托的方法也必须有同样的参数和返回类型
            Program p = new Program();
            Calc myCalc1 = new Calc(p.Add);
            Calc myCalc2 = new Calc(p.Sub);
            Calc myCalc3 = p.Mult;

            //Calc myCalc3 = new Calc(p.Mult); same as above
            double a = 11, b = 10;
            Console.WriteLine(myCalc1.Invoke(a, b)); // +
            Console.WriteLine(myCalc2.Invoke(a, b)); // -
            Console.WriteLine(myCalc3.Invoke(a, b)); // *

            Calc myCalc4 = p.Mult;
            Console.WriteLine(p.doCalc1(myCalc4, a, b)); // *

            Console.WriteLine("********* Func delegate");
            // Func委托,  被委托的函数有返回值
            Console.WriteLine(p.doFunc(p.Sub, a, b));   // 
            Console.WriteLine(p.doFunc(p.Add, a, b));   // 
            // Action委托, 被委托的函数无返回值，即 void
            Console.WriteLine("********* Action delegate");
            p.doAction(p.Print, a, b);   // -

            Console.WriteLine("********* Multicast delegate");
            // 多播委托，每个被委托的函数必须返回为void，否则只会返回最后一个函数的结果
            Print multiPrint = new Print(p.Print1);
            multiPrint += p.Print2;
            //multiPrint -= p.Print1;
            multiPrint.Invoke("hello");

            Console.WriteLine("********* Anonymous delegate");
            // 匿名委托
            Func<double, double, double> tempAdd = delegate (double x, double y)
            {
                return x + y;
            };
            Action<string> tempPrint = delegate (string s)
            {
                Console.WriteLine(s);
            };
            double result = tempAdd(11, 22);
            Console.WriteLine(result);
            tempPrint("hello");
            tempPrint.Invoke("world");


            Console.WriteLine("********* Action and Func together");
            p.TriggerAlert(p.SendAlert, p.Log2File);

        }
        
        public double doCalc1(Calc calc, double a, double b)
        {
            return calc.Invoke(a, b);
        }

        // Func<double, double, double>中的前面2个double是被委托方法的参数类型，第三个double是被委托方法的返回类型
        public double doFunc(Func<double, double, double> calc, double a, double b)
        {
            return calc.Invoke(a, b);
        }
        // Action<double, double>中的两个double表示被委托方法的参数类型，Action不允许有返回值，只能为void
        public void doAction(Action<double, double> action, double a, double b)
        {
            action(a, b);
        }

        public void Print(double a, double b)
        {
            Console.WriteLine($"a={a}, b={b}");
        }

        public void Print1(string a)
        {
            Console.WriteLine($"a1={a}");
        }
        public void Print2(string a)
        {
            Console.WriteLine($"a2={a}");
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public double Mult(double a, double b)
        {
            return a * b;
        }

        public void Log2File(string filename)
        {
            Console.WriteLine($"log written into file:{filename}");
        }

        public bool SendAlert(string recipient)
        {
            Console.WriteLine($"Alert sent to:{recipient}");
            return true;
        }
        public void TriggerAlert(Func<string, bool> alert, Action<string> log)
        {
            alert.Invoke("jiechencn@qq.com");
            log.Invoke("alert.log");

        }
    }
}
