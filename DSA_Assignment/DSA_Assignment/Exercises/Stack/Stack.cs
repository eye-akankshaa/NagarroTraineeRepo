using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.Stack
{
    class Stack
    {
        public static int[] arr;
        //fields
        public int top;
        public int size;

        //constructor
        public Stack(int size)
        {
            this.size = size;
            arr = new int[size];
            this.top = -1;
        }
        //1.Push
        public void push(int element)
        {
            if (top + 1 == size)
            {
                Console.WriteLine("Stack Is Full");
                return;
            }
            arr[++top] = element;
        }

        //2.Pop
        public int pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            Console.WriteLine("\n{0} popped from stack ", arr[top]);
            return arr[top--];
        }
        //3.Peek
        public int peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            Console.WriteLine("\nTop element: " + arr[top]);
            return arr[top];

        }
        //4.Contains-->search with help of Binary search
        public bool Contains(int element)
        {
            if (top == -1)
            {
                return false;
            }
            int L = 0;
            int R = size - 1;

            while (L <= R)
            {
                int m = (L + R) / 2;
                if (element == arr[m])
                {
                    return true;
                }
                else if (element < arr[m])
                    R = m - 1;
                else if (element > arr[m])
                    L = m + 1;
            }
            return false;

        }
        //5.Size
        public int sizeOf()
        {
            if (top == -1)
            {
                return 0;
            }
            return top + 1; //size = top + 1
        }
        //6.Center
        public int center()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            int m = sizeOf() / 2;
            return arr[m];
        }
        //7.Reverse-->Inplace reverse
        public void reverse()
        {
            int left;
            int right = top;
            for (left = 0; left < right; left++, right--)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;

            }

        }
        //8.sort--> Inplace sort
        public void sort()
        {
            for (int i = 0; i < top + 1; i++)
            {
                for (int j = 0; j < top; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

                }
            }
        }

        //9.PrintStack
        public void printStack()

        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty Nothing to display");
            }
            for (int i = 0; i < top + 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }


    }
    //10.iterator
    class StackIterator
    {
        Stack s;
        public StackIterator(Stack s)
        {
            this.s = s;
        }
        public void nextElement()
        {
            int i = 0;
            while (i < s.top + 1)
            {
                Console.WriteLine(Stack.arr[i]);
                i++;
            }
        }
    }

}
