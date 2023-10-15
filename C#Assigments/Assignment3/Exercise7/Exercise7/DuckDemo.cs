using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7
{
    public class DuckDemo
    {
        static List<Duck> ducklist = new List<Duck>();

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1. List all ducks:");
                Console.WriteLine("2. Add a duck");
                Console.WriteLine("3. Remove a duck");
                Console.WriteLine("4. Remove all ducks");
                Console.WriteLine("5. sort ducks by weight");
                Console.WriteLine("6. sort ducks by wings:");
                Console.WriteLine("0. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice try again");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("For exit:");
                        Environment.Exit(0);
                        break;
                    case 1:
                        ListAllDucks();
                        break;
                    case 2:
                        AddDuck();
                        break;
                    case 3:
                        RemoveDuck();
                        break;
                    case 4:
                        RemoveAllDuck();
                        break;
                    case 5:
                        SortByWeight();
                        break;
                    case 6:
                        sortducksbynumberofwings();
                        break;
                    default:
                        Console.WriteLine("Invalid choice please try again!");
                        break;
                }
            }
        }
        //1.
        static void ListAllDucks()
        {
            if (ducklist.Count == 0)
            {
                Console.WriteLine("No ducks is present");
                return;
            }
            foreach (var duck in ducklist)
            {
                Console.WriteLine($"Name:{duck.Name},Number of wings:{duck.NumberOfWings},Weight:{duck.Weight}");
            }
        }
        //2
        static void AddDuck()
        {
            Console.WriteLine("Name of duck:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter weight of duck");
            double weight;
            if (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("invalid weight");
                return;
            }
            Console.WriteLine("Enter the number of wings:");
            int numberOfWings;
            if (!int.TryParse(Console.ReadLine(), out numberOfWings))
            {
                Console.WriteLine("invalid number of wings:");
                return;
            }
            ducklist.Add(new Duck(name, weight, numberOfWings));
            Console.WriteLine("duck added successfully");
        }
        //3.
        static void RemoveDuck()
        {
            Console.WriteLine("Provide duck name which you want to remove");
            string name = Console.ReadLine();
            var duck = ducklist.FirstOrDefault(d => d.Name == name);

            if (duck == null)
            {
                Console.WriteLine("Duck not found:");
                return;
            }
            ducklist.Remove(duck);
            Console.WriteLine("Duck removed successfully");
        }
        //4.
        static void RemoveAllDuck()
        {
            ducklist.Clear();
            Console.WriteLine("All ducks removed Successfully");
        }

        //5.
        static void SortByWeight()
        {
            List<Duck> sortedDucks = ducklist.OrderBy(d => d.Weight).ToList();
            foreach (Duck duck in sortedDucks)
            {
                Console.WriteLine("weight:" + duck.Weight + ",Name: " + duck.Name + ",wings:" + duck.NumberOfWings);
            }
        }


        //6.
        static void sortducksbynumberofwings()
        {
            List<Duck> sortedDucks = ducklist.OrderBy(d => d.NumberOfWings).ToList();
            foreach (Duck duck in sortedDucks)
            {
                Console.WriteLine(",wings:" + duck.NumberOfWings + "weight:" + duck.Weight + ",Name: " + duck.Name);
            }
        }
    }

}
