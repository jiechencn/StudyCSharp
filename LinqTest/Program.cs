using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var classes = new List<Class>()
            {
                new Class(2, "Class Two"),
                new Class(1, "Class One"),
                new Class(4, "Class Four"),
                new Class(3, "Class Three")
            };
            var scores = new List<Score>()
            {
                new Score(1, "student_name_1_tom", 98),
                new Score(2, "student_name_2_jerry", 95),
                new Score(3, "student_name_3_kate", 99),
                new Score(4, "student_name_4_marry", 88),
                new Score(1, "student_name_1_jack", 79),
                new Score(2, "student_name_2_jim", 90),
                new Score(3, "student_name_3_peter", 86),
                new Score(4, "student_name_4_john", 91),
                new Score(1, "student_name_1_tommy", 99),
                new Score(1, "student_name_1_jacki", 68),
                new Score(2, "student_name_2_micky", 99),
                new Score(2, "student_name_2_mini", 68),
                new Score(4, "student_name_4_jeff", 63),
            };


            Console.WriteLine("----------------------------------------------------order all students by grade and class");
            var queryByAllGrades = from score in scores
                                   join klass in classes
                                   on score.ClassID equals klass.ID
                                   orderby score.Point descending, klass.ID
                                   select new { score.ClassID, klass.Name, score.StudentName, score.Point };
            foreach (var ss in queryByAllGrades)
            {
                Console.WriteLine($"class id: {ss.ClassID}, class name: {ss.Name}, student: {ss.StudentName}, grade: {ss.Point}");
            }


            Console.WriteLine("----------------------------------------------------order all students by grade and class, method 2");
            var queryByAllGrades2 = scores.Join(classes, score => score.ClassID, klass => klass.ID, (score, klass) => new
            {
                score.ClassID,
                klass.Name,
                score.StudentName,
                score.Point
            }).OrderBy(c=>c.ClassID).OrderByDescending(c => c.Point);
            foreach (var ss in queryByAllGrades2)
            {
                Console.WriteLine($"class id: {ss.ClassID}, class name: {ss.Name}, student: {ss.StudentName}, grade: {ss.Point}");
            }

            Console.WriteLine("---------------------------------------------------- get all students whose point is highest");
            var queryHighestStu = from score in scores
                                    join klass in classes
                                    on score.ClassID equals klass.ID
                                    where score.Point == scores.Max(s => s.Point)
                                    orderby klass.ID
                                    select new { score.ClassID, klass.Name,  score.StudentName, score.Point };
            
            foreach (var hs in queryHighestStu)
            {
                Console.WriteLine($"class id: {hs.ClassID}, class name: {hs.Name}, student: {hs.StudentName}, grade: {hs.Point}");
            }

            Console.WriteLine("---------------------------------------------------- get all students whose point is highest: method 2");
            var queryHighestStu2 = scores.Join(classes, s => s.ClassID, k => k.ID,
                (s, c) => new
                {
                    s.ClassID,
                    c.Name,
                    s.StudentName,
                    s.Point
                }).Where(sc=>sc.Point == scores.Max(c=>c.Point)).OrderBy(sc=>sc.ClassID);

            foreach (var hs in queryHighestStu2)
            {
                Console.WriteLine($"class id: {hs.ClassID}, class name: {hs.Name}, student: {hs.StudentName}, grade: {hs.Point}");
            }


            Console.WriteLine("---------------------------------------------------- get each class's high point");
            var queryHighPointByClass = from score in scores
                                            join klass in classes
                                            on score.ClassID equals klass.ID
                                            group score by new
                                            {
                                                score.ClassID,
                                                klass.Name
                                            }
                                            into g
                                            orderby g.Average(cc => cc.ClassID)
                                            select new { NewClassID = g.Key.ClassID, NewClassName = g.Key.Name, ClassAvgPoint = g.Max(cc => cc.Point) }
                                             ;
            foreach (var ap in queryHighPointByClass)
            {
                Console.WriteLine($"class id: {ap.NewClassID}, class name: {ap.NewClassName}, averiage point: {ap.ClassAvgPoint}");
            }
            Console.WriteLine("---------------------------------------------------- get each class's high point: method 2");
            var queryHighPointByClass2 = classes.GroupJoin(scores, _class => _class.ID, _score => _score.ClassID, (_class, _class_scores) => new
            {
                NewClassID = _class.ID,
                NewClassName = _class.Name,
                AveriageScore = _class_scores.Max(s => s.Point)
            }).OrderBy(r => r.NewClassID);

            foreach (var ap in queryHighPointByClass2)
            {
                Console.WriteLine($"class id: {ap.NewClassID}, class name: {ap.NewClassName}, averiage point: {ap.AveriageScore}");
            }

            Console.WriteLine("---------------------------------------------------- get each class's averiage point");
            var queryAveriagePointByClass = from score in scores
                                            join klass in classes
                                            on score.ClassID equals klass.ID
                                            group score by new
                                            {
                                                score.ClassID,
                                                klass.Name
                                            }
                                            into g
                                            orderby g.Average(cc => cc.Point) descending
                                            select new {NewClassID = g.Key.ClassID, NewClassName =g.Key.Name, ClassAvgPoint =  g.Average(cc=>cc.Point) }
                                             ;
            foreach (var ap in queryAveriagePointByClass)
            {
                Console.WriteLine($"class id: {ap.NewClassID}, class name: {ap.NewClassName}, averiage point: {ap.ClassAvgPoint}");
            }

            Console.WriteLine("---------------------------------------------------- get each class's averiage point: method 2");
            var queryAveriagePointByClass2 = classes.GroupJoin(scores, _class => _class.ID, _score => _score.ClassID, (_class, _class_scores) => new
            {
                NewClassID = _class.ID,
                NewClassName = _class.Name,
                AveriageScore = _class_scores.Average(s => s.Point)
            }).OrderByDescending(r=>r.AveriageScore);

            foreach (var ap in queryAveriagePointByClass2)
            {
                Console.WriteLine($"class id: {ap.NewClassID}, class name: {ap.NewClassName}, averiage point: {ap.AveriageScore}");
            }



            /*
            ----------------------------------------------------order all students by grade and class
            class id: 1, class name: Class One, student: student_name_1_tommy, grade: 99
            class id: 2, class name: Class Two, student: student_name_2_micky, grade: 99
            class id: 3, class name: Class Three, student: student_name_3_kate, grade: 99
            class id: 1, class name: Class One, student: student_name_1_tom, grade: 98
            class id: 2, class name: Class Two, student: student_name_2_jerry, grade: 95
            class id: 4, class name: Class Four, student: student_name_4_john, grade: 91
            class id: 2, class name: Class Two, student: student_name_2_jim, grade: 90
            class id: 4, class name: Class Four, student: student_name_4_marry, grade: 88
            class id: 3, class name: Class Three, student: student_name_3_peter, grade: 86
            class id: 1, class name: Class One, student: student_name_1_jack, grade: 79
            class id: 1, class name: Class One, student: student_name_1_jacki, grade: 68
            class id: 2, class name: Class Two, student: student_name_2_mini, grade: 68
            class id: 4, class name: Class Four, student: student_name_4_jeff, grade: 63
            ----------------------------------------------------order all students by grade and class, method 2
            class id: 1, class name: Class One, student: student_name_1_tommy, grade: 99
            class id: 2, class name: Class Two, student: student_name_2_micky, grade: 99
            class id: 3, class name: Class Three, student: student_name_3_kate, grade: 99
            class id: 1, class name: Class One, student: student_name_1_tom, grade: 98
            class id: 2, class name: Class Two, student: student_name_2_jerry, grade: 95
            class id: 4, class name: Class Four, student: student_name_4_john, grade: 91
            class id: 2, class name: Class Two, student: student_name_2_jim, grade: 90
            class id: 4, class name: Class Four, student: student_name_4_marry, grade: 88
            class id: 3, class name: Class Three, student: student_name_3_peter, grade: 86
            class id: 1, class name: Class One, student: student_name_1_jack, grade: 79
            class id: 1, class name: Class One, student: student_name_1_jacki, grade: 68
            class id: 2, class name: Class Two, student: student_name_2_mini, grade: 68
            class id: 4, class name: Class Four, student: student_name_4_jeff, grade: 63
            ---------------------------------------------------- get all students whose point is highest
            class id: 1, class name: Class One, student: student_name_1_tommy, grade: 99
            class id: 2, class name: Class Two, student: student_name_2_micky, grade: 99
            class id: 3, class name: Class Three, student: student_name_3_kate, grade: 99
            ---------------------------------------------------- get all students whose point is highest: method 2
            class id: 1, class name: Class One, student: student_name_1_tommy, grade: 99
            class id: 2, class name: Class Two, student: student_name_2_micky, grade: 99
            class id: 3, class name: Class Three, student: student_name_3_kate, grade: 99
            ---------------------------------------------------- get each class's high point
            class id: 1, class name: Class One, averiage point: 99
            class id: 2, class name: Class Two, averiage point: 99
            class id: 3, class name: Class Three, averiage point: 99
            class id: 4, class name: Class Four, averiage point: 91
            ---------------------------------------------------- get each class's high point: method 2
            class id: 1, class name: Class One, averiage point: 99
            class id: 2, class name: Class Two, averiage point: 99
            class id: 3, class name: Class Three, averiage point: 99
            class id: 4, class name: Class Four, averiage point: 91
            ---------------------------------------------------- get each class's averiage point
            class id: 3, class name: Class Three, averiage point: 92.5
            class id: 2, class name: Class Two, averiage point: 88
            class id: 1, class name: Class One, averiage point: 86
            class id: 4, class name: Class Four, averiage point: 80.6666666666667
            ---------------------------------------------------- get each class's averiage point: method 2
            class id: 3, class name: Class Three, averiage point: 92.5
            class id: 2, class name: Class Two, averiage point: 88
            class id: 1, class name: Class One, averiage point: 86
            class id: 4, class name: Class Four, averiage point: 80.6666666666667
            
             */

        }
    }
}
