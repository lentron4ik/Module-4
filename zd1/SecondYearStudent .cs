using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace zd1
{
    public class SecondYearStudent : IStudent
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; } = new List<double>();

        public SecondYearStudent(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        // Реализация метода для вычисления среднего балла
        public double CalculateAverageGrade()
        {
            return Grades.Count > 0 ? Grades.Average() : 0;
        }

        // Реализация методa для получения информации о курсе
        public string GetCourseInfo()
        {
            return "Второй курс";
        }

        public override string ToString()
        {
            return $"{Name}, {GetCourseInfo()}";
        }
    }
}
