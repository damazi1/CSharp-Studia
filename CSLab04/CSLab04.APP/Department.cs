namespace lab04
{
    public class Department : IContainer , IDisplayable
    {
        public string Name { get; set; }
        public Person Dean { get; set; }
        public IList<OrganizationUnit> OrganizationUnits { get; set; } = new List<OrganizationUnit>();
        public IList<Subject> Subjects { get; set; } = new List<Subject>();
        public IList<Student> Students { get; set; } = new List<Student>();
        public Department(string name, Person dean, IList<Subject> subjects, IList<Student> students)
        {
            Name = name;
            Dean = dean;
            Subjects = subjects;
            Students = students;
        }
        public override string ToString()
        {
            string str = "";
            foreach (OrganizationUnit unit in OrganizationUnits)
            {
                str += unit.ToString() + '\n';
            }
            foreach (Subject subject in Subjects)
            {
                str += subject.ToString() + "\n";
            }
            foreach (Student student in Students)
            {
                str += student.ToString() + "\n";
            }

            return $"Wydzia³: {Name} / {Dean}" + str;
        }
    }

}