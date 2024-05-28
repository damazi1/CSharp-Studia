using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09.DAL
{
    public class Grade
    {
        [Key] // Adnotacja klucza głównego.
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public double Value { get; set; }
        // Adnotacja klucza obcego, parametr name musi być zgodna z nazwą właściwości nawigacyjnej
        [ForeignKey("Student")]
        public int StudentNo { get; set; } // właściwość klucza obcego
        public Student Student { get; set; } //właściwość nawigacyjna
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
