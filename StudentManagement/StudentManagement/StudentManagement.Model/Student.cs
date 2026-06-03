using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.StudentManagement.Model
{
    public class Student
    {
        public string Name { get; set; }
        public int Rollno { get; set; }
        public string Department { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}