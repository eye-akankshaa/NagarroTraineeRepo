using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class EquipmentDemo
    {

        public static void Run()
        {
            //Taking user Input
            Console.WriteLine("Entry Required : Press m for mobile equiptments and i for immobile equipments");

            string input = Console.ReadLine();
            if (input == "m" || input == "M") //If this condition satisfies then Equipment is set to Mobile
            {
                //user input required for details

                var mobileEquipment = new Mobile();

                Console.WriteLine("Name of Equiptment : ");

                mobileEquipment.Name = Console.ReadLine();

                Console.WriteLine("Description of Equiptment");

                mobileEquipment.Description = Console.ReadLine();

                Console.WriteLine("Distance Travelled b Equiptment");

                mobileEquipment.Distance = Double.Parse(Console.ReadLine());

                Console.WriteLine("Number of Wheels: ");

                mobileEquipment.numberOfWheels = int.Parse(Console.ReadLine());

                //Calling method to calculate maintainanceCost and printing Details
                double maintainance = mobileEquipment.MoveBy();

                Console.WriteLine("Maintainance cost is {0}", maintainance);

                Console.WriteLine();
                mobileEquipment.Details();


            }

            else if (input == "i" || input == "I")//If this condition satisfies then Equipment is set to Immobile
            {
                //user input required for details
                var immobileEquipment = new Immobile();
                Console.WriteLine("Name of Equiptment : ");

                immobileEquipment.Name = Console.ReadLine();
                Console.WriteLine("Description of Equiptment");

                immobileEquipment.Description = Console.ReadLine();
                Console.WriteLine("Distance Travelled by Equiptment");

                immobileEquipment.Distance = Double.Parse(Console.ReadLine());
                Console.WriteLine("Weight of Equipment");

                immobileEquipment.weight = Double.Parse(Console.ReadLine());

                //Calling method to calculate maintainanceCost and printing Details
                double maintain = immobileEquipment.MoveBy();

                Console.WriteLine("Maintainance cost is {0}", maintain);

                Console.WriteLine();

                immobileEquipment.Details();
            }
        }

    }
}    

