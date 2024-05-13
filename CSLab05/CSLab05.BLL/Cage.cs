using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generic.Extensions;


namespace Lab5.BLL
{
    public class Cage : IContainer
    {
        private int _Capacity;
        private bool _CleanUp;
        private IList<Animal> _Animals;

        public int Capacity { get { return _Capacity; }set { _Capacity = value; } }
        public bool CleanUp { get { return _CleanUp; }set { _CleanUp = value; } }
        public IList<Animal> Animals { get { return _Animals; }set { _Animals = value; } }
        
        public Cage(int capacity,bool cleanUp, IList<Animal> animals)
        {
            _Capacity = capacity;
            _CleanUp = cleanUp;
            _Animals = animals;
        }
        public override string ToString()
        {
            string str = "";
            if(_Animals != null)
            {
                foreach (Animal animal in _Animals)
                {
                    str += animal.ToString() + '\n';
                }
            }
            return $"Klatka: {_Capacity} / {_CleanUp} / Zwierzeta:\n" + str;
        }
    }
}