using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.EuclidAlgorithm
{
    public class MainFunction
    {
        public static int FindNOD(int a, int b)
        {

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static int[] AdvancedNOD(int a, int b)
        {
            int[] results = new int[3];
            // Исходные коэффициенты для a и b
            int u1 = 0, u2 = 1, u3 = b;
            int v1 = 1, v2 = 0, v3 = a;

            while (v3 != 0)
            {
                int quotient = u3 / v3;

                // Новые коэффициенты на основе результата деления
                int temp = v3;
                v3 = u3 - quotient * v3;
                u3 = temp;

                temp = v1;
                v1 = u1 - quotient * v1;
                u1 = temp;

                temp = v2;
                v2 = u2 - quotient * v2;
                u2 = temp;
            }

            // На выходе получаем коэффициенты u1 и u2
            results[0] = u1;
            results[1] = u2;
            results[2] = u3;
            return results;
        }

        //public static int [] BackNumberEuclid(int a, int n)
        //{
        //    int[] results = new int[3];
        //    // Исходные коэффициенты для a и b
        //    int u1 = 0, u2 = 1, u3 = n;
        //    int v1 = 1, v2 = 0, v3 = a;

        //    while (v3 != 1)
        //    {
        //        if (v3 == 0)
        //            return results;
        //        int quotient = u3 / v3;

        //        // Новые коэффициенты на основе результата деления
        //        int temp = v3;
        //        v3 = u3 - quotient * v3;
        //        u3 = temp;

        //        temp = v1;
        //        v1 = u1 - quotient * v1;
        //        u1 = temp;

        //        temp = v2;
        //        v2 = u2 - quotient * v2;
        //        u2 = temp;
        //    }

        //    // На выходе получаем коэффициенты u1 и u2
        //    results[0] = u1;
        //    results[1] = u2;
        //    results[2] = u3;
        //    return results;
        //}
    }
}
