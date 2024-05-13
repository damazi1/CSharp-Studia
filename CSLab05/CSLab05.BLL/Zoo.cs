using System;
using System.Collections.Generic;
using Generic.Extensions;
using System.Linq;
using System.Text;
namespace Lab5.BLL
{
    public class Zoo : IContainer , IDisplayable
    {
        private string _Name;
        private IList<Employee> _Employees;
        private IList<Cage> _Cages;
        private IList<Animal> _Animals;
    
        public string Name { get { return _Name; }set { _Name = value; } }
        public IList<Employee> Employees { get { return _Employees; } set { _Employees = value; } }
        public IList<Cage> Cages { get { return _Cages; } set { _Cages = value; } }
        public IList<Animal> Animals { get { return _Animals; } set { _Animals = value; } }

        public Zoo()
        {
            _Name = "";
            _Employees= new List<Employee>();
            _Cages= new List<Cage>();
            _Animals= new List<Animal>();
        }
        public Zoo(string name,IList<Employee> employees,IList<Cage> cages,IList<Animal> animals)
        {
            _Name = name;
            _Employees = employees;
            _Cages = cages;
            _Animals = animals;
        }
        public Cage BuildCage(int capacity,bool cleanUp)
        {
            Cage c1=new Cage(capacity, cleanUp, new List<Animal>());
            _Cages.Add(c1);
            return c1;
        }
        public void ExpandCage(Cage cage,int inc_capacity)
        {
            foreach (Cage cg in _Cages)
            {
                if (cg == cage)
                {
                    cage.Capacity += inc_capacity;
                    return;
                }
            }
        }
        public Employee HireEmployee(string firstName,string lastName,DateTime dateOfBirth)
        {
            Employee emp = new Employee(firstName, lastName, dateOfBirth, DateTime.Now, null);
            return emp;
        }
    }
}