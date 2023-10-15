using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11
{
    
        static class DivisibleBy
        {
            public static void IsDivisibleBy(this int num)
            {
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)//All the numbers from 0 to num divisible by num
                    {
                        Console.WriteLine("{0} is divisible by {1}", num, i);
                    }
                }

            }
        }
    }

