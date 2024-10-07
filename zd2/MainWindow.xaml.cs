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

namespace zd2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IProduct> products = new List<IProduct>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик нажатия кнопки "Добавить товар"
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Чтение данных с текстовых полей
            string name = ProductNameTextBox.Text;
            if (!double.TryParse(ProductPriceTextBox.Text, out double price) || !int.TryParse(ProductQuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для цены и количества.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверяем, выбран ли элемент в ComboBox
            if (ProductTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Определяем тип товара
            IProduct newProduct = null;
            if (ProductTypeComboBox.SelectedItem is ComboBoxItem selectedType)
            {
                if (selectedType.Content.ToString() == "Продукты питания")
                {
                    // Если это продукт питания, читаем вес
                    if (!double.TryParse(ProductWeightTextBox.Text, out double weight))
                    {
                        MessageBox.Show("Пожалуйста, введите корректное значение для веса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    newProduct = new FoodProduct(name, price, weight, quantity);
                }
                else if (selectedType.Content.ToString() == "Бытовая техника")
                {
                    newProduct = new ElectronicProduct(name, price, quantity);
                }

                // Добавляем товар в список
                if (newProduct != null)
                {
                    products.Add(newProduct);
                    ProductListBox.Items.Add(newProduct.Name);

                    // Очищаем поля ввода
                    ProductNameTextBox.Clear();
                    ProductPriceTextBox.Clear();
                    ProductWeightTextBox.Clear();
                    ProductQuantityTextBox.Clear();
                }
            }
        }

        // Обработчик выбора товара в списке
        private void ProductListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductListBox.SelectedIndex >= 0)
            {
                // Получаем выбранный товар по индексу
                var selectedProduct = products[ProductListBox.SelectedIndex];

                // Отображаем информацию о выбранном товаре
                ProductDetailsTextBlock.Text = $"Название: {selectedProduct.Name}\n" +
                                               $"Цена: {selectedProduct.GetPrice():0.00}\n" +
                                               $"Количество на складе: {selectedProduct.GetStock()}";
            }
        }
    }
}