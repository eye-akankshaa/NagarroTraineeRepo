using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class Mobile : Equipment
    {
        private int distanceMoved;
        /// Constructor with arguments 
        public Mobile(string name, string description, double maintenanceCost)
            : base(name, description, maintenanceCost)
        {
            this.distanceMoved = 0; //Innitial value of distance moved is 0
        }
        public int DistanceMoved
        {
            get { return distanceMoved; }
            set { distanceMoved = value; }
        }
    }
}
