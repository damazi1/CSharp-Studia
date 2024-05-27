using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab08.BLL
{
    public class Grade
    {
        public string Name { get; set; }
        public double _Grade {  get; set; }
        public Grade() { }
        public Grade(string name, double grade) 
        {
            Name = name;
            _Grade = grade;
        }
    }
}
