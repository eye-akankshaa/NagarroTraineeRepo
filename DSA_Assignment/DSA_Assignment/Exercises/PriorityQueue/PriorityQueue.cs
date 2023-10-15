using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.PriorityQueue
{
    class Node<T>
    {

        public Node<T> next;

        public int priority;
        public T data;
        public Node(int priority, T value)
        {
            this.priority = priority;
            data = value;
            next = null;
        }
        public Node() { }

    }
    class PriorityQueue<T>
    {
        public Node<T> Head;
        public Node<T> Tail;

        //1.Enqueue
        public void Enqueue(int priority, T data)
        {

            Node<T> TempNode = new Node<T>(priority, data);

            if (Tail == null)
            {
                Tail = TempNode;
                Head = TempNode;
            }

            else
            {
                Node<T> previousNode = null;
                Node<T> tempNode = Head;


                int flagIsHighestPriority = 1;
                while (tempNode != null && tempNode.priority <= priority)
                {
                    flagIsHighestPriority = 0;
                    previousNode = tempNode;
                    tempNode = tempNode.next;
                }
                if (flagIsHighestPriority == 0)
                {
                    previousNode.next = TempNode;
                    TempNode.next = tempNode;
                    Tail = TempNode;
                }
                else
                {
                    TempNode.next = Head;
                    Head = TempNode;
                }
            }
        }
        //2.Dequeue
        public void Dequeue()
        {


            if (Head != null)
            {
                T temp;
                temp = Head.data;
                Head = Head.next; //As delete is from start
                if (Head == null)
                {
                    Tail = null;
                }
                Console.WriteLine(" Deleted successfully {0}", temp);
            }

            else
            {
                Console.WriteLine("cant delete, queue is empty");
            }



        }
        //4.Size
        public int Size()
        {
            int length = 0;
            Node<T> TempNode = Head;

            while (TempNode != null)
            {
                length++;
                TempNode = TempNode.next;
            }
            return length;
        }
        //5.Center
        public void Center()
        {
            int size = Size();
            int center = size / 2;
            int i = 0;
            Node<T> TempNode;
            TempNode = Head;
            while (i < center)
            {

                TempNode = TempNode.next;
                i++;
            }
            Console.WriteLine("Center {0}", TempNode.data);
        }
        //6.Peek
        public void Peek()
        {



            if (Head != null)
            {
                Console.WriteLine("Priority is {0} and element is {1} ", Head.priority, Head.data);
            }
            else
            {
                Console.WriteLine(" queue is empty");
            }


        }
        //5.Contains
        public bool Contains(T data)
        {
            Node<T> TempNode;
            TempNode = Head;
            while (TempNode != null)
            {

                if (TempNode.data.Equals(data))
                {
                    return true;
                }
                TempNode = TempNode.next;
            }
            return false;
        }
        //7.print
        public void Traverse()
        {
            Node<T> TempNode;
            TempNode = Head;
            while (TempNode != null)
            {
                Console.WriteLine("Priority is {0} and element is {1} ", TempNode.priority, TempNode.data);

                TempNode = TempNode.next;

            }
        }
        //8.reverse
        public void Reverse()
        {
            Node<T> NextNode = null;
            Node<T> PreviousNode = null;
            Node<T> TempNode = Head;
            Node<T> AnotherTempNode = Head;

            while (TempNode != null)
            {
                NextNode = TempNode.next;
                TempNode.next = PreviousNode;
                PreviousNode = TempNode;
                TempNode = NextNode;
            }
            Head = PreviousNode;
            Tail = AnotherTempNode;

        }
        // 9.iterator
        public IEnumerable<string> iterator()
        {
            Node<T> temp = Head;
            while (temp != null)
            {
                yield return "Priority is " + temp.priority.ToString() + " data is " + temp.data.ToString();
                temp = temp.next;
            }

        }




    }
}
