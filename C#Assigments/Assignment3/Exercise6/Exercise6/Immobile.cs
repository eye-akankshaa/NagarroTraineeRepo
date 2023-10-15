using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class Immobile : Equipment // Equipmemt id base class
    {
        private int distanceMoved;
        //Constructor
        public Immobile(string name, string description, double maintenanceCost)
            : base(name, description, maintenanceCost) // taking value from base class
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
