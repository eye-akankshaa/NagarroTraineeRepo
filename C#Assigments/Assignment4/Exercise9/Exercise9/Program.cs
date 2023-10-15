using System;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue2<int> pq = new PriorityQueue2<int>();

            //Enque Operation
            //setting priority with Property
            pq.Priority = 5;
            pq.Enqueue(10);
            pq.Enqueue(30);
            pq.Priority = 1;
            pq.Enqueue(90);

            pq.Priority = 10;
            pq.Enqueue(60);
            pq.Enqueue(88);
            pq.Priority = 6;
            pq.Enqueue(72);

            //peek()
            Console.WriteLine(pq.Peek());

            //contain
            Console.WriteLine(pq.Contains(10));

            //Deque
            Console.WriteLine(pq.Dequeue());

            //count
            Console.WriteLine(pq.Count);

            //Get Highest Priority
            Console.WriteLine(pq.GetHighestPriority());

            Console.ReadLine();
        }
    }
}
