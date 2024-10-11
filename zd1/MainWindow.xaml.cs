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
            // Получаем данные из полей
            string name = StudentNameTextBox.Text;
            string course = ((ComboBoxItem)CourseComboBox.SelectedItem)?.Content.ToString();
            var grades = ParseGrades(GradesTextBox.Text);

            IStudent student = null;

            // Создаем экземпляры классов студентов на основе курса
            if (course == "Первый курс")
            {
                student = new FirstYearStudent(name, grades);
            }
            else if (course == "Второй курс")
            {
                student = new SecondYearStudent(name, grades);
            }
            else if (course == "Третий курс")
            {
                student = new ThirdYearStudent(name, grades);
            }
            else if (course == "Четвертый курс")
            {
                student = new FourthYearStudent(name, grades);
            }

            if (student != null)
            {
                // Добавляем студента в список
                students.Add(student);

                // Создаем экземпляр StudentViewModel
                var studentViewModel = new StudentViewModel
                {
                    Name = name,
                    Course = course,
                    Grades = string.Join(", ", grades),
                    AverageGrade = student.CalculateAverageGrade().ToString("F2")
                };

                // Добавляем объект StudentViewModel в ListView
                StudentListView.Items.Add(studentViewModel);

                // Очищаем поля
                ClearInputFields();
            }
        }

        // Метод для парсинга оценок из строки
        private List<double> ParseGrades(string gradesText)
        {
            return gradesText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(g => double.TryParse(g.Trim(), out var grade) ? grade : 0)
                             .ToList();
        }

        // Очистка полей после добавления студента
        private void ClearInputFields()
        {
            StudentNameTextBox.Clear();
            GradesTextBox.Clear();
            CourseComboBox.SelectedIndex = -1;
        }

        private void DeleteStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StudentListView.SelectedIndex >= 0)
            {
                // Удаляем студента из списка и ListBox
                IStudent selectedStudent = students[StudentListView.SelectedIndex];
                students.Remove(selectedStudent);
                StudentListView.Items.RemoveAt(StudentListView.SelectedIndex);
            }
        }

    }
}
