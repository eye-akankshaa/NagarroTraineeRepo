using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class Equipment
    {

        private string name;
        private string description;
        private double distanceMoved;
        //Constructor
        public Equipment() { }
        // Constructor with arguments 
        public Equipment(string name, string description, double distanceMoved)
        {
            this.name = name;
            this.description = description;
            this.distanceMoved = distanceMoved;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double MaintenanceCost
        {
            get { return distanceMoved; }
            set { distanceMoved = value; }
        }
    }
}
