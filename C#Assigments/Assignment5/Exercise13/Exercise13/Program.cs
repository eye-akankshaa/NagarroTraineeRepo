using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            
            // 1.CustomAll
            bool allGreaterThanZero = numbers.CustomAll(x => x > 0);
            Console.WriteLine($"All numbers are greater than zero: {allGreaterThanZero}");  

            
            // 2.CustomAny
            bool anyGreaterThanTen = numbers.CustomAny(x => x > 10);
            Console.WriteLine($"Any number is greater than ten: {anyGreaterThanTen}");     
            
            
            // 3.CustomMax
            int max = numbers.CustomMax((x, y) => x.CompareTo(y));
            Console.WriteLine($"Max number is: {max}");       
            
            
            // 4.CustomMin
            int min = numbers.CustomMin((x, y) => x.CompareTo(y));
            Console.WriteLine($"Min number is: {min}");       
            
            
            // 5.CustomWhere
            IEnumerable<int> evenNumbers = numbers.CustomWhere(x => x % 2 == 0);
            Console.Write("Even numbers: ");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write($"{evenNumber} ");
            }
            Console.WriteLine();      
            
            
            // 6. CustomSelect
            IEnumerable<int> allPlusFive = numbers.CustomSelect(x => x + 5);
            Console.Write("Numbers plus by Five: ");
            foreach (int number in allPlusFive)
            {
                Console.WriteLine($"{number}");
            }
            Console.WriteLine();
        }
    }

}
    

