namespace lab04 {
    public class Student : Person , IContainer , IDisplayable{
        private int id; 
        public IList<FinalGrade> Grades {get;set;} = new List<FinalGrade>();
        public int Semester {get;set;}
        public int Group {get;set;}
        public int IndexId {get;set;}
        public string Specialization {get;set;}
        public double AverageGrade {
            get {
                double sum=0;
                foreach (FinalGrade finalGrade in Grades) {
                    sum +=finalGrade.Value;
                }
                return sum/Grades.Count;
            }
        }
        public Student(string firstName, string lastName, DateTime dateOfBirth, string specialization, int group, int semester = 0) : base(firstName,lastName,dateOfBirth){
            Semester=semester;
            Specialization=specialization;
            Group=group;
        }
        public override string ToString() {
            string str="";
            foreach (FinalGrade finalGrade in Grades) {
                    str +=finalGrade.ToString()+'\n';
                }
            return "Student :" + base.ToString()+ $"\n{Semester} / {Group} / {IndexId} / {Specialization} / {AverageGrade} \nOceny:\n"+str; 
        }
    }
}