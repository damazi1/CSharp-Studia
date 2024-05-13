using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5.BLL
{
    public abstract class Animal
    {
        private string _Species;
        private string _FoodType;
        private int _SpaceTaken;
        private string _Origin;

        public string Species { get { return _Species; }set {  _Species = value; } }
        public int SpaceTaken { get { return _SpaceTaken; } set { _SpaceTaken = value; } }        
        public string FoodType { get { return _FoodType;} set { _FoodType = value;} }
        public string Origin { get { return _Origin; } set { _Origin = value; } }

        public Animal(string species,int spaceTaken, string foodType,string origin)
        {
            _Species = species;
            _SpaceTaken = spaceTaken;
            _FoodType = foodType;
            _Origin = origin;
        }
        public override string ToString()
        {
            return $"{_Species} / {_SpaceTaken} / {_FoodType} / {_Origin}  ";
        }
    }
}