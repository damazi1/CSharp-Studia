namespace lab04 {
    public class FinalGrade {
        public Subject Subject {get; set;}
        public DateTime Date {get;set;}
        public double Value {get;set;}
        public FinalGrade (Subject subject,double value,DateTime date) {
            Subject = subject;
            Value = value;
            Date = date;
        }
        public override string ToString()
        {
            return $"Ocena końcowa: {Subject.ToString()} \n" + 
            $"Data: {Date} / Ocena: {Value}";
        }
    }
}