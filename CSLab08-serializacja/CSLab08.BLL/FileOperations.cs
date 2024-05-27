using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CSLab08.BLL
{
    public interface FileOperations
    {
        public static void SerializeToTxt(IList<Student> Students)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var student in Students)
            {
                sw.WriteLine($"[[Student]]\n[FirstName]\n{student.FirstName}\n[SurName]\n{student.LastName}\n[StudentNo]\n{student.StudentNo}" +
                    $"\n[Faculty]\n{student.Faculty}\n[[]]");
            }
            sw.Close();
        }
        public static void DeserializeFromTxt(IList<Student> Students)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                if (sr.ReadLine() != "[[]]")
                {
                    sr.ReadLine();
                    var imie = sr.ReadLine();
                    sr.ReadLine();
                    var nazwisko = sr.ReadLine();
                    sr.ReadLine();
                    var numer = sr.ReadLine();
                    sr.ReadLine();
                    var wydzial = sr.ReadLine();
                    Students.Add(new Student() { FirstName = imie, LastName = nazwisko, StudentNo = Int32.Parse(numer), Faculty = wydzial });
                }

            }
            sr.Close();
        }


    }
}
