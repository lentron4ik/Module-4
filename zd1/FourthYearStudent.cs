using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    public class FourthYearStudent : IStudent
    {
        private string Name { get; }
        private List<double> Grades { get; }

        public FourthYearStudent(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        public double CalculateAverageGrade()
        {
            return Grades.Any() ? Grades.Average() : 0;
        }

        public string GetCourseInfo()
        {
            return "Четвертый курс";
        }

        public override string ToString()
        {
            return $"{Name} (4 курс)";
        }
    }
}
