using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttributeTest
{
    public class JobAssignment
    {
        public string Title { get; set; }

        public string Fullname { get; set; }
        
        [GenderAttribute(ErrorMessage = "femail is not allowed")]
        public char Sex { get; set; }


        [Range(18, 50, ErrorMessage = "you are too week to take this job")]
        public int Age { get; set; }
    }
}
