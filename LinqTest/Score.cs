using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Score
    {
        public int ClassID { get; }
        public string StudentName { get; }
        public double Point { get; }
        public Score(int classID, string studentName, double point)
        {
            ClassID = classID;
            StudentName = studentName;
            Point = point;
        }
    }
}
