using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    static class IsPrimeClass
    {
        public static void IsPrime(this int num)// logic for a number to be prime
        {
            int count = 1;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    count = 1;
                    break;
                }
            }
            if (count == 1)
            {
                Console.WriteLine("{0} is a Prime number", num);
            }
            else
            {
                Console.WriteLine("{0} is not a Prime number", num);
            }
        }
    }
}
