using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace LinqTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(">> Preparing students info and scores info");
            int numberOfStudent = 9;
            IList<string> subjects = new List<string>(){ "Chinese", "Maths", "English"};
            IList<Student> students = PrepareStudentsData(numberOfStudent);
            IList<Score> scores = PrepareScoresData(numberOfStudent, subjects);

            Console.WriteLine(String.Format("{0,2}\t{1,-18}\t{2}", "No", "Sex", "Full Name"));
            Console.WriteLine(String.Format("{0,2}\t{1,-18}\t{2}", "-----", "-----", "-----"));
            foreach (Student stu in students)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,2}\t{1,-18}\t{2}", "No", "Subject", "Point"));
            Console.WriteLine(String.Format("{0,2}\t{1,-18}\t{2}", "-----", "-----", "-----"));
            foreach (Score sc in scores)
            {
                Console.WriteLine(sc);
            }
            subjects.Add("Science");

            int topN = 3;

            // 统计单科前三名的学生成绩
            Console.WriteLine();
            Console.WriteLine("Top 3 students for each subject");
            Get_TopNStudentsForEachSubject(students, scores, subjects, topN);

            // 统计单科90分以上的学生成绩
            Console.WriteLine();
            Console.WriteLine("Show students above 90 points for each subject");
            Get_StudentsAbovePointsForEachSubject(students, scores, subjects, 90);

            // 统计总分前三名的学生成绩
            Console.WriteLine();
            Console.WriteLine("Top 3 students for total points of all subjects");
            Get_TopNStudentsWithHighTotalPoints(students, scores, subjects, topN);


            // 按照性别统计各科的平均成绩
            Console.WriteLine();
            Console.WriteLine("Show averiage point for each subject per gender");
            Get_AveriagePointsForEachSubjectPerGender(students, scores, subjects);
        }

        private static void Get_TopNStudentsWithHighTotalPoints(IList<Student> students, IList<Score> scores, IList<string> subjects, int topN)
        {
            var topNStudentsTotalPoints = (from topScore in
                                          (from score in scores
                                           group score by score.No into scoregroup
                                           let subjectScore = scoregroup.Sum(cg => cg.Point)
                                           orderby subjectScore descending
                                           select new
                                           {
                                               No = scoregroup.Key,
                                               Points = subjectScore
                                           }).Take(topN)
                                           join student in students on topScore.No equals student.No
                                           select new
                                           {
                                               No = topScore.No,
                                               Student = student,
                                               Points = topScore.Points
                                           }
                                           ).ToList();

            foreach(var item in topNStudentsTotalPoints)
            {
                Console.WriteLine(item.Student.ToString() + "\t total score = " + item.Points.ToString());
            }


        }

        private static void Get_TopNStudentsForEachSubject(IList<Student> students, IList<Score> scores, IList<string> subjects, int topN)
        {
            var topNStudentsForSubjects = (from subject in subjects
                                           join score in scores on subject equals score.Subject into scoresPerSubject
                                           select new
                                           {
                                               Subject = subject,
                                               TopN = (
                                                       from item in scoresPerSubject
                                                       join student in students
                                                       on item.No equals student.No
                                                       orderby item.Point descending
                                                       select new
                                                       {
                                                           item.Subject,
                                                           item.Point,
                                                           item.No,
                                                           student.Fullname,
                                                           student.Sex
                                                      }).Take(topN)
                                            }).ToList();

            foreach(var item in topNStudentsForSubjects)
            {
                Console.WriteLine(item.Subject);
                foreach (var score in item.TopN)
                {
                    Console.WriteLine(score);
                }
            }
        }

        private static void Get_StudentsAbovePointsForEachSubject(IList<Student> students, IList<Score> scores, IList<string> subjects, double points)
        {
            var highPointStudentsForSubjects = (from subject in subjects
                                           join score in scores on subject equals score.Subject into scoresPerSubject
                                           select new
                                           {
                                               Subject = subject,
                                               HighPointStudent = (
                                                       from item in scoresPerSubject
                                                       join student in students
                                                       on item.No equals student.No
                                                       orderby item.Point descending
                                                       where item.Point >= points
                                                       select new
                                                       {
                                                           item.Subject,
                                                           item.Point,
                                                           item.No,
                                                           student.Fullname,
                                                           student.Sex
                                                       })
                                           }).ToList();

            foreach (var item in highPointStudentsForSubjects)
            {
                Console.WriteLine(item.Subject);
                foreach (var stuScore in item.HighPointStudent)
                {
                    Console.WriteLine(stuScore);
                }
            }
        }



        private static void Get_AveriagePointsForEachSubjectPerGender(IList<Student> students, IList<Score> scores, IList<string> subjects)
        {
            var averiageScores = (from subject in subjects
                                 join score in
                                 (from _score2 in
                                  (from _score1 in scores
                                   join _student in students on _score1.No equals _student.No
                                   select new
                                   {
                                       _score1.Subject,
                                       _score1.Point,
                                       _student.Sex
                                   })
                                  group _score2 by (_score2.Sex, _score2.Subject) into allScoresWithSex
                                  select new
                                  {
                                      allScoresWithSex.Key.Sex,
                                      allScoresWithSex.Key.Subject,
                                      SubjectScore = allScoresWithSex.Average(c => c.Point)
                                  }
                                 )
                                 on subject equals score.Subject into scoreWithSubject
                                 from score in scoreWithSubject.DefaultIfEmpty() // 左外连接 Subject有4种课程，但是 scoreWithSubject只有3种课程的成绩
                                 select new
                                 {
                                     Subject = subject,
                                     Sex = score?.Sex,//左外连接时， score可能为空
                                     Scores = score?.SubjectScore
                                 }).ToList();

            foreach (var item in averiageScores)
            {
                Console.WriteLine(item);
               // Console.WriteLine(item.Scores);
            }
        }

        private static IList<Student> PrepareStudentsData(int numberOfStudent)
        {
            IList<Student> students = new List<Student>();
            for (int i=1; i<=numberOfStudent; i++)
            {
                char sex = new Random().Next(0, 100) % 2 == 0 ? 'M' : 'F';
                Student stu = new Student()
                {
                    No = i,
                    Sex = sex,
                    Fullname = $"fullname-{i}-{sex}"
                };
                students.Add(stu);
            }

            return students;
        }
        private static IList<Score> PrepareScoresData(int numberOfStudent, IList<string> subjects)
        {
            IList<Score> scores = new List<Score>();
            
            for (int i=1; i<=numberOfStudent; i++)
            {
                foreach (string subject in subjects)
                {
                    scores.Add(new Score()
                    {
                        No = i,
                        Subject = subject,
                        Point = new Random().Next(70, 100)
                    });
                }
            }

            return scores;
        }
    }
}
