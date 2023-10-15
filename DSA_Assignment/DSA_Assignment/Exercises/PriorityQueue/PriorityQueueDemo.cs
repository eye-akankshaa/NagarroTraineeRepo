using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.PriorityQueue
{
    class PriorityQueueDemo
    {
       public static void Run()
        {
            int flag = 1;
            PriorityQueue<int> queue = new PriorityQueue<int>();
            
            
            do {
                
                
                    Console.WriteLine("enter option:\n1. for Enqueue\n2. for Dequeue\n3. for Peek\n4. check it contains the element or not\n5. for size\n6. for reverse\n7. for iterator\n8.Center\n9.Traverse ");

                    int input = int.Parse(Console.ReadLine());
                    int number;
                    int priority;
                    switch (input)
                    {
                        case 1:

                            Console.WriteLine("Please enter a number to be enqueue");
                            number = int.Parse(Console.ReadLine());

                            Console.WriteLine("Please enter Priority");
                            priority = int.Parse(Console.ReadLine());
                            queue.Enqueue(priority, number);
                            break;
                        case 2:
                            queue.Dequeue();
                            break;
                        case 3:
                            queue.Peek();
                            break;
                        case 4:
                            Console.WriteLine("Please enter a number to know queue contains it or not");
                            number = int.Parse(Console.ReadLine());
                            Console.WriteLine(queue.Contains(number));
                            break;
                        case 5:
                            Console.WriteLine(queue.Size());
                            break;
                        case 6:
                            queue.Reverse();
                            break;
                        case 7:
                            IEnumerable<string> ele = queue.iterator();
                            foreach (var element in ele)
                            {
                                Console.WriteLine(element);
                            }
                            break;
                        case 8:
                            queue.Center();
                            break;

                        case 9:
                            queue.Traverse();
                            break;
                        default:
                            Console.WriteLine("Enter valid input");
                            break;
                    }
                Console.WriteLine();
                Console.WriteLine("Do you wish to continue --> Press '1' to continue ,'0' for exit");
                flag = int.Parse(Console.ReadLine());

            } while (flag==1) ;
               

            
        }
    }
}
