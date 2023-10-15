using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.LinkedList
{
    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }

    }
    class LinkedList
    {

        public Node head;
        public LinkedList()
        {
            head = null;
        }

        //isEmpty 
        public bool isEmpty()
        {
            if (this.head == null)
                return true;
            return false;
        }
        //Size
        public int Size()
        {
            int size = 0;
            if (isEmpty())
                return 0;

            Node curr;
            curr = head;
            while (curr != null)
            {
                size++;
                curr = curr.next;
            }
            return size;
        }
        //Insert first
        public void InsertFirst(int element)
        {
            Node newest = new Node(element);
            if (isEmpty())
            {
                head = newest;
            }
            else
            {
                newest.next = head;
                head = newest;
            }
        }
        //Insert Last
        public void InsertLast(int element)
        {
            Node newest = new Node(element);
            if (isEmpty())
            {
                head = newest;
                return;
            }
            Node curr = head;
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = newest;

        }

        //Insert at any Position
        public void InsertAtPosition(int element, int position)
        {
            Node newest = new Node(element);
            Node curr = head;
            if (position < 1 || position > Size() + 1)
            {
                Console.WriteLine("Wrong Position ,Enter again");
                return;
            }
            if (position == 1)
            {
                InsertFirst(element);
                Console.WriteLine("Done First");
            }

            else
            {
                int i = 1;
                while (i < position - 1)
                {
                    curr = curr.next;
                    i++;
                }
                newest.next = curr.next;
                curr.next = newest;
            }
        }

        //Delete First
        public int DeleteFirst()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            else
            {
                int e = head.data;
                head = head.next;
                return e;
            }
        }

        //Delete Last
        public int DeleteLast()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            else
            {
                Node p = head;
                while (p.next.next != null)
                {
                    p = p.next;
                }
                int e = p.next.data;
                p.next = null;
                return e;
            }
        }

        //Delete at any Position
        public int DeleteAtPosition(int position)
        {
            if (position < 1 || position > Size())
            {
                return -1;
            }
            if (position == 1)
            {
                return DeleteFirst();

            }
            else
            {
                Node p = head;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i++;
                }
                int e = p.next.data;
                p.next = p.next.next;

                return e;
            }

        }
        //Reverse
        public void Reverse()
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
            }

            Node prev = null;
            Node current = head;

            while (current != null)
            {
                Node forw = current.next;
                current.next = prev;
                prev = current;
                current = forw;
            }
            head = prev;

        }
        //Center
        public int Center()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }


            Node fast = head;
            Node slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow.data;
        }
        //Sort
        public void Sort()
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
            }
            Node p = head;

            while (p.next != null)
            {
                Node q = p.next;
                while (q != null)
                {
                    if (p.data > q.data)
                    {
                        int temp = p.data;
                        p.data = q.data;
                        q.data = temp;
                        q = q.next;
                    }
                    else
                    {
                        q = q.next;
                    }
                }
                p = p.next;
            }
        }
        //Print LinkedList
        public void PrintLinkedList()
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
            }
            Node p;
            p = head;
            while (p != null)
            {
                Console.Write(p.data + "-->");
                p = p.next;
            }
        }


    }
    //Iterator
    class LinkListIterator
    {
        LinkedList list;
        public LinkListIterator(LinkedList list)
        {
            this.list = list;
        }
        public void nextElement()

        {
            Node curr = list.head;
            while (curr != null)
            {
                Console.WriteLine(curr.data);
                curr = curr.next;
            }
        }
    }

}
