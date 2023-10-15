using System;

namespace Exercise11
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Enter a number");
            number = int.Parse(Console.ReadLine());
            number.IsOdd();//IsOdd Extension
            number.IsEven();//IsEven Extension
            number.IsPrime();//IsPrime Extension
            number.IsDivisibleBy();//IsDivisibleBy Extension
            Console.ReadKey();
        }
    }
}
