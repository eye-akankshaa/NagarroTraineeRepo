using System;
using System.Collections.Generic;


namespace Exercise7
{
    internal class Duck : IComparable<Duck>
    {
        static List<Duck> ducklist = new List<Duck>();
        public string Name { get; set; }
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }

        public Duck(string name, double weight, int numberOfWings)
        {
            Name = name;
            Weight = weight;
            NumberOfWings = numberOfWings;
        }

        //Comparing classes by their weight
        public int ComapreTo(Duck other)
        {
            return Weight.CompareTo(other.Weight);
        }


        //public override string ToString() 
        //{
        //    return &"Name: {Name}, Weight: {Weight},Number of wings: {NumberOfWings}";
        //}

        public int CompareTo(Duck other)
        {
            throw new NotImplementedException();
        }
    }

    

}
