using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab02{

    public class Student : Person{
        private int _year;
        private int _group;
        private int _indexid;
        private IList<Grade> _grades;
        public int Year {get {return _year;}set {_year= value;}}
        public int Group {get {return _group;}set {_group=value;}}
        public int Indexid {get {return _indexid;}set {_indexid=value;}}
        public IList<Grade> Grades { get { return _grades; } } 
        public Student():base(){
            _year=0;
            _group=0;
            _indexid=0;
            _grades=new List<Grade>();
        }
        public Student(string firstName,string lastName,DateTime dateOfBirth,int year,int group,int indexid):base(firstName,lastName,dateOfBirth){
            _year=year;
            _group=group;
            _indexid=indexid;
            _grades=new List<Grade>();
        }

        public void AddGrade(string subjectName, double value, DateTime date)
        {
            _grades.Add(new Grade(subjectName, value, date));
        }
        public void AddGrade(Grade grade)
        {
            _grades.Add(grade);
        }
        public void DisplayGrades()
        {
            foreach (Grade grade in _grades)
            {
                Console.WriteLine($"- Ocena: {grade.ToString()}");
            }
        }
        public void DisplayGrades(string subjectName)
        {
            foreach(Grade grade in _grades)
            {
                if(grade.SubjectName == subjectName)
                {
                    Console.WriteLine($"- Ocena: {grade.ToString()}");
                }
            }
        }

        public void DeleteGrade(string subjectName,double value, DateTime date)
        {


            foreach (Grade grade in _grades)
            {
                if (grade.SubjectName == subjectName)
                {
                    if (grade.Value == value)
                    {
                        if (grade.Date == date)
                        {
                            _grades.Remove(grade);
                            break;
                        }
                    }
                }
            }
        }

        public void DeleteGrade(Grade grade)
        {
            _grades.Remove(grade);
        }
        public void DeleteGrades(string subjectName)
        {
            for (int i = _grades.Count-1; i >= 0; i--)
            {
                if (_grades[i].SubjectName == subjectName)
                {
                    _grades.RemoveAt(i);
                }
            }

        }
        public void DeleteGrades()
        {
            for (int i=_grades.Count-1; i>=0;i--)
            {
                _grades.Remove(_grades[i]);
            }
        }

        public override string ToString()//
        {
            string str = base.ToString() + "\n" + $"rok: {_year} | grupa: {_group} | indexid: {_indexid} | Oceny: \n";
            foreach (Grade grade in _grades)
            {
                str += "-" + grade.ToString()+'\n';
            }
            return str;

        }
        
    }
}