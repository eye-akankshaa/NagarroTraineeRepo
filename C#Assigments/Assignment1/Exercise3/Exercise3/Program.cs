using System;
using System.Text;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            primeNumber();
        }


        static void primeNumber()
        {
            bool _rightrange=false ;

            do {

                Console.WriteLine();

                Console.WriteLine("Enter the positive start range number between 2 and 1000");
                int _starttrange = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Enter the positive end range number between 2 and 1000");
                int _endrange = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                

                
                
                if (_starttrange < _endrange)
                {
                    Console.WriteLine("Prime numbers between the given range are:");

                    _rightrange = true;
                    int count = 0;
                    for (int num = _starttrange + 1; num < _endrange; num++)
                   {

                        
                        int flag = 0;
                        for (int div = 2; div <= num / 2; div++)
                        {
                            if (num % div == 0)
                            {
                            
                             flag = 1;
                             break;
                            }
                        }
                        if (flag == 0)
                        {
                            Console.WriteLine(num);
                            count++;
                            
                        }
                        
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Sorry ,No Prime numbers found");
                    }
                    

                }

                else
                {
                    Console.WriteLine("OOPs You entered wrong ranges,Enter the ranges again");
                    continue;
                }





           } while (_rightrange==false);

        }//func close
    
    }//class close




}//namespace close
