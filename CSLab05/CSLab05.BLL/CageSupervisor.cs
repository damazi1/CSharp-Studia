using System;
using System.Collections.Generic;
using Generic.Extensions;
using System.Linq;
using System.Text;

namespace Lab5.BLL
{
    public class CageSupervisor : Employee , IContainer
    {
        public CageSupervisor(string firstName, string lastName, DateTime dateOfBirth, DateTime dateOfEmployment, IList<Cage> cages) : base(firstName, lastName, dateOfBirth, dateOfEmployment, cages) { }
    }
}