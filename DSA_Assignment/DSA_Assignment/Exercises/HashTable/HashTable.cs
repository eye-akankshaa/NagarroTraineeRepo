using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignment.Exercises.HashTable
{
    // Class Node for Creating nodes for Table For HashTable.

    public class Node
    {
        public int value;
        public Node next;
        public int key;

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
            next = null;
        }
    }
    class HashTable
    {

        // Creating a list of Data type Node to store nodes for hashtable.

        public List<Node> Table;
        public int currentsize;
        public int tablesize;


        // Private method Rehash, in order to perform rehashing whenever value of loadbalancing is exceeded it's default value.

        void Rehash()
        {
            // Saving the prev. data to old table and then do insertions in new table.
            List<Node> oldTable = Table;
            int oldsize = tablesize;

            // Increasing table size.
            currentsize = 0;
            tablesize = 2 * tablesize + 1;

            Table = new List<Node>();

            for (int i = 0; i < tablesize; i++)
            {
                Table.Add(null);
            }

            // Copying Elements from old table to new table.

            for (int i = 0; i < oldsize; i++)
            {
                Node temp = oldTable[i];

                while (temp != null)
                {
                    int key = temp.key;
                    int value = temp.value;
                    Insert(key, value);
                    temp = temp.next;
                }

                // Emptying Old Table

                if (oldTable[i] != null)
                {
                    oldTable[i] = null;
                }
            }
            oldTable = null;
        }


        // Constructor Call to assign tablesize and currentsize and also to create a List of datatype Node. 

        public HashTable()
        {
            currentsize = 0;
            tablesize = 7;

            Table = new List<Node>();

            for (int i = 0; i < tablesize; i++)
            {
                Table.Add(null);
            }
        }

        // Creating HashTable

        public void CreateHashTable()
        {
            int number;
            Console.WriteLine("Enter the number of elements ");
            number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                int key, value;
                Console.WriteLine("Enter Key");
                key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter value");
                value = Convert.ToInt32(Console.ReadLine());
                Insert(key, value);

            }
        }


        // 1.Insert Method to insert key and value in hashtable

        public void Insert(int key, int value)
        {
            int index = key % tablesize;

            Node obj = new Node(key, value);
            obj.next = Table[index];
            Table[index] = obj;

            currentsize++;

            float loadbalance = currentsize / (float)tablesize;

            if (loadbalance > 0.7)
            {
                Rehash();
            }
        }

        // 2.Delete Method to remove key from hashtable.

        public void Delete(int key)
        {
            int index = key % tablesize;
            Table[index] = null;
        }

        // 3.Contains Bool Method to check whether key is present in hashtable or not.

        public bool Contains(int key)
        {
            int index = key % tablesize;
            Node temp = Table[index];

            while (temp != null)
            {
                if (temp.key == key)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }



        //4. GetValueByKey

        public void GetValueByKey(int key)
        {
            int index = key % tablesize;
            Node temp = Table[index];

            while (temp != null)
            {
                if (temp.key == key)
                {
                    Console.WriteLine("The value corresponding to given key is {0} :", temp.value);
                    break;
                }
                temp = temp.next;
            }

        }

        //5. Returns the current size (insertions) and total size of the hashtable .

        public void Size()
        {
            Console.WriteLine("Current Size - " + currentsize + " Total Size - " + tablesize);
        }




        //6.Print Method in order to print all the values associated with keys.

        public void Print()
        {
            // Iterating Over Buckets.

            for (int i = 0; i < tablesize; i++)
            {
                Console.Write("Bucket " + i + " -> ");
                Node temp = Table[i];

                while (temp != null)
                {
                    Console.Write(temp.value + " -> ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
        }











    }
}
