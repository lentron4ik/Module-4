using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2
{
    public class ElectronicProduct : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }  // Фиксированная цена за единицу
        public int Stock { get; set; }     // Количество на складе

        public ElectronicProduct(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        // Метод для получения стоимости товара (цена за единицу)
        public double GetPrice()
        {
            return Price;
        }

        // Метод для получения остатка на складе
        public int GetStock()
        {
            return Stock;
        }
    }
}
