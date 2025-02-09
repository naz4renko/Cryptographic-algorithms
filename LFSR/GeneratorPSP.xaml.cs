using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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

namespace InfoSecurity.LFSR
{
    /// <summary>
    /// Логика взаимодействия для GeneratorPSP.xaml
    /// </summary>
    public partial class GeneratorPSP : UserControl
    {
        private LFSR_Galua lfsr;
        uint registr;
        List<string> history = new List<string>();
        public GeneratorPSP()
        {
            InitializeComponent();
        }
        public string GenerateRandomRegistr()
        {
            string work = "";
            Random rnd = new Random();
            for (int i = 0; i < 32; i++)
            {
                work += rnd.Next(0, 2).ToString();
            }
            return work;
        }
        public static string ReverseString(string input)
        {
            return new string(input.Reverse().ToArray());
        }
        private void GenerateStartRegistr_Click(object sender, RoutedEventArgs e)
        {
            
            StartRegistr.Text = null;
            string work = GenerateRandomRegistr();
            registr = Convert.ToUInt32(work, 2);
            StartRegistr.Text = work;

        }

        private void StartGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (StartRegistr.Text != null && StartRegistr.Text.Length == 32) 
            {
                lfsr = new LFSR_Galua(Convert.ToUInt32(StartRegistr.Text, 2));
                string result = lfsr.GenerateFull(128);
                result = ReverseString(result);
                Result.Text = result;
                history = lfsr.HistoryRegistr;


                // Создание DataTable
                DataTable dataTable = new DataTable();

                // Добавление столбцов в DataTable
                dataTable.Columns.Add("Итерация");
                dataTable.Columns.Add("Состояние регистра");
                int i = 1;
                foreach (var item in history)
                {
                    DataRow newRow = dataTable.NewRow();

                    // Заполнение значений первых двух свойств
                    newRow["Итерация"] = i;
                    newRow["Состояние регистра"] = item;

                    // Добавление строки в DataTable
                    dataTable.Rows.Add(newRow);
                    i++;
                }
                TableOfIteration.ItemsSource = dataTable.DefaultView;

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            StartRegistr.Text = null;
            Result.Text = null;
            TableOfIteration.ItemsSource = null;
        }
    }
}
