using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Class myClass = new Class();
            for (int i = 1; i <= 10; i++)
            {
                Student s = new Student("name_" + i, i);
                myClass.Add(s);
            }

            foreach(var o in myClass)
            {
                Console.WriteLine(o.Name);
            }
        }
    }
}
