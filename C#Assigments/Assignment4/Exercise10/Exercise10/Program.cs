using System;

namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue3<int> priorityQueue3 = new PriorityQueue3<int>();
            priorityQueue3.Enqueue(10, 1);
            priorityQueue3.Enqueue(2, 4);
            priorityQueue3.Enqueue(20, 7);

            Console.WriteLine(priorityQueue3.Peek());

            int eleRemoved= priorityQueue3.Dequeue();
            Console.WriteLine("Element removed :: {0}",eleRemoved);

            Console.WriteLine(priorityQueue3.Peek());
        }
    }
}
