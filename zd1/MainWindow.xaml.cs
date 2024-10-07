using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zd1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xаml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IStudent> students = new List<IStudent>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string name = StudentNameTextBox.Text;
            string course = ((ComboBoxItem)CourseComboBox.SelectedItem)?.Content.ToString();
            var grades = ParseGrades(GradesTextBox.Text);

            IStudent student = null;

            if (course == "Первый курс")
            {
                student = new FirstYearStudent(name, grades);
            }
            else if (course == "Второй курс")
            {
                student = new SecondYearStudent(name, grades);
            }

            if (student != null)
            {
                students.Add(student);
                StudentListBox.Items.Add(student.ToString());
                ClearInputFields();
            }
        }

        private List<double> ParseGrades(string gradesText)
        {
            return gradesText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(g => double.TryParse(g.Trim(), out var grade) ? grade : 0)
                             .ToList();
        }

        private void ClearInputFields()
        {
            StudentNameTextBox.Clear();
            GradesTextBox.Clear();
            CourseComboBox.SelectedIndex = -1;
        }

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentListBox.SelectedIndex >= 0)
            {
                var selectedStudent = students[StudentListBox.SelectedIndex];
                string info = $"Имя: {selectedStudent.ToString()}\n" +
                              $"Средний балл: {selectedStudent.CalculateAverageGrade():F2}";
                StudentInfoTextBlock.Text = info;
            }
        }
    }
}