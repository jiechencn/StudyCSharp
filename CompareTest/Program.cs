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
                new Student(33, "xyz", 10),
                new Student(22, "chen2", 20),
                new Student(25, "chen3", 20)
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

            Console.WriteLine("--------------");
            StudentCollection stuCollect = new StudentCollection(stus);
            var sameAgedStus = stuCollect[20];
            foreach (Student s in sameAgedStus)
            {
                Console.WriteLine(s.Name);
            }


            Console.ReadKey();
        }


    }
}
