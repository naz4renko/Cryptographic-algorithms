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

namespace InfoSecurity.VigTrithCardСipher
{
    /// <summary>
    /// Логика взаимодействия для SymmetricCipher.xaml
    /// </summary>
    public partial class SymmetricCipher : UserControl
    {
        MainFunctional mainFunctional = new MainFunctional();
        public SymmetricCipher()
        {
            InitializeComponent();

        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
           EncryptTB.Text = mainFunctional.EncryptMessage(MessageTB.Text, Convert.ToChar(keyLettersCB.Text));
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (EncryptTB.Text != null) 
            {
                DecryptTB.Text = mainFunctional.DecryptMessage(EncryptTB.Text, Convert.ToChar(keyLettersCB.Text));
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

        private void EntropyButton_Click(object sender, RoutedEventArgs e)
        {
            if (EntropyTB.Text != null)
            {
                EntropyTB.Text = null;
            }
            if (EncryptTB.Text != null)
            {
                EntropyTB.Text += $"Энтропия исходного сообщения - {Math.Round(mainFunctional.FindEntropy(DecryptTB.Text),3)} \n";
            }

            if (DecryptTB.Text != null)
            {
                EntropyTB.Text += $"Энтропия зашифрованного сообщения - {Math.Round(mainFunctional.FindEntropy(EncryptTB.Text),3)} \n";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageTB.Text = null;
            DecryptTB.Text = null;
            EncryptTB.Text = null;
            EntropyTB.Text = null;
        }
    }
}
