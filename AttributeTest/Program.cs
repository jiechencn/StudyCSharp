using System;

namespace AttributeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Hello");

            JobAssignment job1 = new JobAssignment();
            job1.Title = "programmer";
            job1.Sex = 'M';
            job1.Age = 80;

            JobAssignment job2 = new JobAssignment()
            {
                Title = "boxer",
                Sex = 'F',
                Age = 90
            };

            IMyValidator<JobAssignment> v = new MyValidator<JobAssignment>();
            if (v.IsValid(job1))
            {
                Console.WriteLine("job1: fine");
            }
            else
            {
                Console.WriteLine("job1: ");
                foreach(string err in v.ValidatorResultMessages)
                {
                    Console.WriteLine("\t" + err);
                }
            }

            if (v.IsValid(job2))
            {
                Console.WriteLine("job2: fine");
            }
            else
            {
                Console.WriteLine("job2: ");
                foreach (string err in v.ValidatorResultMessages)
                {
                    Console.WriteLine("\t" + err);
                }
            }

            Console.WriteLine("--World");
        }
    }
}
