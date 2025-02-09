using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.Knackpack
{
    public class KnapsackAlgorithm
    {

        public List<int> GenerateSecretKey(int n)
        {
            var sequence = new List<int> { 1 };
            while (sequence.Count < n)
            {
                int nextElement = sequence.Sum() + new Random().Next(1, 3);
                sequence.Add(nextElement);
            }
            return sequence;
        }

        public int[] GetMandN(List<int> secretKey)
        {
            int[] MandN = new int[2];

            int M = 0;
            int N = 0;

            // Автоматический расчет M (больше суммы всех элементов в секретном рюкзаке)
            int sum = 0;
            foreach (var i in secretKey)
            {
                sum += i;
            }
            M = sum + 1;

            // Автоматический выбор N взаимно простого с M
            Random random = new Random();
            do
            {
                N = random.Next(2, M);
            } while (EuclidAlgorithm.MainFunction.FindNOD(N,M) != 1);

            MandN[0] = M;
            MandN[1] = N;

            return MandN;
        }

        public List<int> GetPublicKey(List<int> secretKey, int M, int N)
        {
            // Генерация публичного рюкзака
            List<int> publicKey = secretKey.Select(x => (x * N) % M).ToList();
            return publicKey;
        }

        public bool VerificateKey(List<int> privateKey)
        {
            if (privateKey == null || privateKey.Count < 2)
            {
                return false;
            }
            int sum = 0;
            for (int i = 0; i < privateKey.Count; i++)
            {
                if (i > 0 && privateKey[i] <= sum)
                {
                    return false;
                }
                sum += privateKey[i];
            }
            return true;
        }

        public bool CheckKey(string[] key)
        {
            bool result = true;
            foreach (var item in key)
            {
                if (!int.TryParse(item.Trim(), out int number))
                {
                    result = false;
                }
            }
            return result;
        }

        private List<string> ConvertAndSplitBinary(string message, int n)
        {
            List<string> binaryList = new List<string>();

            string binary = message;

            bool flag = true;
            while (flag == true)
            {
                if (binary.Length % n != 0)
                {
                    binary = "0" + binary;
                }
                else
                {
                    flag = false;
                }
            }

            for (int i = 0; i < binary.Length; i += n)
            {
                if (i + n <= binary.Length)
                {
                    binaryList.Add(binary.Substring(i, n));
                }
                else
                {
                    binaryList.Add(binary.Substring(i));
                }
            }

            return binaryList;
        }

        public List<int> Encrypt(string message, List<int> publicKeys)
        {
            List<string> binaryMessageParts = ConvertAndSplitBinary(message, publicKeys.Count);

            var encryptedValues = new List<int>();

            foreach (var binaryPart in binaryMessageParts)
            {
                int sum = 0;
                for (int i = 0; i < binaryPart.Length; i++)
                {
                    if (binaryPart[i] == '1')
                    {
                        sum += publicKeys[i];
                    }
                }
                encryptedValues.Add(sum);
            }

            return encryptedValues;
        }

        public int ModInverse(int n, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            if (m == 1)
                return 0;

            while (n > 1)
            {
                int q = n / m;
                int t = m;

                m = n % m;
                n = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }

        public string Decrypt(List<int> encryptedMessage, List<int> privateKey, int m, int n)
        {
            string decryptMessage = "";
            List<int> workList = new List<int>();
            List<string> composeNumbers = new List<string>();
            int inverse = ModInverse(n, m);

            for (int i = 0; i < encryptedMessage.Count; i++)
            {
                workList.Add((encryptedMessage[i] * inverse) % m);
            }

            foreach (var number in workList)
            {
                composeNumbers.Add(ComposeNumber(number, privateKey));
            }

            foreach (var bin in composeNumbers)
            {
                decryptMessage += bin;
            }

            decryptMessage = RemoveLeadingZeros(decryptMessage);

            return decryptMessage;
        }

        public string RemoveLeadingZeros(string binaryString)
        {
            int startIndex = 0;
            while (startIndex < binaryString.Length && binaryString[startIndex] == '0')
            {
                startIndex++;
            }
            return binaryString.Substring(startIndex);
        }

        public string ComposeNumber(int N, List<int> list)
        {
            string comNum = "";

            int k = N;

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (k >= list[i])
                {
                    comNum += "1";
                    k = k - list[i];
                }
                else
                {
                    comNum += "0";
                }
            }

            comNum = Reverse(comNum);
            return comNum;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
