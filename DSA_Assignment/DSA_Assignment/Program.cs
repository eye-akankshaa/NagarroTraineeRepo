using DSA_Assignment.Exercises.HashTable;
using DSA_Assignment.Exercises.LinkedList;
using DSA_Assignment.Exercises.PriorityQueue;
using DSA_Assignment.Exercises.Queue;
using DSA_Assignment.Exercises.Stack;
using System;

namespace DSA_Assignment
{
    class Program
    {
        private static object LinkedListSolution;

        static void Main(string[] args)
        {
            //user input
            int flag = 1;
            int choice;
            do
            {
                Console.WriteLine("Select 1 for LinkedList ");
                Console.WriteLine("Select 2 for Stack ");
                Console.WriteLine("Select 3 for Queue ");
                Console.WriteLine("Select 4 for PriorityQueue ");
                Console.WriteLine("Select 5 for HashTable ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("This is LinkedList implementation");
                        LinkedListDemo.Run();
                        break;
                    case 2:
                        Console.WriteLine("This is Stack implementation");
                        StackDemo.Run();
                        break;
                    case 3:
                        Console.WriteLine("This is Queue implementation");

                        QueueDemo.Run();

                        break;
                    case 4:
                        Console.WriteLine("This is Priority Queue implementation ");

                        PriorityQueueDemo.Run();

                        break;
                    case 5:
                        Console.WriteLine("This is HashTable implementation");
                        HashTableDemo.Run();
                        break;

                    default:
                        Console.WriteLine("Oops, Wrong choice");
                        break;

                }

                Console.WriteLine("Do you wish to continue to see another Data structure implementation --> Press '1' to continue ,'0' for exit");
                flag = int.Parse(Console.ReadLine());

            } while (flag == 1);
        }
    }
}
