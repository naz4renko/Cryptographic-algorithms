using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.BinaryCipher
{
    class MainFunctional
    {
        public static string GetFullBinaryCode(char symbol)
        {
            int charCode = symbol; // Получаем целочисленное представление символа

            // Создаем строку для хранения двоичного представления с 16 битами
            string binaryFull = "";

            // Проходим через каждый бит символьного кода
            for (int i = 15; i >= 0; i--)
            {
                // Проверяем, установлен ли текущий бит
                int bit = (charCode >> i) & 1;

                // Добавляем бит в начало строки
                binaryFull = binaryFull + bit;
            }
            return binaryFull;
        }

        public static string XORtwoString(string firstPart, string secondPart)
        {
            string XORingBinary = "";

            for (int i = 0; i < 8; i++)
            {
                XORingBinary += firstPart[i] ^ secondPart[i];
            }
            return XORingBinary;
        }

        public static int ConvertBinaryToNormal(string binaryCode)
        {
            double normal = 0;
            int doublePow = binaryCode.Length - 1;
            for (int i = 0; i < binaryCode.Length; i++)
            {
                if (binaryCode[i] == '1')
                {
                    normal += Math.Pow(2, doublePow - i);
                }
            }

            int unicode = Convert.ToInt32(normal);

            return unicode;
        }

        public static string EncryptSymbolInBinary(char symbol)
        {
            string encryptBinaryCode = "";

            string workBinary = GetFullBinaryCode(symbol);

            string firstPart = workBinary.Substring(0, 8);
            string secondPart = workBinary.Substring(8, 8);

            encryptBinaryCode += XORtwoString(firstPart, secondPart);
            encryptBinaryCode += firstPart;

            return encryptBinaryCode;

        }

        public static string DecryptSymbolInBinary(char encryptSymbol)
        {
            string decryptBinaryCode = "";

            string workBinary = GetFullBinaryCode(encryptSymbol);

            string firstPart = workBinary.Substring(0, 8);
            string secondPart = workBinary.Substring(8, 8);

            decryptBinaryCode += secondPart;
            decryptBinaryCode += XORtwoString(firstPart, secondPart);

            return decryptBinaryCode;

        }

        public static string EncryptWord(string word)
        {
            string encryptWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                string workBinary = EncryptSymbolInBinary(word[i]);
                int workUnicode = ConvertBinaryToNormal(workBinary);
                encryptWord += (char)workUnicode;
            }

            return encryptWord;
        }

        public static string DecryptWord(string encryptWord)
        {
            string decryptWord = "";

            for (int i = 0; i < encryptWord.Length; i++)
            {
                string workBinary = DecryptSymbolInBinary(encryptWord[i]);
                int workUnicode = ConvertBinaryToNormal(workBinary);
                decryptWord += (char)workUnicode;
            }

            return decryptWord;
        }

        public static byte[] GetBytesOfSymbol(char symbol)
        {
            byte[] bytesOfSymbol = new byte[2];
            string binaryCodeOfSymbol = GetFullBinaryCode(symbol);

            string firstPart = binaryCodeOfSymbol.Substring(0, 8);
            string secondPart = binaryCodeOfSymbol.Substring(8, 8);

            bytesOfSymbol[0] = Convert.ToByte(ConvertBinaryToNormal(firstPart));
            bytesOfSymbol[1] = Convert.ToByte(ConvertBinaryToNormal(secondPart));

            return bytesOfSymbol;
        }
    }
}
