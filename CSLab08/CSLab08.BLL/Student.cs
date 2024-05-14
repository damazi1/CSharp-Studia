using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab08.BLL
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentNo { get; set; }
        public string Faculty { get; set; }

        public Student() { }
        public Student(string firstName, string lastName, int studentNo, string faculty)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNo = studentNo;
            Faculty = faculty;
        }
    }
}
