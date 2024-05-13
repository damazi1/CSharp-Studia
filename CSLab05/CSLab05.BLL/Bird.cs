using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5.BLL
{
    public class Bird : Animal
    {
        private double _Wingspan;
        private int _Endurance;

        public double Wingspan { get { return _Wingspan; } set {  _Wingspan = value; } }
        public int Endurance { get { return _Endurance; } set { _Endurance = value; } }
        public Bird(string species,int count, string foodType, string origin,double wingspan,int endurance) : base(species,count, foodType, origin)
        {
            _Wingspan = wingspan;
            _Endurance = endurance;
        }
        public void Fly()
        {
            Console.WriteLine($"Czas lotu ptaka: {_Wingspan * _Endurance}");
            return;
        }

        public override string ToString()
        {
            return $"Bird: {_Wingspan} / {_Endurance} / " + base.ToString();
        }

    }
}