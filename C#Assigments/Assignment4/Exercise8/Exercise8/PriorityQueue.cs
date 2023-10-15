using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise8
{
	class PriorityQueue<T> where T : IEquatable<T>
	{
		private IDictionary<int, IList<T>> elements;


		public PriorityQueue()
		{
			elements = new SortedDictionary<int, IList<T>>();
		}


		public int Count()
		{
			return elements.Count();
		}


		public bool Contains(T item)
		{
			foreach (KeyValuePair<int, IList<T>> pair in elements)
			{
				if (pair.Value.Contains(item))
					return true;
			}
			return false;
		}


		public T Dequeue()
		{
			IList<T> topPriorityList = elements[elements.Keys.First()];
			int priority = elements.Keys.First();
			T topElement = topPriorityList.First();
			topPriorityList.Remove(topElement);
			if (topPriorityList.Count() == 0)
			{
				elements.Remove(priority);
			}
			return topElement;
		}


		public void Enqueue(int priority, T item)
		{
			IList<T> list;
			if (!elements.ContainsKey(priority))
				elements.Add(priority, new List<T>());

			list = elements[priority];
			list.Add(item);
		}


		public T Peek()
		{
			IList<T> topPriorityList = elements[elements.Keys.First()];
			T topElement = topPriorityList.First();
			return topElement;
		}


		public int GetHighestPriority()
		{
			return elements.Keys.First();
		}
	}

}
