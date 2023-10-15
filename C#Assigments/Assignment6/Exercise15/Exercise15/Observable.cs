using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Exercise15
{
    public enum CollectionChangedAction
    {
        Add,
        Remove
    };

    public class MyCollection : ObservableCollection<string>
    {
        public MyCollection()
        {
            //Delegate added to event CollectionChanged
            CollectionChanged += MyCollection_CollectionChanged;
        }

        private void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)

        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine($"Element '{item}' is added to collection");

                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine($"Element '{item}' is Removed from collection");
                }
            }
        }
    }

    

}
