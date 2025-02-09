using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace InfoSecurity
{
    public partial class CaesarCipher : UserControl
    {
        ChiSquaredStatistic chiSquared = new ChiSquaredStatistic();

        public CaesarCipher()
        {
            InitializeComponent();
            chiSquared.workDataTable += ChiSquared_workDataTable;
        }

        public static string EncryptWithUnicode(string input, int shift)
        {
            string encryptedText = "";

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    encryptedText += c;
                    continue;
                }

                char baseChar = char.IsUpper(c) ? 'А' : 'а';
                //вычисление смещения символа, относительно базового
                int offset = (int)c - (int)baseChar;
                //сдвиг на заданый ключ
                int shiftedOffset = (offset + shift) % 32;
                char shiftedChar = (char)((int)baseChar + shiftedOffset);

                encryptedText += shiftedChar;
            }

            return encryptedText;
        }

        public static string DecryptWithUnicode(string encryptedText, int shift)
        {
            string decryptedText = "";

            foreach (char c in encryptedText)
            {
                if (!char.IsLetter(c))
                {
                    decryptedText += c;
                    continue;
                }

                char baseChar = char.IsUpper(c) ? 'А' : 'а';
                int offset = (int)c - (int)baseChar;
                int shiftedOffset = (offset - shift + 32) % 32;
                char shiftedChar = (char)((int)baseChar + shiftedOffset);

                decryptedText += shiftedChar;
            }

            return decryptedText;
        }

        private void ChiSquared_workDataTable(System.Data.DataTable data)
        {
            ChiSquaredDG.ItemsSource = data.DefaultView;
        }

        private void MessageTB_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void KeyTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                if (KeyTB.Text.Length < 2)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MessageTB.Text) && !string.IsNullOrWhiteSpace(KeyTB.Text))
            {
                EncryptTB.Text = EncryptWithUnicode(MessageTB.Text, Convert.ToInt32(KeyTB.Text));
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EncryptTB.Text) && !string.IsNullOrWhiteSpace(KeyTB.Text))
            {
                DecryptTB.Text = DecryptWithUnicode(EncryptTB.Text, Convert.ToInt32(KeyTB.Text));
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
                    MessageTB.Text = text;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
                }
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (EncryptTB.Text != null)
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
                        writer.WriteLine(EncryptTB.Text);
                    }
                }
            }
        }

        private void ChiSqrButton_Click(object sender, RoutedEventArgs e)
        {
            if (EncryptTB.Text != null)
            {
                ChiSqrTB1.Text = Convert.ToString(chiSquared.CalculateChiSquared(EncryptTB.Text));
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageTB.Text = null;
            KeyTB.Text = null;
            EncryptTB.Text = null;
            DecryptTB.Text = null;
            ChiSqrTB1.Text = null;
        }

        private void CalculateChiSqr_Click(object sender, RoutedEventArgs e)
        {
            chiSquared.CalculateFullChiSquared(EncryptTB.Text);
        }

        private void ChiSqrFullButton_Click(object sender, RoutedEventArgs e)
        {
            ChiGrid.Visibility = Visibility.Visible;
        }

        private void CloseWindowChiSqr_Click(object sender, RoutedEventArgs e)
        {
            ChiGrid.Visibility = Visibility.Hidden;
            ChiSquaredDG.ItemsSource = null;

        }
    }
}

