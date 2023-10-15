using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.HashTable
{
    class HashTableDemo
    {
        public static void Run()
        {
            int flag = 1;

            HashTable hash = new HashTable();
            hash.CreateHashTable();//creating hashtable

            do
            {
                //giving options
                Console.WriteLine("");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Contains");
                Console.WriteLine("4. GetValueByKey");
                Console.WriteLine("5. Size");
                Console.WriteLine("6. Iterate");
                Console.WriteLine("7. Print");
               
                int choice;
                choice = Convert.ToInt32(Console.ReadLine());
                int key, value;

                switch (choice)
                {
                    //INSERT
                    case 1:

                        Console.WriteLine("Enter Key");
                        key = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter value");
                        value = Convert.ToInt32(Console.ReadLine());
                        hash.Insert(key, value);//calling method
                        break;


                    case 2:
                        //DELETE

                        Console.WriteLine("Which value you want to delete,enter its key");
                        key = Convert.ToInt32(Console.ReadLine());
                        hash.Delete(key);
                        Console.WriteLine("successfully deleted");
                        break;

                    //Contains
                    case 3:
                        Console.WriteLine("Check for the key");
                        key = Convert.ToInt32(Console.ReadLine());
                        bool res = hash.Contains(key);
                        Console.WriteLine(res);
                        break;


                        //GetValueByKey
                    case 4:
                        key = Convert.ToInt32(Console.ReadLine());
                        hash.GetValueByKey(key);
                        break;

                        //Size
                    case 5:
                        hash.Size();
                        break;

                        //Print
                    case 6:
                        hash.Print();
                        break;

                    case 7:
                        hash.Print();
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Do you wish to continue --> Press '1' to continue ,'0' for exit");
                flag = int.Parse(Console.ReadLine());

            } while (flag==1);

        }

    }
}
