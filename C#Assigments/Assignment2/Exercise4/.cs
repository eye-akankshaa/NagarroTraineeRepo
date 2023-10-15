using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise4
{
    public class Equipment
    {
        //Setting auto implied properties
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMobile { get; set; }
        public double DistanceMoved { get; set; }
        public double CostOfMaintenance { get; set; }

        //ToString method used so that object printed is understandable not in hashcodes
        public override string ToString()
        {
            return $"Name:{Name}, Description:{Description}";
        }
    }

    