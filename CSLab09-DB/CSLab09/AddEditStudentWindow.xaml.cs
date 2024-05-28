using Lab09.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSLab09.WpfApp
{
    /// <summary>
    /// Interaction logic for AddEditStudentWindow.xaml
    /// </summary>

    public partial class AddEditStudentWindow : Window
    {
        private readonly ApplicationDbContext _dbContext;
        public Student Student { get; set; }
        public AddEditStudentWindow(ApplicationDbContext dbContext, Student student=null)
        {

            InitializeComponent();
            _dbContext= dbContext;
            if (student !=null)
            {
                TextBoxFaculty.Text = student.Faculty;
                TextBoxFirstName.Text = student.FirstName;
                TextBoxSurName.Text = student.SurName;
                TextBoxStudentNo.Text = student.StudentNo.ToString();
            }
            Student = student ?? new Student();
        }

        private void ButtonSaveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(TextBoxFirstName.Text, @"^\p{Lu}{1,12}\p{Ll}{1,12}$"))
            {
                {
                    MessageBox.Show("zle imie");
                    return;
                }
            }
            if (!Regex.IsMatch(TextBoxSurName.Text, @"^\p{L}{1,12}$"))
            {
                MessageBox.Show("Zle nazwisko");
                return;
            }
            if(!Regex.IsMatch(TextBoxFaculty.Text, @"^\p{L}{1,12}$"))
            {
                MessageBox.Show("Zle wydzial");
                return;
            }
            if(!Regex.IsMatch(TextBoxStudentNo.Text, @"^[0-9]{4,10}$"))
                {
                MessageBox.Show("Zly number");
                return;
            }
            if(!DatePickerDateOfBirth.SelectedDate.HasValue)
            {
                MessageBox.Show("Data");
                return;
            }

            Student.Faculty = TextBoxFaculty.Text;
            Student.FirstName = TextBoxFirstName.Text;
            Student.SurName = TextBoxSurName.Text;
            Student.StudentNo = int.Parse(TextBoxStudentNo.Text);
            Student.DateOfBirth = DatePickerDateOfBirth.SelectedDate.Value;

            if (!_dbContext.Students.Contains(Student)) // sprawdzenie czy encja istnieje w kontekscie
                _dbContext.Students.Add(Student); // dodanie encji do kontekstu
            else
                _dbContext.Students.Update(Student); // modyfikacja encji w kontekscie
            _dbContext.SaveChanges(); // wygenerowanie SQL oraz wykonanie go na bazie danych
            DialogResult = true;
        }

    }
}
