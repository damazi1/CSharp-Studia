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
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using CSLab08.BLL;
using Microsoft.Win32;

namespace CSLab08.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, FileOperations
    {
        public IList<Student> Students { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Students = new List<Student>
            {
                new Student(){FirstName = "Jan", LastName="Kowalski", Faculty="WIMII", StudentNo=1010},
                new Student(){FirstName= "Michal", LastName="Nowak", Faculty="WIMII", StudentNo=1011},
                new Student(){FirstName= "Jacek", LastName="Makieta", Faculty="WIMII", StudentNo=1012},
            };
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "First Name", Binding = new Binding(path: "FirstName") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Last Name", Binding = new Binding(path: "LastName") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Faculty", Binding = new Binding(path: "Faculty") });
            DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Student No.", Binding = new Binding(path: "StudentNo") });
            //DataGridStudents.Columns.Add(item: new DataGridTextColumn() { Header = "Grade", Binding = new Binding(path: "Grades") { Converter = new GradeConverter() } });

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
                    //gradeToAdd.Grades.Add(win1.Grade);
                    DataGridStudents.Items.Refresh();
                }
            }
            
        }

        private void _SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            FileOperations.SerializeToTxt(Students);
        }

        private void _LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            FileOperations.DeserializeFromTxt(Students);
            DataGridStudents.Items.Refresh();
        }

        private async void _SaveReflection_Click(object sender, RoutedEventArgs e)
        {
            using (var streamWriter = new StreamWriter("data1.txt"))
            {
                foreach (var student in Students) 
                {
                    await streamWriter.Save(student);
                }
                
            }
            
        }
        private IEnumerator<Student> studentEnumerator;
        private async void _LoadReflection_Click(object sender, RoutedEventArgs e)
        {

            if (studentEnumerator == null)
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    var streamReader = new StreamReader(openFileDialog.FileName);
                    var streamEnumerable = new StreamEnumerable<Student>(streamReader);
                    studentEnumerator = streamEnumerable.GetEnumerator();
                }
            }

            if (studentEnumerator != null && studentEnumerator.MoveNext())
            {
                Students.Add(studentEnumerator.Current);
                DataGridStudents.ItemsSource = null; // To trigger refresh
                DataGridStudents.ItemsSource = Students;
            }
            else
            {
                MessageBox.Show("No more students to load.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                studentEnumerator?.Dispose();
                studentEnumerator = null;
            }
        }
        private void _SaveToXML_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                using var fileStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                xmlSerializer.Serialize(fileStream, Students);
            }
        }

            private void _LoadFromXML_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    using var fileStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
                    var xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    if (xmlSerializer.Deserialize(fileStream) is List<Student> students && students.Count > 0)
                    {
                        Students = students;
                        DataGridStudents.ItemsSource = Students;
                        DataGridStudents.Items.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Loading XML file: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void _SaveToJSON_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter="JSON files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                string jsonStr = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, jsonStr);
            }
        }

        private async void _LoadFromJSON_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            if(openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonStr = await File.ReadAllTextAsync(openFileDialog.FileName);
                    Students = JsonSerializer.Deserialize<List<Student>>(jsonStr);
                    DataGridStudents.ItemsSource = Students;
                    DataGridStudents.Items.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Loading json file: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}