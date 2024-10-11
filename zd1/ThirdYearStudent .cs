using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    public class ThirdYearStudent : IStudent
    {
        private string Name { get; }
        private List<double> Grades { get; set; }

        public ThirdYearStudent(string name, List<double> grades)
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
            return "Третий курс";
        }

        public override string ToString()
        {
            return $"{Name} (3 курс)";
        }

        
    }
}
