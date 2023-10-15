using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    static class IsEvenClass
    {
        public static void IsEven(this int num)//logic for a number to be even
        {
            if (num % 2 == 0)
            {
                Console.WriteLine("{0} Is Even", num);
            }
            else
            {
                Console.WriteLine("{0} Is not Even", num);
            }
        }
    }
}
