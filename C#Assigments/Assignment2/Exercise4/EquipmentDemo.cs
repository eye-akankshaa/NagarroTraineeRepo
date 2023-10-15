using System;
public class EquipmentDemo
{
    static List<Equipment> inventory = new List<Equipment>();
    
    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("Select an operation from all the options:");
            Console.WriteLine("1. Create an Equipment");
            Console.WriteLine("2. Delete an Equipment");
            Console.WriteLine("3. Move Equipment");
            Console.WriteLine("4. List All equipment");
            Console.WriteLine("5. show details of equipment");
            Console.WriteLine("6. List all mobile equipment:");
            Console.WriteLine("7. list all immobile equipment:");
            Console.WriteLine("8. list all eqipment that have not moved till now");
            Console.WriteLine("9. Delete all equipment:");
            Console.WriteLine("10. Delete all Mobile Equipment");
            Console.WriteLine("11. Delete all Immbobile Equipment");
            Console.WriteLine("press 0 for exit");

            int choice;

            if (int.TryParse(Console.ReadLine(), out choice))
            {

                switch (choice)
                {
                    case 1:
                        CreateEquipment();
                        break;
                    case 2:
                        DeleteAnEquipment();
                        break;
                    case 3:
                        MoveEquipment();
                        break;
                    case 4:
                        ListAllEquipment();
                        break;
                    case 5:
                        ShowEquipmentDetails();
                        break;
                    case 6:
                        ListMobileEquipment();
                        break;
                    case 7:
                        ListImmobileEquipment();
                        break;
                    case 8:
                        ListNotMovedEquipment();
                        break;
                    case 9:
                        DeleteAllEquipment();
                        break;
                    case 10:
                        DeleteImmobileEquipment();
                        break;
                    case 11:
                        DeleteMobileEquipment();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You enter Invalid Choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
            Console.WriteLine();
        }

    }
    static void CreateEquipment()
    {
        Console.WriteLine("Enter equipment name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter description");
        string description = Console.ReadLine();

        Console.WriteLine("press Y for mobile equipment(Y/N:");
        bool isMobile = Console.ReadLine().ToUpper() == "Y";


        Equipment equipment = new Equipment
        {
            Name = name,
            Description = description,
            IsMobile = isMobile
        };
        inventory.Add(equipment);
        Console.WriteLine("equipment created successfully:");
    }

    static void DeleteAnEquipment()
    {
        Console.WriteLine("Enter equipment name:");
        string name = Console.ReadLine();

        Equipment equipment = inventory.FirstOrDefault(x => x.Name == name);

        if (equipment == null)
        {
            Console.WriteLine("equipment not found");
            return;
        }
        inventory.Remove(equipment);
        Console.WriteLine("Equipment deleted successfully:");
    }

    static void MoveEquipment()
    {
        Console.WriteLine("Name of the equipment which you want to move:");
        string name = Console.ReadLine();

        Equipment equipment = inventory.FirstOrDefault(e => e.Name == name);

        if (equipment != null)
        {
            if (equipment.IsMobile)
            {
                // ((MobileEquipment)equipment).NoOfWheels
                Console.WriteLine("Enter the distance which you want to move:");
                double distance;
                if (double.TryParse(Console.ReadLine(), out distance))
                {
                    equipment.DistanceMoved += distance;

                    Console.WriteLine("moved successfully:");
                }
                else
                {
                    Console.WriteLine("invalid distance:");
                }
            }
            else
            {
                Console.WriteLine("we can't move immobile equipment:");
            }

        }

    }
    //4.Only name and description
    static void ListAllEquipment()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No equipment found!");
            return;
        }
        foreach (Equipment equipment in inventory)
        {
            Console.WriteLine("Name: " + equipment.Name + " Description: " + equipment.Description);
        }
    }

    //5. show all details
    static void ShowEquipmentDetails()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No equipment found!");
            return;
        }
        foreach (Equipment equipment in inventory)
        {
            Console.WriteLine("Name: " + equipment.Name + " Description: " + equipment.Description);
            Console.WriteLine("MovedDistance = " + equipment.DistanceMoved + " Maintenance cost = " + equipment.CostOfMaintenance);
        }
    }

    //6. List only mobile equipment
    static void ListMobileEquipment()
    {
        List<Equipment> mobEquip = inventory.Where(e => e.IsMobile).ToList();

        if (mobEquip.Count == 0)
        {
            Console.WriteLine("No mobile equipment is available:");
            return;
        }
        foreach (Equipment equipment in mobEquip)
        {
            Console.WriteLine(equipment);
        }
    }

    //7. List all immobile equipment
    static void ListImmobileEquipment()
    {
        List<Equipment> mobEquip1 = inventory.Where(e => !e.IsMobile).ToList();

        if (mobEquip1.Count == 0)
        {
            Console.WriteLine("No mobile equipment is available:");
            return;
        }
        foreach (Equipment equipment in mobEquip1)
        {
            Console.WriteLine(equipment);
        }
    }
    //8. List not moved equipment
    static void ListNotMovedEquipment()
    {
        List<Equipment> notMovedEquipment = inventory.Where(e => e.DistanceMoved == 0).ToList();

        if (notMovedEquipment.Count == 0)
        {
            Console.WriteLine(" equipment has been moved");
            return;
        }
        foreach (Equipment equipment in notMovedEquipment)
        {
            Console.WriteLine(equipment);
        }

    }

    static void DeleteAllEquipment()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No equipment is present");
            return;
        }
        inventory.Clear();
        Console.WriteLine("All equipment is deleted successfully:");
    }

    static void DeleteImmobileEquipment()
    {
        int deletedMobile = inventory.RemoveAll(inventory => inventory.IsMobile);

        if (deletedMobile == 0)
        {
            Console.WriteLine("No mobile equipment is found for delettion:");
            return;
        }
        Console.WriteLine(deletedMobile + "Mobile equipment is deleted successflly");
    }

    static void DeleteMobileEquipment()
    {
        int deletedImmobile = inventory.RemoveAll(inventory => !inventory.IsMobile);

        if (deletedImmobile == 0)
        {
            Console.WriteLine("No mobile equipment is found for delettion:");
            return;
        }
        Console.WriteLine(deletedImmobile + "Mobile equipment is deleted successflly");
    }
}
}


