using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.LFSR
{
    internal class LFSR_Galua
    {
        private uint S;  // Начальное состояние регистра
        private readonly int[] FeedbackBits = { 0, 2, 25, 27, 31 };  // Отводные последовательности
        List<string> historyRegistr = new List<string>();

        public List<string> HistoryRegistr { get { return historyRegistr; } }

    // Конструктор, принимающий начальное состояние и отводные последовательности
        public LFSR_Galua(uint initialState)
        {
            S = initialState;
        }

        public int Generate()
        {
            int lsb = (int)(S & 1);  // Получаем младший бит
            int feedback = 0;
            foreach (int bitIndex in FeedbackBits)
            {
                feedback ^= (int)((S >> bitIndex) & 1);  // Выполняем XOR для битов отводных последовательностей
            }
            S = (S >> 1) | ((uint)feedback << 31);  // Обновляем состояние регистра
            historyRegistr.Add(Convert.ToString(S, 2).PadLeft(32, '0'));
            return lsb;
        }

        //// Метод для генерации следующего бита
        //public int Generate()
        //{
        //    int lsb = (int)(S & 1);  // Получаем младший бит
        //    int feedback = 0;
        //    foreach (int bitIndex in FeedbackBits)
        //    {
        //        feedback ^= (int)((S >> bitIndex) & 1);  // Выполняем XOR для битов отводных последовательностей
        //    }

        //    // Заменяем биты в регистре на индексе отводной последовательности результатом XOR с lsb
        //    foreach (int bitIndex in FeedbackBits)
        //    {
        //        uint mask = (uint)(1 << bitIndex);
        //        if (lsb == 1)
        //        {
        //            S ^= mask;  // Если lsb == 1, инвертируем бит на позиции bitIndex
        //        }
        //        // Если lsb == 0, бит остается без изменений
        //    }

        //    S = (S >> 1) | ((uint)feedback << 31);  // Обновляем состояние регистра
        //    historyRegistr.Add(Convert.ToString(S, 2).PadLeft(32, '0'));
        //    return lsb;
    

        public string GenerateFull(int n)
        {
            historyRegistr.Clear();
            string result = "";
            for (int i = 0; i < n; i++)
            {
                int k = Generate();
                result += k.ToString();
            }
            return result;
        }
    }
}
