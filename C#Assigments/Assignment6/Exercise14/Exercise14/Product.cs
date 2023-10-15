using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise14
{
    class Product : IEquatable<int>
    {
        private int id;
        private float price;
        private bool isDefective;
        public Product() { }

        public Product(int id, float price, bool isDefective)
        {
            this.id = id;
            this.price = price;
            this.isDefective = isDefective;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public bool IsDefective
        {
            get { return isDefective; }
            set { isDefective = value; }
        }
        public bool Equals(int id)
        {
            return this.id == id;
        }
    }

}
