using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class EquipmentDemo
    {

        public static void Run()
        {
            List<Equipment> equipment = new List<Equipment>();
            int input = -1;
            while (input != 12)
            {
                //display to user
                Console.WriteLine("1. Create an equipment.");
                Console.WriteLine("2. Delete an equipment.");
                Console.WriteLine("3. Move an equipment");
                Console.WriteLine("4. List all equipments.");
                Console.WriteLine("5. Show details.");
                Console.WriteLine("6. List all mobile equipments.");
                Console.WriteLine("7. List all Immobile equipments.");
                Console.WriteLine("8. List all equipments that haven't been moved till now.");
                Console.WriteLine("9. Delete all equipments.");
                Console.WriteLine("10. Delete all immobile equipments.");
                Console.WriteLine("11. Delete all mobile equipments.");
                Console.WriteLine("12. Quit");
                Console.Write("Provide User Input : ");
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("\nSelect correct menu item.\n");
                }
                else
                {
                    switch (input)
                    {
                        case 1://Create an equipment
                            createEquipment(equipment);
                            break;
                        case 2://Delete an Equipment
                            deleteEquipment(equipment);
                            break;
                        case 3:// to move equipment(for mobile only)
                            moveEquipment(equipment);
                            break;
                        case 4://list equipment
                            listAllEquipment(equipment);
                            break;
                        case 5://show details of equipment
                            showdetails(equipment);
                            break;
                        case 6:// list all mobile equipment
                            listAllMobileEquipment(equipment);
                            break;
                        case 7:// list immobile equipment
                            listAllImmobileEquipment(equipment);
                            break;
                        case 8:// equipment not been mooved till now
                            listAllEquipmentNotBeenMovedTillNow(equipment);
                            break;
                        case 9:
                            //Delete all equipment
                            equipment.Clear();
                            Console.WriteLine("\nAll equipments have been deleted.\n");
                            break;
                        case 10:
                            equipment.RemoveAll(e => e is Immobile);
                            Console.WriteLine("\nAll Immobile equipments have been deleted.\n");
                            break;
                        case 11:
                            equipment.RemoveAll(e => e is Mobile);
                            Console.WriteLine("\nAll Mobile equipments have been deleted.\n");
                            break;
                        case 12:
                            //exit
                            break;
                        default:
                            Console.WriteLine("\nSelect correct menu item.\n");
                            break;
                    }
                }
            }
        }

        /// Create an equipment method
        static void createEquipment(List<Equipment> equipment)
        {
            string name;
            string description;
            double maintenanceCost;
            int input;
            Console.WriteLine("1. Create mobile equipment");
            Console.WriteLine("2. Create immobile equipment");
            Console.Write("User Input : ");
            if (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 2)
            {
                Console.WriteLine("\nSelect correct menu item.\n");
            }
            else
            {
                Console.Write("Enter the name: ");
                name = Console.ReadLine();
                Console.Write("Enter the description: ");
                description = Console.ReadLine();
                Console.Write("Enter the maintenance cost: ");
                if (!double.TryParse(Console.ReadLine(), out maintenanceCost) || maintenanceCost < 0)
                {
                    Console.WriteLine("\nEnter correct the maintenance cost>0.\n");
                }
                if (input == 1)
                {
                    equipment.Add(new Mobile(name, description, maintenanceCost));
                    Console.WriteLine("\nA new Mobile equipment has been added\n");
                }
                if (input == 2)
                {
                    equipment.Add(new Immobile(name, description, maintenanceCost));
                    Console.WriteLine("\nA new Immobile equipment has been added.\n");
                }

            }


        }
        // Delete equipment method
        static void deleteEquipment(List<Equipment> equipment) // from class Equipment
        {
            if (equipment.Count > 0)
            {
                listAllEquipment(equipment);
                int selectedMobileEquipment = -1;
                Console.Write("Select the equipment: ");
                if (!int.TryParse(Console.ReadLine(), out selectedMobileEquipment) || selectedMobileEquipment < 0 || selectedMobileEquipment > equipment.Count)
                {
                    Console.WriteLine("\nSelect correct equipment.\n");
                }
                else
                {
                    equipment.RemoveAt(selectedMobileEquipment - 1);
                    Console.WriteLine("\nThe equipment have been deleted.\n");
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipment yet.");
            }
            Console.WriteLine();
        }
        /// Moving an equipment method
        static void moveEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                listAllEquipment(equipment);
                int selectedMobileEquipment = -1;
                Console.Write("Select the mobile equipment: ");

                if (!int.TryParse(Console.ReadLine(), out selectedMobileEquipment) || selectedMobileEquipment < 0 || selectedMobileEquipment > equipment.Count)
                {
                    Console.WriteLine("\nSelect correct mobile equipment.\n");
                }
                else
                {
                    if (equipment[selectedMobileEquipment - 1] is Mobile)
                    {
                        int distanceMoved;
                        Console.Write("Enter the distance to move mobile equipment: ");
                        if (!int.TryParse(Console.ReadLine(), out distanceMoved) || distanceMoved < 0)
                        {
                            Console.WriteLine("\nEnter correct the distance to move>0.\n");
                        }
                        else
                        {
                            ((Mobile)equipment[selectedMobileEquipment - 1]).DistanceMoved = distanceMoved;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSelect mobile equipment.\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        /// List all equipment
        static void listAllEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                Console.WriteLine("\n{0,-15}{1,-25}{2,-15}", "No", "Name", "Description");
                for (int i = 0; i < equipment.Count; i++)
                {
                    Console.WriteLine("{0,-15}{1,-25}{2,-15}", (i + 1), equipment[i].Name, equipment[i].Description);
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        /// Show details
        static void showdetails(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", "No", "Type", "Name", "Description", "Cost");
                for (int i = 0; i < equipment.Count; i++)
                {
                    string type = "Immobile";
                    if (equipment[i] is Mobile)
                    {
                        type = "Mobile";
                    }
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", (i + 1), type, equipment[i].Name, equipment[i].Description, equipment[i].MaintenanceCost);
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        /// List all mobile equipment
        static void listAllMobileEquipment(List<Equipment> equipments)
        {


            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}{5,-15}", "No", "Type", "Name", "Description", "Cost", "Distance moved");
                foreach (Equipment equipment in equipments.FindAll(e => e is Mobile))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}{5,-15}", (i + 1), "Mobile", equipment.Name, equipment.Description, equipment.MaintenanceCost, (((Mobile)equipment).DistanceMoved));
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        /// List all Immobile Equipment
        static void listAllImmobileEquipment(List<Equipment> equipments)
        {
            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", "No", "Type", "Name", "Description", "Cost");
                foreach (Equipment equipment in equipments.FindAll(e => e is Immobile))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", (i + 1), "Immobile", equipment.Name, equipment.Description, equipment.MaintenanceCost);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }
        ///  List all equipment that have not been moved till now
        static void listAllEquipmentNotBeenMovedTillNow(List<Equipment> equipments)
        {
            if (equipments.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", "No", "Type", "Name", "Description", "Cost");
                foreach (Equipment equipment in equipments.FindAll(e => e is Mobile && (((Mobile)e).DistanceMoved) == 0))
                {
                    Console.WriteLine("{0,-15}{1,-15}{2,-25}{3,-35}{4,-15}", (i + 1), "Mobile", equipment.Name, equipment.Description, equipment.MaintenanceCost);
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nYou have not added equipments yet.");
            }
            Console.WriteLine();
        }


    }
}
