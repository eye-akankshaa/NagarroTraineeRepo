using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    enum DuckType
    {
        Rubber,
        Mallard,
        Redhead
    }

    interface IDuck
    {
        double Weight { get; set; }

        int NumberOfWings { get; set; }
        DuckType Type { get; set; }

        void Fly();
        void Quack();
        void ShowDetails();
    }

    class RubberDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType Type { get; set; } = DuckType.Rubber;

        public void Fly()
        {
            Console.WriteLine("I'm a rubber duck. I can't fly.");
        }

        public void Quack()
        {
            Console.WriteLine("Squeak! Squeak!");
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Number of wings: {NumberOfWings}");
           
        }
    }

    class MallardDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType Type { get; set; } = DuckType.Mallard;

        public void Fly()
        {
            Console.WriteLine("I'm a mallard duck. I fly fast!");
        }

        public void Quack()
        {
            Console.WriteLine("Quack! Quack! Quack!");
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Number of wings: {NumberOfWings}");
           
        }
    }

    class RedheadDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType Type { get; set; } = DuckType.Redhead;

        public void Fly()
        {
            Console.WriteLine("I'm a redhead duck. I fly slow.");
        }

        public void Quack()
        {
            Console.WriteLine("Quack! Quack!");
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Number of wings: {NumberOfWings}");
        }
    }

    
}


