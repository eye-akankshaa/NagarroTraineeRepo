using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
          == operator :-Equality Operator basically used as a comparision operator but it also checks for the reference identity.

           Equals() :-Equals method is basically used to check the content of the string.

           Example 1 :-

            string str = "hello";
            string str2 = str;
            Console.WriteLine("Using Equality operator: {0}", str == str2);
            Console.WriteLine("Using equals() method: {0}", str.Equals(str2));

            Output 1 :-
            True
            True

            Explaination :-Since we are assigning str to str2 so reference will be same.
                            And Equals check for the content hence, that to will be same.


            Example 2 :-

            object str = "hello";
            char[] values = { 'h', 'e', 'l', 'l', 'o' };
            object str2 = new string(values);
            Console.WriteLine("Using Equality operator: {0}", str == str2);
            Console.WriteLine("Using equals() method: {0}", str.Equals(str2));

            Output 2 :-
            False
            True

            Explaination :-Here reference will be different for str and str2 , hence false,
                              But content will be same, so true.


           ReferenceEquals() :-Object.ReferenceEquals() Method is used to determine whether,
                                the specified Object instances are the same instance or not.This method cannot
                                be overriden.




           */

           //Initiating a string
            string name = "Akansha";
            string name1 = "Akansha";
            string compare = name; //giving same value as string
            char[] values = { 'A','k','a','n','s','h','a' };
            object str2 = new string(values);

            //Another string
            string lastName = "Khandelwal";
            Console.WriteLine(name == compare);//true
            Console.WriteLine(name == name1);//true
            
           
            Console.WriteLine(name.Equals(compare)); //true
            Console.WriteLine(name.Equals(values));//false
            Console.WriteLine(name.Equals(str2));//true
            
            Console.WriteLine(Object.ReferenceEquals(name, compare));//true
            Console.WriteLine(Object.ReferenceEquals(name, values));//false
            
            Console.WriteLine(name == lastName);//false
            
            Console.WriteLine(name.Equals(lastName));//false
            
            Console.WriteLine(Object.ReferenceEquals(name, lastName));//false
        }

    }
}

