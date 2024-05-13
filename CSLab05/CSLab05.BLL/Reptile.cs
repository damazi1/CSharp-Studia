using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5.BLL
{
    public class Reptile : Animal
    {
        private bool _Venomous;
        public bool Venomous { get { return _Venomous; }set { _Venomous = value; } }
        public Reptile(string species, int count, string foodType, string origin, bool veonomous) : base(species, count, foodType, origin)
        {
            _Venomous = veonomous;
        }
        public override string ToString()
        {
            return $"Reptile: {_Venomous} / " + base.ToString();
        }
    }
}