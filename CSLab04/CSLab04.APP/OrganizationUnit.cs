using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class OrganizationUnit : IContainer
    {
        public string Name { get; set; }
        public string Address { get; set; } 
        public IList<Lecturer> Lectures { get; set; }
        public OrganizationUnit(string name, string address,IList<Lecturer> lecturers)
        {
            Name = name;
            Address = address;
            Lectures = lecturers;
        }
        public override string ToString()
        {
            string str = "";
            foreach (Lecturer l in Lectures) { str += l.ToString()+'\n'; }
            return $"Organizacja: {Name} / {Address} / Wykładowcy : \n" + str;
        }
    }
}
