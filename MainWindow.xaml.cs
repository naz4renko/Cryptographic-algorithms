using InfoSecurity.BinaryCipher;
using InfoSecurity.EuclidAlgorithm;
using InfoSecurity.Knackpack;
using InfoSecurity.LFSR;
using InfoSecurity.VigTrithCardСipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    public partial class MainWindow : Window
    {
        CaesarCipher caesarCipher = new CaesarCipher();
        SymmetricCipher symmetricCipher = new SymmetricCipher();
        BinaryCipher.BinaryCipher binaryCipher = new BinaryCipher.BinaryCipher();
        EuclidAlgorithm.EuclidAlgorithm euclidAlgorithm = new EuclidAlgorithm.EuclidAlgorithm();
        LemhannTest.LemhannWindow lemhannWindow = new LemhannTest.LemhannWindow();
        Knapsack knapsack = new Knapsack();
        GeneratorPSP generator = new GeneratorPSP();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void CaesarButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = caesarCipher;
        }
        private void SymmetricButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = symmetricCipher;
        }

        private void BinaryButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = binaryCipher;
        }

        private void EuclidButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = euclidAlgorithm;
        }

        private void LemhannButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = lemhannWindow;

        }

        private void KnackpackButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = knapsack;
        }

        private void GeneratorButton_Click(object sender, RoutedEventArgs e)
        {
            UserController.Content = generator;
        }
    }
}
