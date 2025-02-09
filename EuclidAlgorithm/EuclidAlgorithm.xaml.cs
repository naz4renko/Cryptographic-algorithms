using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace InfoSecurity.EuclidAlgorithm
{
    /// <summary>
    /// Логика взаимодействия для EuclidAlgorithm.xaml
    /// </summary>
    public partial class EuclidAlgorithm : UserControl
    {
        public static int[] GetRandomNumbers(int numDigits)
        {
            int[] numbers = new int[2];

            int minValue = (int)Math.Pow(10, numDigits - 1);
            int maxValue = (int)Math.Pow(10, numDigits) - 1;

            int num1 = new Random().Next(minValue, maxValue + 1);
            int num2 = new Random().Next(minValue, maxValue + 1);

            numbers[0] = num1;
            numbers[1] = num2;
            return numbers;
        }

        public EuclidAlgorithm()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {

            if (NumberA != null && NumberB != null) 
            {

                // Обычный алгоритм НОД
                int a = Convert.ToInt32(NumberA.Text);
                int b = Convert.ToInt32(NumberB.Text);

                int nod = MainFunction.FindNOD(a, b);

                NOD1.Text = Convert.ToString(nod);

                // Расширенный алгоритм
                int[] advNOD = MainFunction.AdvancedNOD(a, b);

                NOD2.Text = $"u1 = {advNOD[0]}, u2 = {advNOD[1]}, u3 = {advNOD[2]}";


                // Обратное число

                if (advNOD[2] == 1)
                {
                    NOD3.Text = $"u1 ( a^(-1) ) = {advNOD[0]}, u2 = {advNOD[1]}, u3 = {advNOD[2]}";
                }
                else
                {
                    NOD3.Text = "Нет такого числа";
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NumberA.Text = null;
            NumberB.Text = null;
            NOD1.Text= null;
            NOD2.Text = null;
            NOD3.Text = null;
            TestDG.ItemsSource = null;
        }

        private void GoTest_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            // Создание DataTable
            DataTable dataTable = new DataTable();

            // Добавление столбцов в DataTable
            dataTable.Columns.Add("Число 1");
            dataTable.Columns.Add("Число 2");
            dataTable.Columns.Add("НОД");
            dataTable.Columns.Add("u1");
            dataTable.Columns.Add("u2");
            dataTable.Columns.Add("u3");
            dataTable.Columns.Add("обратное число");
            dataTable.Columns.Add("Время");


            for (int i = 0; i < 6; i++)
            {
                Stopwatch watch1 = new Stopwatch();

                int[] numbers = GetRandomNumbers(i + 1);
                int first = numbers[0];
                int second = numbers[1];

                watch1.Start();
                int NOD = MainFunction.FindNOD(first, second);
                int[] result = MainFunction.AdvancedNOD(first, second);
                watch1.Stop();

                // Создание новой строки
                DataRow newRow = dataTable.NewRow();

                // Заполнение значений первых двух свойств
                newRow["Число 1"] = first;
                newRow["Число 2"] = second;
                newRow["НОД"] = NOD;
                newRow["u1"] = result[0];
                newRow["u2"] = result[1];
                newRow["u3"] = result[2];

                if (result[2] == 1)
                {
                    newRow["обратное число"] = result[0];
                }
                else
                {
                    newRow["обратное число"] = "НЕТ";
                }

                newRow["Время"] = watch1.Elapsed.TotalMilliseconds;

                // Добавление строки в DataTable
                dataTable.Rows.Add(newRow);
            }

            TestDG.ItemsSource = dataTable.DefaultView;
        }
    }
}
