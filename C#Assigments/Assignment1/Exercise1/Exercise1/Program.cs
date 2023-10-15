using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)

        {

            //Method to Convert a string into integer.


            Console.WriteLine("Enter the string  which you want to convert to integer:");

            //here simply read input as a string
            string ival = Console.ReadLine();

            //1. Here we use int.parse method to perform operations

            //This method convert input string to integer

            int finalResult = int.Parse(ival);
            Console.WriteLine("type conversion using integer.Parse::" + finalResult);

            //2. Here we use Convert.ToInt method

            // This method convert integer type string to integer

            int result2 = Convert.ToInt32(ival);
            Console.WriteLine("type conversion using  Convert.ToInt32 :" + result2);

            //3. Here we use int.TryParse method

            // This method read input as string and then convert it into integer

            int converted_integer;
            if (int.TryParse(ival, out converted_integer))
            {
                Console.WriteLine("type conversion  using TryParse:" + converted_integer);
            }
            else
            {
                Console.WriteLine("invalid input");
            }
            Console.ReadLine();



           
            // Method to Convert a string into float.
            

            string fval;
            Console.WriteLine("Enter String that you want to convert to Float");

            fval = Console.ReadLine();

            //a. using float.parse
            float f1 = float.Parse(fval);
            Console.WriteLine("Type Conversion using float.Parse " + f1);

            //b. using Convert.ToDouble
            double f2 = Convert.ToDouble(fval);
            Console.WriteLine("Type Conversion using Convert.ToDouble " + f2);

            //c. using float.TryParse
            float f3;
            float.TryParse(fval, out f3);
            Console.WriteLine("Type Conversion using float.TryParses " + f3);

            Console.WriteLine();


            // Method to Convert a string into Boolean.

            Console.WriteLine("Enter String that you want to convert to Boolean");

            string bval = Console.ReadLine();

            //a.using bool.parse
            bool boolVal1 = bool.Parse(bval);
            Console.WriteLine("Type Conversion using bool.Parse ::" + boolVal1);


            //b. using Convert.ToBoolean

            bool boolVal2 = Convert.ToBoolean(bval);
            Console.WriteLine("Type Conversion using Convert.ToBoolean :: " + boolVal2);

            
            // c. using tryParse
            
            bool boolVal3;
            Boolean.TryParse(bval, out boolVal3);
            Console.WriteLine("Type Conversion using Boolean.TryParse " + boolVal3);
            Console.ReadKey();

        }
    }
}
