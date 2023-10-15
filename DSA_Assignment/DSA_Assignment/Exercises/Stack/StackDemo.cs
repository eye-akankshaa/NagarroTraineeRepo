using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.Stack
{
    class StackDemo
    {
        public static void Run()
        {
          
            int flag = 1;
                Console.Write("Enter Size Limit of Stack:");
                int size = Convert.ToInt32(Console.ReadLine());

                Stack stack = new Stack(size);
                StackIterator iterator = new StackIterator(stack);
            
            do
            {
                Console.WriteLine("CHOOSE:\n1.Push\n2.Pop\n3.Peek\n4.Contains\n5.Size\n6.Center\n7.Sort\n8.Reverse\n9.Print\n10.Iterator");
                int choice = Convert.ToInt32(Console.ReadLine());

                int element;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter element:");
                        element = Convert.ToInt32(Console.ReadLine());
                        stack.push(element);
                        break;
                    case 2:
                        stack.pop();
                        break;
                    case 3:
                        stack.peek();
                        break;
                    case 4:
                        Console.Write("Enter element to be searched:");
                        int searchNumber = Convert.ToInt32(Console.ReadLine());

                        if (stack.Contains(searchNumber))
                            Console.WriteLine("Element Found");
                        else
                            Console.WriteLine("Element not Found");
                        break;
                    case 5:
                        Console.WriteLine("Size:" + stack.sizeOf());
                        break;
                    case 6:
                        Console.WriteLine("Center element:" + stack.center());
                        break;
                    case 7:
                        stack.sort();
                        stack.printStack();
                        break;
                    case 8:
                        stack.reverse();
                        stack.printStack();
                        break;
                    case 9:
                        stack.printStack();
                        break;
                    case 10:

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
