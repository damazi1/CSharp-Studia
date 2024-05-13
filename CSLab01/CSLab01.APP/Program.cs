namespace lab01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kod testowy do zadania 1");
            Car car1 = new Car();
            car1.Details();
            car1.Brand = "Fiat";
            car1.Model = "126p";
            car1.DoorCount = 2;
            car1.EngineVolume = 650;
            car1.AvgConsump = 6.0;
            car1.RegistrationNumber = "KR12345";
            car1.Details();
            Car car2 = new Car("Syrena", "105", 2, 0.8f, 7.6d, "WE1234");
            car2.Details();
            Console.WriteLine(car1);
            double routeConsumption = car2.CalculateConsump(500);
            Console.WriteLine($"Route consumption (Zużycie Paliwa): {routeConsumption} l");
            double routeCost = car2.CalculateCost(500, 5);
            Console.WriteLine($"Route cost (Koszt paliwa): {routeCost}");
            Car.DisplayCarCount();
            Console.WriteLine("\r\n=========================================\r\n");
            Console.WriteLine("Kod testowy do zadania 2");
            Garage garage1 = new Garage();
            garage1.Address = "ul. Garażowa 1";
            garage1.Capacity = 1;
            Garage garage2 = new Garage("ul. Garażowa 2", 2);
            garage1.CarIn(car1);
            garage1.Details();
            garage1.CarIn(car2);
            garage2.CarIn(car2);
            var movedCar = garage1.CarOut();
            garage2.CarIn(movedCar);
            garage2.Details();
            garage1.Details();
            garage2.CarOut();
            garage2.Details();
            garage2.CarOut();
            garage2.CarOut();
            garage2.Details();
            garage1.Details();
            Console.WriteLine("\r\n=========================================\r\n");
            Console.WriteLine("Kod testowy do zadania 2 (Dodatkowy)");
            Garage garage3 = new Garage("ul. Garażowa 3",2);
            garage3.CarIn(car1);
            garage3.CarIn(car2);
            garage3.CarIn(car2);
            garage3.CarOut();
            garage3.CarOut();
            garage3.CarOut();
            garage3.CarIn(car1);
            garage3.CarIn(car2);
            garage3.CarIn(car2);
            garage3.CarOut();
            garage3.CarOut();
            garage3.CarOut();
            garage1.Details();
            Console.WriteLine("\r\n=========================================\r\n");
            Console.WriteLine("Kod testowy do zadania 3");
            Person person1 = new Person("Jan","Kowal","ul. Kwaitowa 1, Częstochowa");
            person1.Details();
            Person person2 = new Person("Maja", "Nowak", "ul. Wesoła 5, Częstochowa");
            person2.AddCarRegistrationNumber(car1.RegistrationNumber);
            person2.AddCarRegistrationNumber(car2.RegistrationNumber);
            person2.AddCarRegistrationNumber("WE5432");
            person2.AddCarRegistrationNumber("WE5432");
            person2.Details();
            person2.RemoveCarRegistrationNubmer(car1.RegistrationNumber);
            person2.Details();
            person2.RemoveCarRegistrationNubmer(car2.RegistrationNumber);
            person2.RemoveCarRegistrationNubmer("WE5432");
            person2.RemoveCarRegistrationNubmer("CD8888");
            person2.Details();

            Console.WriteLine("\nNaciśnji dowolny klawisz aby zakończyć");
            Console.ReadKey();
        }
    }
}