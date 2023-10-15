using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    static class IsOddClass
    {
        public static void IsOdd(this int num)//Logic for a number to be odd
        {
            if (num % 2 == 0)
            {
                Console.WriteLine("{0} Is not odd", num);
            }
            else
            {
                Console.WriteLine("{0} Is odd", num);
            }
        }
    }
}
