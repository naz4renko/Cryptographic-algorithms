using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity.LemhannTest
{
    public class LemhannFunctional
    {
        static long ModPow(long x, long y, long p)
        {
            long res = 1;
            x = x % p;

            while (y > 0)
            {
                if (y % 2 == 1)
                    res = (res * x) % p;

                y = y >> 1;
                x = (x * x) % p;
            }
            return res;
        }

        public static int LehmannTest(long n, int t)
        {
            Random rand = new Random();

            if (n == 2)
                return 1;

            while (t > 0)
            {
                long b = rand.Next(2, (int)n - 1); // Генерируем случайное число от 2 до n-2
                long result = ModPow(b, (n - 1) / 2, n);

                if (result != 1 && result != n - 1)
                    return -1;

                t--;
            }

            return 1;
        }
    }
}
