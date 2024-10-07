using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2
{
    public class FoodProduct : IProduct
    {
        public string Name { get; set; }
        public double PricePerKg { get; set; }  // Цена за килограмм
        public double Weight { get; set; }      // Вес в килограммах
        public int Stock { get; set; }          // Количество на складе

        public FoodProduct(string name, double pricePerKg, double weight, int stock)
        {
            Name = name;
            PricePerKg = pricePerKg;
            Weight = weight;
            Stock = stock;
        }

        // Метод для получения стоимости товара (цена за кг * вес)
        public double GetPrice()
        {
            return PricePerKg * Weight;
        }

        // Метод для получения остатка на складе
        public int GetStock()
        {
            return Stock;
        }
    }
}
