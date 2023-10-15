using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise15
{
    public class ObservableDemo
    {
        public static void Run()
        {
            MyCollection myCollection = new MyCollection();
            myCollection.Add("item 1");
            myCollection.Add("item 2");
            myCollection.Add("item 3");
            myCollection.Remove("item 1");
        }
    }


}
