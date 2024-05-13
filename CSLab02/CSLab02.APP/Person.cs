namespace lab02 {
    public class Person {
        protected string _firstName;
        protected string _lastName;
        protected DateTime _dateOfBirth;

        public string FirstName {get {return _firstName;} set {_firstName=value;}}
        public string LastName {get {return _lastName;} set {_lastName=value;}}
        public DateTime DateOfBirth{get {return _dateOfBirth;}set {_dateOfBirth=value;}}
        public Person(){
            _firstName = "";
            _lastName = "";
            _dateOfBirth = new DateTime();
        }
        public Person(string firstName, string lastName, DateTime dateOfBirth){
            _firstName=firstName;
            _lastName=lastName;
            _dateOfBirth=dateOfBirth;
        }
        public override string ToString(){
            return $"Osoba: {_firstName} {_lastName} [{_dateOfBirth}]";
        }
        public virtual void Details(){
            Console.WriteLine(this.ToString()+'\n');
        }
    }
}