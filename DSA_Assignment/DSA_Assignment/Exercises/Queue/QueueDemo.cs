using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.Queue
{
    class QueueDemo
    {
        public static void Run()
        {
            int flag = 1;
            
           
                Console.Write("Enter Size Limit of Queue:");
                int size = Convert.ToInt32(Console.ReadLine());
                Queue queue = new Queue(size);
                QueueIterator iterator = new QueueIterator(queue);
                
                do
                {
                    Console.WriteLine("CHOOSE:\n1.Enqueue\n2.Dequeue\n3.Peek\n4.Contains\n5.Size\n6.Center\n7.Sort\n8.Reverse\n9.Print\n10.Iterator");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    int element;
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter element:");
                            element = Convert.ToInt32(Console.ReadLine());
                            queue.enQueue(element);
                            break;
                        case 2:
                            queue.deQueue();
                            break;
                        case 3:
                            queue.peek();
                            break;
                        case 4:
                            Console.WriteLine("Enter element to be searched");
                            element = Convert.ToInt32(Console.ReadLine());
                            if (queue.contains(element))
                            {
                                Console.WriteLine("Element Found");
                            }
                            else
                            {
                                Console.WriteLine("Element not Found");
                            }
                            break;
                        case 5:
                            queue.sizeOf();
                            break;
                        case 6:
                            Console.WriteLine("Center:" + queue.center());
                            break;
                        case 7:
                            queue.sort();
                            Console.WriteLine("Sorted");
                            queue.printQueue();
                            break;
                        case 8:
                            queue.reverse();
                            Console.WriteLine("Reversed:");
                            queue.printQueue();
                            break;
                        case 9:
                            queue.printQueue();
                            break;
                        case 10:
                            iterator.nextElement();
                            break;

                        default:
                            Console.WriteLine("Enter valid input");
                            break;
                    }
              
                    Console.WriteLine();
                    Console.WriteLine("Do you wish to continue --> Press '1' to continue ,'0' for exit");
                    flag = int.Parse(Console.ReadLine());
                } while (flag == 1);

                


            }


        
    }

}