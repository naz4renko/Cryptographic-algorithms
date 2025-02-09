using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity
{
    class ChiSquaredStatistic
    {
        public event Action<DataTable> workDataTable;

        Dictionary<char, double> alphabetFrequency = new Dictionary<char, double>()
        {
            { 'а', 0.07998}, { 'б', 0.01592},
            { 'в', 0.04533}, { 'г', 0.01687},
            { 'д', 0.02977}, { 'е', 0.08483},
            { 'ж', 0.00940}, { 'з', 0.01641},
            { 'и', 0.07367}, { 'й', 0.01208},
            { 'к', 0.03486}, { 'л', 0.04343},
            { 'м', 0.03203}, { 'н', 0.06700},
            { 'о', 0.10983}, { 'п', 0.02804},
            { 'р', 0.04746}, { 'с', 0.05473},
            { 'т', 0.06318}, { 'у', 0.02615},
            { 'ф', 0.00267}, { 'х', 0.00966},
            { 'ц', 0.00486}, { 'ч', 0.01450},
            { 'ш', 0.00718}, { 'щ', 0.00361},
            { 'ъ', 0.00037}, { 'ы', 0.01898},
            { 'ь', 0.01735}, { 'э', 0.00331},
            { 'ю', 0.00639}, { 'я', 0.02001} 
        };

        public double CalculateChiSquared(string message)
        {
            Dictionary<char, int> symbolCounts = new Dictionary<char, int>();

            foreach (char symbol in message)
            {
                if (!symbolCounts.ContainsKey(symbol))
                {
                    symbolCounts[symbol] = 0;
                }

                symbolCounts[symbol]++;
            }

            int totalLength = message.Length;

            Dictionary<char, double> symbolProbabilities = new Dictionary<char, double>();
            foreach (KeyValuePair<char, int> symbolCount in symbolCounts)
            {
                symbolProbabilities[symbolCount.Key] = (double)symbolCount.Value / totalLength;
            }
            
            double chiSquared = 0;
            foreach (var item in alphabetFrequency)
            {
                foreach(var sym in symbolProbabilities) 
                {
                    if (sym.Key == item.Key)
                    {
                        chiSquared += (Math.Pow((sym.Value - item.Value), 2)) / item.Value;
                    }
                }
            }

            return chiSquared;
        }

        public void CalculateFullChiSquared(string message)
        {
            // Создание DataTable
            DataTable dataTable = new DataTable();

            // Добавление столбцов в DataTable
            dataTable.Columns.Add("Сообщение");
            dataTable.Columns.Add("Ключ");
            dataTable.Columns.Add("хи-квадрат");
            dataTable.Columns.Add("Декодирование");

            for (int i = 0; i < 32; i++)
            {
                // Создание новой строки
                DataRow newRow = dataTable.NewRow();

                // Заполнение значений первых двух свойств
                newRow["Сообщение"] = message;
                newRow["Ключ"] = i;
                newRow["хи-квадрат"] = CalculateChiSquared(CaesarCipher.DecryptWithUnicode(message, i));
                newRow["Декодирование"] = CaesarCipher.DecryptWithUnicode(message,i);

                // Добавление строки в DataTable
                dataTable.Rows.Add(newRow);
            }

            workDataTable?.Invoke(dataTable);
        }
    }
}
