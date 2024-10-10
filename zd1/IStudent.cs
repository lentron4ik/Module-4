using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    public interface IStudent
    {
        double CalculateAverageGrade(); // Метод для вычисления среднего баллa
        string GetCourseInfo();        // Метод для получения информации о курсе
    }
}