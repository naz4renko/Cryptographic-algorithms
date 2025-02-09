using System;
using System.Collections.Generic;
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

namespace InfoSecurity.LemhannTest
{
    /// <summary>
    /// Логика взаимодействия для LemhannWindow.xaml
    /// </summary>
    public partial class LemhannWindow : UserControl
    {
        public LemhannWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumberForTest.Text != null && CountOfIteration.Text != null) 
            {
                Stopwatch watch = new Stopwatch();
                int number = Convert.ToInt32(NumberForTest.Text);
                int count = Convert.ToInt32(CountOfIteration.Text);

                string result = "";

                watch.Start();
                long flag = LemhannFunctional.LehmannTest(number, count);

                if (number == 2)
                    result = " 2 это простое число";

                if (number % 2 == 0)
                    result = number + " Это составное";

                else
                {
                    if (flag == 1)
                        result = number + " Наверное простое";

                    else
                        result = number + " Это составное";
                }
                watch.Stop();
                ResultOfTest.Text = result;
                WatchResult.Text = $"{watch.Elapsed}";
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
