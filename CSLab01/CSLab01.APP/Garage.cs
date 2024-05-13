using System.Text;

namespace lab01
{
    internal class Garage
    {
        private Car[] _cars;
        private string _address;
        private int _carsCount = 0;
        private int _capacity;

        public string Address { get { return _address; } set { _address = value; } }
        public int Capacity
        {
            get { return _capacity; }
            set
            {
                _capacity = value;
                _cars = new Car[value];
            }
        }
        public Garage()
        {
            _cars = null;
            _address = "Nieznane";
            _capacity = 0;
        }
        public Garage(string address, int capacity)
        {
            _address = address;
            _capacity = capacity; if (_capacity > 0)
            {
                _cars = new Car[capacity];
            }
        }
        public void CarIn(Car car)
        {
            if (_carsCount < _capacity)
            {
                _cars[_carsCount] = car;
                _carsCount++;
                Console.WriteLine($"Zaparkowano ({car})");
            }
            else
                Console.WriteLine($"{this.ToString()} Jest pełen ");
        }
        public Car CarOut()
        {
            if (_carsCount == 0)
            {
                Car c = new Car();
                Console.WriteLine($"Garaż: ({this.ToString()}) Jest pusty");
                return c;
            }
            else
            {
                Car d = new Car(_cars[_carsCount - 1]);
                Console.WriteLine($"Wyparkowano ({d})");
                _cars[_carsCount - 1] = null;
                _carsCount--;
                return d;
            }
        }
        public override string ToString()
        {
            string str = $"Garaż: {_address}/{_carsCount}/{_capacity}zaparkowane samochody:";

            foreach (Car car in _cars)
            {
                if (car != null)
                    str += $"\n- {car.ToString()}";

            }

            return str;
        }

        public void Details()
        {
            Console.WriteLine(this.ToString());

        }
    }

}