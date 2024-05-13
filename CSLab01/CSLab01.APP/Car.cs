namespace lab01
{
    internal class Car
    {
        private string _brand ;
        private string _model ;
        private int _doorCount ;
        private float _engineVolume ; 
        private double _avgConsump ;
        private string _registrationNumber;
        private static int _carCount = 0;

        public string Brand { get {return _brand;} set {_brand=value; }}
        public string Model { get {return _model;} set{_model=value;} }
        public int DoorCount { get{return _doorCount;} set{_doorCount=value;} }
        public float EngineVolume { get{return _engineVolume;} set{_engineVolume=value;} }
        public double AvgConsump {  get{return _avgConsump;} set{_avgConsump=value;} }
        public string RegistrationNumber{get{return _registrationNumber;} set{_registrationNumber=value;}}
        public Car()
        {
            _brand = "Nieznany";
            _model = "Nieznany";
            _doorCount = 0;
            _engineVolume = 0;
            _avgConsump = 0.0;
            _registrationNumber="Nieznany";
            _carCount++;
        }
        public Car(string brand, string model, int doorCount, float engineVolume, double avgConsump,string registrationNumber)
        {
            _brand = brand;
            _model = model;
            _doorCount = doorCount;
            _engineVolume = engineVolume;
            _avgConsump = avgConsump;
            _registrationNumber=registrationNumber;
            _carCount++;
        }
        public Car(Car car)
        {
            _brand=car._brand;
            _model=car._model;
            _doorCount = car._doorCount;
            _engineVolume = car._engineVolume;
            _avgConsump=car._avgConsump;
            _registrationNumber=car._registrationNumber;
            _carCount++;
        }
        public override string ToString(){
            return $"Samochód: {_brand}/{_model}/{_doorCount}/{_engineVolume}/{_avgConsump}/{_registrationNumber}";
        }
        public double CalculateConsump(double dystans)
        {
            return (_avgConsump * dystans) / 100;
        }
        public double CalculateCost(double dystans,double cost) {
            return CalculateConsump(dystans) * cost;
        }
        public void Details()
        {
            Console.WriteLine(this.ToString());
        }
        public static void DisplayCarCount()
        {
            Console.WriteLine($"Ilosc samochodow: {Car._carCount}");
        }
    }
}
