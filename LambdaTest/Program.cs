using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTest
{
    class Program
    {
        int num = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("------------ Actions begin");
            Actions();
            Console.WriteLine("------------ Functions begin");
            Functions();

            Linqs();


        }

        private static void Linqs()
        {
            List<int> ints = new List<int> { 1, 2, 4, 8, 4, 2, 1 };
            // Will contain { 1, 2, 4 }
            IEnumerable<int> result1 = ints.TakeWhile(theInt => theInt < 5);
            Console.WriteLine(result1) ;



            string result = "none";
            IEnumerable<string> strings = new List<string> { "four", "one", "two", "three", "five" };
            if (strings.Take(3).Any(s => s.StartsWith("a")))
            {
                if (strings.Skip(1).Take(2).All(s => s.Length == 3))
                {
                    result = "red";
                }
                else
                {
                    result = "orange";
                }
            }
            else
            {
                if (strings.All(s => s.Length > 2))
                {
                    if (strings.OrderBy(s => s).Take(3).Any(s => s == "one"))
                    {
                        result = "yellow";
                    }
                    else
                    {
                        result = "green";
                    }
                }
                else
                {
                    result = "blue";
                }
            }

            Console.WriteLine(result);


            IEnumerable<int> ints3 = new List<int> { 2, 4, 1, 6 };
            // Reimplementation of the Sum() method utilizing Aggregate()
            // Will return 13
            int result3 = ints3.Aggregate((sum, val) => sum + val);



            var studentsStream = new List<Student> {
                new Student { FullName = "Aruna", StreamId=1,  Score = 10 },
                new Student { FullName = "Janet", StreamId=2,  Score = 9  },
                new Student { FullName = "Ajay", StreamId=1,  Score = 11 },
                new Student { FullName = "Kunal", StreamId=2,  Score = 13  },
                new Student { FullName = "Chandra", StreamId=2,  Score = 8  },
            };
            //Method syntax
            var _studentNames1 = studentsStream.Where(s=>s.StreamId==2).Select(s => new { s.FullName, s.Score}).OrderBy(s=>s.Score);
            _studentNames1.ToList().ForEach(s =>
            {
                Console.WriteLine($"{s.FullName} - {s.Score}");
            });
        }

        private static void Functions()
        {
            // no parameter, retrun string
            Func<string> Do1 = () =>
            {
                return "func do1";
            };

            // string parameter, retrun int
            Func<string, int> Do2 = (str1) =>
            {
                return str1.Length;
            };

            // two string parameters, return int
            Func<string, string, int> Do3 = (str1, str2) =>
            {
                string str3 = str1 + str2;
                return str3.Length;
            };

            string s1 = Do1(); Console.WriteLine(s1);
            int n2 = Do2("func do2"); Console.WriteLine(n2);
            int n3 = Do3("func", "do3"); Console.WriteLine(n3);
        }

        private static void Actions()
        {
            Action Do1 = () =>
            {
                Console.WriteLine("action do1");
            };

            Action<string> Do2 = (str1) =>
            {
                Console.WriteLine(str1);
            };

            Action<string, int> Do3 = (str1, n) =>
            {
                for (int i = 0; i < n; i++)
                {
                    str1 += str1;
                }
                Console.WriteLine(str1);
            };

            Do1();
            Do2("action do2");
            Do3("action do3", 2);
        }
    }

    public class Student
    {
        public string FullName { get; set; }
        public int StreamId { get; set; }
        public int Score { get; set; }
    }
}
