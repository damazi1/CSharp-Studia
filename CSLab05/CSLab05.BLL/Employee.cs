using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5.BLL
{
    public class Employee
    {
        private string _FirstName;
        private string _LastName;
        private DateTime _DateOfBirth;
        private DateTime _DateOfEmployment;
        private IList<Cage> _Cages;

        public string FirstName { get { return _FirstName; }set { _FirstName = value; } }
        public string LastName { get { return _LastName; }set { _LastName = value; } }
        public DateTime DateOfBirth { get { return _DateOfBirth; }set { _DateOfBirth =  value; } }
        public DateTime DateOfEmployment { get { return _DateOfEmployment; }set { _DateOfEmployment = value; } }
        public IList<Cage> Cages { get { return _Cages; } set { _Cages = value; } }
        
        public Employee(string firstName,string lastName, DateTime dateOfBirth, DateTime dateOfEmployment, IList<Cage> cages)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _DateOfBirth = dateOfBirth;
            _DateOfEmployment = dateOfEmployment;
            _Cages = cages;

        }
    }
}