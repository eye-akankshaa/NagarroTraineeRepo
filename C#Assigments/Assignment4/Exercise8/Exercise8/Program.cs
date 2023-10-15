using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(1, 1);
            priorityQueue.Enqueue(2, 4);
            priorityQueue.Enqueue(3, 7);
            priorityQueue.Enqueue(0, 8);

            Console.WriteLine(priorityQueue.Peek());

            int eleRemoved=priorityQueue.Dequeue();
            Console.WriteLine("Dequed Ele :: {0}", eleRemoved);

            Console.WriteLine(priorityQueue.Peek());
        }
    }
}
