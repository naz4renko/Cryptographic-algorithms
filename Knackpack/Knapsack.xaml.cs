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

namespace InfoSecurity.Knackpack
{
    /// <summary>
    /// Логика взаимодействия для Knapsack.xaml
    /// </summary>
    public partial class Knapsack : UserControl
    {
        KnapsackAlgorithm pack;
        List<int> MySecretKey { get; set; }
        List<int> MyPublicKey { get; set; }
        int MyM { get; set; }
        int MyN { get; set; }
        public Knapsack()
        {
            InitializeComponent();
            pack = new KnapsackAlgorithm();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedItem != null)
            {
                int n = Convert.ToInt32(ComboBox.SelectedItem.ToString());

                List<int> secretKey = pack.GenerateSecretKey(n);

                int k = 1;
                foreach(var key in secretKey) 
                {
                    if (k < n)
                    {
                        PrivateKeyTB.Text += $"{key} ";
                    }
                    else
                    {
                        PrivateKeyTB.Text += $"{key}";
                    }
                    k++;
                }
            }
        }

        private void GenerateNandM_Click(object sender, RoutedEventArgs e)
        {
            if (PrivateKeyTB.Text != null)
            {
                string [] arr = PrivateKeyTB.Text.Split(' ');

                List<int> secretList = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    int a = int.Parse(arr[i].Trim());
                    secretList.Add(a);
                }

                MySecretKey = secretList;

                int[] numbers = pack.GetMandN(MySecretKey);
                int M = numbers[0];
                int N = numbers[1];

                MyM = M;
                MyN = N;

                NumberMTB.Text = M.ToString();
                NumberNTB.Text = N.ToString();

                
            }

        }

        private void PublicKey_Click(object sender, RoutedEventArgs e)
        {
            if (NumberMTB.Text != null && NumberNTB.Text != null)
            {
                string[] arr = PrivateKeyTB.Text.Split(' ');

                List<int> secretList = new List<int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    int a = int.Parse(arr[i].Trim());
                    secretList.Add(a);
                }

                MySecretKey = secretList;


                int M = Convert.ToInt32(NumberMTB.Text);
                int N = Convert.ToInt32(NumberNTB.Text);

                List<int> publicKey = pack.GetPublicKey(MySecretKey, M, N);
                MyPublicKey = publicKey;

                foreach (var item in publicKey)
                {
                    PublicKeyTB.Text += $"{item} ";
                }
            }
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageForEncrypt.Text != null)
            {
                List<int> encryptMessage = pack.Encrypt(MessageForEncrypt.Text, MyPublicKey);

                foreach(var item in encryptMessage)
                {
                    EncryptMessageTB.Text += $"{item} ";
                }
            }
        }

        private void DecryptMessage_Click(object sender, RoutedEventArgs e)
        {
            if (NumberMTB_2.Text != null && NumberNTB_2.Text != null && MessageForDecryptTB.Text != null && PrivateKey1TB.Text != null)
            {
                int M = Convert.ToInt32(NumberMTB_2.Text);
                int N = Convert.ToInt32(NumberNTB_2.Text);

                List<int> messageList = new List<int>();

                string[] arr = MessageForDecryptTB.Text.Split(' ');

                for (int i = 0; i < arr.Length; i++)
                {
                    int a = int.Parse(arr[i].Trim());
                    messageList.Add(a);
                }

                List<int> privateKey = new List<int>();

                string[] arrKey = PrivateKey1TB.Text.Split(' ');

                for (int i = 0; i < arrKey.Length; i++)
                {
                    int a = int.Parse(arrKey[i].Trim());
                    privateKey.Add(a);
                }

                InverseTB.Text = pack.ModInverse(N, M).ToString();

                DecryptMessageTB.Text = pack.Decrypt(messageList, privateKey, M, N);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MySecretKey = null;
            MyPublicKey = null;
            MyM = 0;
            MyN = 0;

            PrivateKeyTB.Text = null;
            NumberMTB.Text = null;
            NumberNTB.Text = null;
            NumberMTB_2.Text = null;
            NumberNTB_2.Text = null;
            PublicKeyTB.Text = null;
            MessageForEncrypt.Text = null;
            EncryptMessageTB.Text = null;
            MessageForDecryptTB.Text = null;
            PrivateKey1TB.Text = null;
            DecryptMessageTB.Text = null;
        }
    }
}
