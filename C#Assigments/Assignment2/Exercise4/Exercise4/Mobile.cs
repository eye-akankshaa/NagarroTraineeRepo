using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise4
{
    
        //Derivied class Mobile

        public class Mobile : Equipment //Class Equipment is Base class
        {
            //Additional variable numberOfWheels for Mobile Equipments
            public int numberOfWheels;
            public override double MoveBy()//Method Overriding using override keyword
            {
                //Calcuation of Maintainance Cost
                double maintainance = numberOfWheels * Distance;
                this.MaintainanceCost = maintainance;
                return maintainance;
            }
            public override void Details() // to display Details of an Immobile Equipment
            {
                Console.WriteLine("Name : {0} ", Name);
                Console.WriteLine("Description : {0}", Description);
                Console.WriteLine(" Distance Moved Till Date : {0}", Distance);
                Console.WriteLine("Maintainance Cost : {0}", MaintainanceCost);
                Console.WriteLine("Type of Equipment : Mobile");
            }

            }
        }

    
