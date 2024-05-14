using CSLab08.BLL;
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

namespace CSLab08.WpfApp
{
    /// <summary>
    /// Interaction logic for EditStudentGrade.xaml
    /// </summary>
    public partial class EditStudentGrade : Window
    {
        public Grade Grade { get; set; }
        public EditStudentGrade(Grade grade = null)
        {
            InitializeComponent();
            if (grade != null)
            {
                TextBoxSubject.Text = grade.Name;
                TextBoxGrade.Text = grade._Grade.ToString();
            }
            Grade = grade ?? new Grade();
        }

        private void _AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(input: TextBoxSubject.Text, pattern: @"^\p{L}{1,12}$") ||
                !Regex.IsMatch(input: TextBoxGrade.Text, pattern: @"^[0-6]*\,[05]$"))
            {
                MessageBox.Show(messageBoxText: "Invalid input data");
                return;
            }
            Grade.Name = TextBoxSubject.Text;
            if (!double.TryParse(TextBoxGrade.Text, out double GradeValue))
                MessageBox.Show(messageBoxText: "Grade is not a number");
            Grade._Grade= GradeValue;
            DialogResult = true;
        }
    }
}
