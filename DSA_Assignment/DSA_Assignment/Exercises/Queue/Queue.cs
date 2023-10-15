using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.Queue
{
    class Queue
    {
        public int front = 0;
        public int rear = 0;
        public int size;
        public int[] arr;
        public Queue(int size)
        {
            front = -1;
            rear = -1;
            this.size = size;
            arr = new int[size];
        }
        //isFull
        public bool isFull()
        {
            if (front == 0 && rear == size - 1)
            {
                return true;
            }
            return false;
        }
        //isEmpty
        public bool isEmpty()
        {
            if (front == -1)
                return true;
            else
                return false;
        }
        // Enqueue
        public void enQueue(int value)
        {
            if (isFull())
            {
                Console.WriteLine("Queue is full!!");
            }
            else
            {
                if (front == -1)
                    front = 0;
                rear++;
                arr[rear] = value;
            }
        }
        //Dequeue
        public int deQueue()
        {
            int value;
            if (isEmpty())
            {
                Console.WriteLine("Queue is empty!!");
                return (-1);
            }
            else
            {
                value = arr[front];
                if (front >= rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front++;
                }
                Console.WriteLine("Deleted => " + value + " from queue");
                return (value);
            }
        }
        //PrintQueue
        public void printQueue()
        {
            int i;
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty!!");
            }
            else
            {
                Console.WriteLine("\nQueue ELements");
                for (i = front; i <= rear; i++)
                    Console.Write(arr[i] + " ");

            }
        }
        //size
        public void sizeOf()
        {
            Console.WriteLine("\nSize:" + ((rear - front) + 1));
        }
        //peek
        public void peek()
        {
            Console.WriteLine("Front Element:" + arr[front]);
        }
        //center
        public int center()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            int m = (front + rear) / 2;
            return arr[m];
        }
        //sort
        public void sort()
        {
            for (int i = front; i < rear + 1; i++)
            {
                for (int j = front; j < rear; j++)
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
        //reverse
        public void reverse()
        {
            int i;
            int j = rear;
            for (i = front; i < j; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;

            }

        }
        //Contains
        public bool contains(int key)
        {
            int i;
            int j = rear;
            for (i = front; i <= j; i++)
            {
                if (arr[i] == key)
                {
                    return true;

                }
            }
            return false;
        }


    }
    //iterator
    class QueueIterator
    {
        Queue q;
        public QueueIterator(Queue q)
        {
            this.q = q;
        }
        public void nextElement()
        {
            int i = q.front;
            int j = q.rear;
            while (i <= j)
            {
                Console.WriteLine(q.arr[i]);
                i++;
            }

        }
    }
}
