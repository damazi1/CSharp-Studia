using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System;

namespace lab01
{
    internal class Person
    {
        private string[] _registrationNumbers;
        public static int MaxCarCount { get; set; } = 3;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int CarsCount { get; set; } = 0;
        public Person()
        {
            _registrationNumbers = new string[MaxCarCount];
            FirstName = "Nieznane";
            LastName = "Nieznane";
            Address = "Nieznane";
        }
        public Person(string firstName, string lastName, string address
            )
        {
            _registrationNumbers = new string[MaxCarCount];
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
        public Person(string firstName, string lastName, string address
            , Car[] cars)
        {
            _registrationNumbers = new string[MaxCarCount];
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            for (int i = 0; i < cars.Length; i++)
            {
                _registrationNumbers[i] = cars[i].RegistrationNumber;
                CarsCount++;
            }
        }
        public void AddCarRegistrationNumber(string registrationNumber)
        {
            if (CarsCount < MaxCarCount)
            {
                _registrationNumbers[CarsCount] = registrationNumber;
                CarsCount++;
            }
            else
                Console.WriteLine($"{this.ToString()}\nDodawanie Nieudane (Osi¹gniêto limit samochodów) ");

        }
        public void RemoveCarRegistrationNubmer(string registrationNumber)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_registrationNumbers[i] == registrationNumber)
                {
                    for(int j = i + 1; j < 3; j++)
                    {
                        _registrationNumbers[j-1]= _registrationNumbers[j];
                    }
                    _registrationNumbers[_registrationNumbers.Length-1]=null;
                    CarsCount--;
                    Console.WriteLine($"Pomyœlnie usuniêto samochód z tablic¹ rejestracyjn¹ {registrationNumber}");
                    return;
                }
            }
            Console.WriteLine($"Nie odnaleziono Samochodu o takim numerze Rejestacyjnym ({registrationNumber})");
        }
        public override string ToString()
        {
            string str = $"Osoba: {FirstName} {LastName}/{Address}/{CarsCount}/posiadane samochody:";
            foreach (string re in _registrationNumbers)
            {
                if (re != null)
                {
                    str += "\n- " + re;
                }
            }
            return str;
        }
        public void Details()
        {
            Console.WriteLine(this.ToString());
        }
    }
}