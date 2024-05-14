using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSLab08.BLL;

namespace CSLab08.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Student> Students { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Students = new List<Student>
            {
                new Student(){FirstName = "Jan", LastName="Kowalski", Faculty="WIMII", StudentNo=1010,
                    Grades = new List<Grade>{ new Grade() { Name = "PO", _Grade = 4.0 }, new Grade("IO", 3.5) } },
                new Student(){FirstName= "Michal", LastName="Nowak", Faculty="WIMII", StudentNo=1011},
                new Student(){FirstName= "Jacek", LastName="Makieta", Faculty="WIMII", StudentNo=1012},
            };
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "First Name", Binding = new Binding(path: "FirstName") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Last Name", Binding = new Binding(path: "LastName") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Faculty", Binding = new Binding(path: "Faculty") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Student No.", Binding = new Binding(path: "StudentNo") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Grade", Binding = new Binding(path: "Grades") { Converter = new GradeConverter() } });

            DataGridStudents.AutoGenerateColumns = false;
            DataGridStudents.ItemsSource = Students;
            DataGridStudents.IsReadOnly = true;
        }

        private void _AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow win = new AddStudentWindow();
            if (win.ShowDialog() == true)
            {
                Students.Add(win.Student);
                DataGridStudents.Items.Refresh();
            }

        }
        private void _RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridStudents.SelectedItem is Student studentToRemove)
            {
                Students.Remove(studentToRemove);
                DataGridStudents.Items.Refresh();
            }
        }

        private void _AddGrade_Click(object sender, RoutedEventArgs e)
        {
           EditStudentGrade win1 = new EditStudentGrade();
            if (DataGridStudents.SelectedItem is Student gradeToAdd)
            {
                if (win1.ShowDialog() == true)
                {
                    gradeToAdd.Grades.Add(win1.Grade);
                    DataGridStudents.Items.Refresh();
                }
            }
            
        }
    }
}