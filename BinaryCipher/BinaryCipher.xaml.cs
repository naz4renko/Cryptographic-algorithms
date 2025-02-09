using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace InfoSecurity.BinaryCipher
{
    /// <summary>
    /// Логика взаимодействия для BinaryCipher.xaml
    /// </summary>
    public partial class BinaryCipher : UserControl
    {
        public BinaryCipher()
        {
            InitializeComponent();
        }

        private void EncryptMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkMessage.Text != null)
            {
                string workMessage = MainFunctional.EncryptWord(WorkMessage.Text);
                ResultMessage.Text = workMessage;

                // Создание DataTable
                DataTable dataTable = new DataTable();

                // Добавление столбцов в DataTable
                dataTable.Columns.Add("Символ");
                dataTable.Columns.Add("Код 10");
                dataTable.Columns.Add("Код 2");
                dataTable.Columns.Add("Левый байт (2)");
                dataTable.Columns.Add("Правый байт (2)");
                dataTable.Columns.Add("XOR байтов");
                dataTable.Columns.Add("Результат");


                // Заполнение данных
                foreach (var symbol in WorkMessage.Text)
                { 
                    // Создание новой строки
                    DataRow newRow = dataTable.NewRow();

                    byte[] bytes = MainFunctional.GetBytesOfSymbol(symbol);
                    string workBinary = MainFunctional.GetFullBinaryCode(symbol);

                    string firstPart = workBinary.Substring(0, 8);
                    string secondPart = workBinary.Substring(8, 8);
                    string xor = MainFunctional.XORtwoString(firstPart, secondPart);

                    newRow["Символ"] = symbol;
                    newRow["Код 10"] = (int)symbol;
                    newRow["Код 2"] = firstPart + " " + secondPart;
                    newRow["Левый байт (2)"] = firstPart;
                    newRow["Правый байт (2)"] = secondPart;
                    newRow["XOR байтов"] = xor;
                    newRow["Результат"] = MainFunctional.EncryptSymbolInBinary(symbol);


                    // Добавление строки в DataTable
                    dataTable.Rows.Add(newRow);
                }
                
                // Привязка DataTable к DataGrid
                ResultsDG.ItemsSource = dataTable.DefaultView;


                // Создание DataTable
                DataTable dataTable2 = new DataTable();

                // Добавление столбцов в DataTable
                dataTable2.Columns.Add("Символ");
                dataTable2.Columns.Add("Код 10");
                dataTable2.Columns.Add("Код 2");

                // Заполнение данных
                foreach (var symbol in ResultMessage.Text)
                {
                    // Создание новой строки
                    DataRow newRow = dataTable2.NewRow();

                    string workBinary = MainFunctional.GetFullBinaryCode(symbol);

                    string firstPart = workBinary.Substring(0, 8);
                    string secondPart = workBinary.Substring(8, 8);

                    string xor = MainFunctional.XORtwoString(firstPart, secondPart);

                    newRow["Символ"] = symbol;
                    newRow["Код 10"] = (int)symbol;
                    newRow["Код 2"] = firstPart + " " + secondPart;

                    // Добавление строки в DataTable
                    dataTable2.Rows.Add(newRow);
                }

                // Привязка DataTable к DataGrid
                Results2DG.ItemsSource = dataTable2.DefaultView;
            }
        }

        private void DecryptMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkMessage.Text != null)
            {
                ResultMessage.Text = MainFunctional.DecryptWord(WorkMessage.Text);
            }
        }

        private void ReadFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string text = File.ReadAllText(filePath);
                    WorkMessage.Text = text;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
                }
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultMessage.Text != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.Title = "Сохранить строку в файл";

                // Отобразить диалог выбора файла
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Получить выбранный путь к файлу
                    string filePath = saveFileDialog.FileName;

                    // Записать строку в файл
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine(ResultMessage.Text);
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            WorkMessage.Text = null;
            ResultMessage.Text = null;
            ResultsDG.ItemsSource = null;
            Results2DG.ItemsSource = null;
        }
    }
}
