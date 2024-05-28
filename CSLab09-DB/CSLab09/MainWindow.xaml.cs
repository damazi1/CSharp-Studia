using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSLab09.WpfApp;
using Lab09.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CSLab08.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationDbContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
            var connString = Application.Current.Resources["connString"] as string; // pobranie cs z resource
                                                                                    // stworzenie obiektu kontekstu
            _dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connString!)// okreslenie providera bazy danych
            .Options);
            SetGrid(DataGridStudents, _dbContext.Students
                                                // ladowanie danych powiazanych przy pomocy Eager Loading.
                                                .Include(stud => stud.Grades)
                                                .ToList());
        }
        private void ButtonAddEditStudentWindowShow_Click(object sender, RoutedEventArgs e)
        {
            AddEditStudentWindow addStudentWindow;
            if (DataGridStudents.SelectedItem != null && DataGridStudents.SelectedItem is Student student)
                addStudentWindow = new AddEditStudentWindow(_dbContext, student);
            else
                addStudentWindow = new AddEditStudentWindow(_dbContext);
            if (addStudentWindow.ShowDialog() == true)
                SetGrid(DataGridStudents, _dbContext.Students
                .Include(stud => stud.Grades)
                .ToList());
        }
        private void ButtonRemoveStudentWindowShow_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridStudents.SelectedItem is Student studentToRemove)
            {
                _dbContext.Students.Remove(studentToRemove);
                _dbContext.SaveChanges();
                SetGrid(DataGridStudents, _dbContext.Students
                .Include(stud => stud.Grades)
                .ToList());
            }
        }
        private void DatePickerFilterGrid_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePickerFilterGrid.SelectedDate.HasValue)
            {
                DataGridStudents.ItemsSource = _dbContext.Students
                .Include(stud => stud.Grades)
                .Where(s => s.DateOfBirth == DatePickerFilterGrid.SelectedDate.Value // filtrowanie danych
                ).ToList();
            }
            else
                SetGrid(DataGridStudents, _dbContext.Students
                .Include(stud => stud.Grades)
                .ToList());
        }
        private static void SetGrid<T>(DataGrid dataGrid, IList<T> list) where T : new()
        {
            dataGrid.Columns.Clear();
            Type type = typeof(T);
            foreach (var prop in type.GetProperties())
                dataGrid.Columns.Add(new DataGridTextColumn() { Header = prop.Name, Binding = new Binding(prop.Name) });
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }

        private void _RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            Student? student = DataGridStudents.SelectedItem as Student;
            int? id = student?.StudentNo;
            if (id == null) return;

            Student? s = _dbContext?.Students?.SingleOrDefault(s => s.StudentNo == id);
            if (s == null) return;
            _dbContext?.Students?.Remove(s);
            if (_dbContext?.SaveChanges() > 0)
            {
                DataGridStudents.ItemsSource = _dbContext?.Students?.Include("Grades").ToList();
                DataGridStudents.Items.Refresh();
            }
        }

        private void _AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(_Grade.Text, @"^[0-6]*\,[05]$"))
            {
                MessageBox.Show("Zla Ocena");
                return;
            }
            if (!Regex.IsMatch(_Subject.Text, @"^\p{L}{1,12}$"))
            {
                MessageBox.Show("Zly Przedmiot");
                return;
            }
            if (!DatePickerFilterGrid.SelectedDate.HasValue)
            {
                MessageBox.Show("Data");
                return;
            }
            Student? student = DataGridStudents.SelectedItem as Student;
            int? id = student?.StudentNo;
            if (id == null) return;
                Grade o = new()
                {
                    Value = double.Parse(_Grade.Text),
                    Date = DatePickerFilterGrid.SelectedDate.Value,
                    Subject = _Subject.Text,
                    Student = student
                };
            if (o == null) return;
            _dbContext?.Grades?.Add(o);

            if (_dbContext?.SaveChanges() > 0)
            {
                DataGridStudents.ItemsSource = _dbContext?.Students?.Include("Grades").ToList();
                DataGridStudents.Items.Refresh();
            }
        }
    }
}