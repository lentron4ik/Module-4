using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace zd1
{
    public class FirstYearStudent : IStudent
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; } = new List<double>();

        public FirstYearStudent(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        // Реализация метода для вычисления среднего бaлла
        public double CalculateAverageGrade()
        {
            return Grades.Count > 0 ? Grades.Average() : 0;
        }

        // Реализация метода для получения информации о курсе
        public string GetCourseInfo()
        {
            return "Первый курс";
        }

        public override string ToString()
        {
            return $"{Name}, {GetCourseInfo()}";
        }
    }
}