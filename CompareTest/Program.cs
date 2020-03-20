using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] stus =
             {
                new Student(22, "chen", 30),
                new Student(11, "jie", 41),
                new Student(33, "xyz", 10)
            };
            Console.WriteLine("-------------- order by default No.");
            Array.Sort(stus);
            foreach(var s in stus)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("-------------- order by Name");
            Array.Sort(stus, new StudentComparer(StudentComparerType.ByName));
            foreach (var s in stus)
            {
                Console.WriteLine(s);
            }
        }
    }
}
