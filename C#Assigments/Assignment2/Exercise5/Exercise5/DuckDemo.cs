using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class DuckDemo
    {
        public static void Run()
        {
            // Create a rubber duck
            IDuck rubberDuck = new RubberDuck
            {
                Weight = 0.5,
                NumberOfWings = 0 // A rubber duck has no wings
            };

            // Create a mallard duck
            IDuck mallardDuck = new MallardDuck
            {
                Weight = 1.5,
                NumberOfWings = 2
            };

            // Create a redhead duck
            IDuck redheadDuck = new RedheadDuck
            {
                Weight = 1.0,
                NumberOfWings = 2
            };

            // Show the details of the ducks
            rubberDuck.ShowDetails();
            rubberDuck.Fly();
            rubberDuck.Quack();

            Console.WriteLine();

            mallardDuck.ShowDetails();
            mallardDuck.Fly();
            mallardDuck.Quack();
            Console.WriteLine();

            redheadDuck.ShowDetails();
            redheadDuck.Fly();
            redheadDuck.Quack();
        }
    }
}
