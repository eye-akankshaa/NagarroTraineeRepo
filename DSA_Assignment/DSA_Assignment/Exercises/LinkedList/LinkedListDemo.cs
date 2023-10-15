using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.LinkedList
{
    public class LinkedListDemo
    {
        public static void Run()
        {
            int flag = 1;
            LinkedList linkList = new LinkedList();
            int element, position;
            LinkListIterator iterator = new LinkListIterator(linkList);

            
            do {
               
                Console.WriteLine("\nChoose Operation:\n1.Display List\n2.Insert element at beginning\n3.Insert element at Last\n4.Insert Element at any position\n5.Delete element from Beginning\n6.Delete element from Last\n7.Delete from any position\n8.Reverse LinkedList\n9.Center\n10.Sort\n11.Size\n12.Iterator");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        linkList.PrintLinkedList();
                        break;
                    case 2:
                        Console.Write("Enter element:");
                        element = Convert.ToInt32(Console.ReadLine());
                        linkList.InsertFirst(element);
                        break;
                    case 3:
                        Console.Write("Enter element:");
                        element = Convert.ToInt32(Console.ReadLine());
                        linkList.InsertLast(element);
                        break;
                    case 4:
                        Console.Write("Enter element:");
                        element = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter position:");
                        position = Convert.ToInt32(Console.ReadLine());
                        linkList.InsertAtPosition(element, position);
                        break;
                    case 5:
                        linkList.DeleteFirst();
                        break;
                    case 6:
                        linkList.DeleteLast();
                        break;
                    case 7:
                        Console.Write("Enter Position:");
                        position = Convert.ToInt32(Console.ReadLine());
                        linkList.DeleteAtPosition(position);
                        break;
                    case 8:
                        linkList.Reverse();
                        linkList.PrintLinkedList();
                        break;
                    case 9:
                        int mid = linkList.Center();
                        Console.WriteLine("The center ele is {0}", mid);
                        break;
                    case 10:
                        linkList.Sort();
                        linkList.PrintLinkedList();
                        break;
                    case 11:
                        Console.WriteLine(linkList.Size());
                        break;
                    case 12:
                        iterator.nextElement();
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input");
                        break;
                        

                }
                Console.WriteLine();
                Console.WriteLine("Do you wish to continue --> Press '1' to continue ,'0' for exit");
                flag = int.Parse(Console.ReadLine());

            } while (flag==1);

          
        }
    }

}
