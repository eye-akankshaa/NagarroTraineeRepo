using System;


namespace Exercise4
{
   public enum EquipmentType //Equipment Type
    {
        Mobile = 1,
        Immobile = 2,
    }

    
    //Base Class
   abstract public class Equipment
    {
        public string Name;
        public string Description;
        public double Distance;
        public double MaintainanceCost;
        public string typeOfEquipment;

        public Equipment()//Constructor setting initial value of Distance and MaintainanceCost
        {
            Distance = 0;
            MaintainanceCost = 0;
        }


        //virtual method t calculate MaintainanceCost

        public virtual double MoveBy()
        {
            return MaintainanceCost;
        }


        // Virtual Function MoveBy which is overrided by child classes.

        // <param name="distance"></param>

        public virtual void Details()
        {
            Console.WriteLine("Name : {0}, Description : {1}, Distance Moved Till Date : {2}, Maintainance Cost{3}", Name, Description, Distance, MaintainanceCost);
        }

    }
}


    