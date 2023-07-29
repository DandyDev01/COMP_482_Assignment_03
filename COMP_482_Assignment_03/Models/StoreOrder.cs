using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class StoreOrder
	{
		public Item[] Items { get { return items.ToArray(); } }

		private readonly List<Item> items;

		public StoreOrder()
		{
			items = new List<Item>();
		}

		public void Add(Item item)
		{
			items.Add(item);	
		}

		public void Remove(Item item)
		{
			items.Remove(item);
		}
	}
}
