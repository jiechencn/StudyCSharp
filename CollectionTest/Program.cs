using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<Student, int> chinese_scores = new SortedDictionary<Student, int>();
            chinese_scores.Add(new Student(10, "stu_name_a"), 98);
            chinese_scores.Add(new Student(1, "stu_name_x"), 88);
            chinese_scores.Add(new Student(45, "stu_name_y"), 90);
            chinese_scores.Add(new Student(12, "stu_name_c"), 96);
            chinese_scores.Add(new Student(2, "stu_name_m"), 78);

            Console.WriteLine("sort dictionary by student's ID by default");
            foreach(var cscore in chinese_scores)
            {
                Console.WriteLine($"{cscore.Key}={cscore.Value}");

            }

            Console.WriteLine("sort dictionary by student's Name by default");
            SortedDictionary<Student, int> english_scores = new SortedDictionary<Student, int>(new StudentComparer());
            english_scores.Add(new Student(10, "stu_name_a"), 98);
            english_scores.Add(new Student(45, "stu_name_y"), 75);
            english_scores.Add(new Student(1, "stu_name_x"), 86);
            english_scores.Add(new Student(12, "stu_name_c"), 83);
            english_scores.Add(new Student(2, "stu_name_m"), 77);
            foreach (var escore in english_scores)
            {
                Console.WriteLine($"{escore.Key}={escore.Value}");

            }

            Console.WriteLine("sort list by student's ID by default");
            SortedList<Student, int> sorted_scores = new SortedList<Student, int>(english_scores);
            foreach (var cscore in sorted_scores)
            {
                Console.WriteLine($"{cscore.Key}={cscore.Value}");

            }

            Console.WriteLine("sort list by student's Name by default");
            SortedList<Student, int> sorted_scores2 = new SortedList<Student, int>(english_scores, new StudentComparer());
            foreach (var cscore in sorted_scores2)
            {
                Console.WriteLine($"{cscore.Key}={cscore.Value}");

            }

        }
    }
}
