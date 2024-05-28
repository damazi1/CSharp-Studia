using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09.DAL
{
    public class Student
    {
        [Key]
        // tryb generacji klucza glownego (identity) w tym przypadku wylaczony
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentNo { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Faculty { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<Grade> Grades { get; set; } // właściwość nawigacyjna
        public string AllGrades => Grades != null ? string.Join(", ", Grades) : "";
    }
}
