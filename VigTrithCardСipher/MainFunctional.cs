using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.VigTrithCardСipher
{
    internal class MainFunctional
    {
        public string EncryptMessage(string message, char keyLetter)
        {
            string encryptedText = "";
            int baseChar = 1072;
            int cumulativeShift = (int)keyLetter - baseChar;

            foreach (char letter in message)
            {
                if (!char.IsLetter(letter))
                {
                    encryptedText += letter;
                    continue;
                }

                int offset = (int)letter - baseChar;
                int shiftedOffset = (offset + cumulativeShift) % 32;

                char shiftedChar = (char)((int)baseChar + shiftedOffset);

                cumulativeShift = (cumulativeShift + offset) % 32;

                encryptedText += shiftedChar;
            }
            return encryptedText;
        }

        public string DecryptMessage(string encryptedMessage, char keyLetter)
        {
            string decryptedMessage = "";
            int baseChar = 1072;
            int workKey = (int)keyLetter - baseChar;

            foreach (char letter in encryptedMessage)
            {
                char encryptedChar = '?';
                int workLetter = (int)letter - baseChar;

                if (!char.IsLetter(letter))
                {
                    decryptedMessage += letter;
                    continue;
                }

                if (workKey > workLetter)
                {
                    encryptedChar = (char)(baseChar + ((32 + workLetter) - workKey));
                }
                else
                {
                    encryptedChar = (char)(baseChar + (workLetter - workKey));
                }
                workKey = (int)letter - baseChar;
                decryptedMessage += encryptedChar;
            }

            return decryptedMessage;
        }

        public double FindEntropy(string message)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            int totalChars = 0;

            foreach (char c in message)
            {
                if (!charCounts.ContainsKey(c))
                {
                    charCounts[c] = 1;
                }
                else
                {
                    charCounts[c]++;
                }
                totalChars++;
            }

            double entropy = 0.0;
            foreach (var count in charCounts.Values)
            {
                double probability = (double)count / totalChars;
                entropy -= probability * Math.Log(probability, 2);
            }

            return entropy;
        }
    }
}
