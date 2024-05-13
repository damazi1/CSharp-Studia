using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5.BLL
{
    public class Mammal : Animal
    {
        private string _NaturalEnvironment;
        public string NaturalEnvironment { get { return _NaturalEnvironment; } set { _NaturalEnvironment = value; } }

        public Mammal (string species,int count, string foodType, string origin, string naturalEnvironment) : base(species,count,foodType,origin)
        {
            _NaturalEnvironment = naturalEnvironment;
        }
        public override string ToString()
        {
            return $"Mammal: {_NaturalEnvironment} / " + base.ToString();
        }
    }
}