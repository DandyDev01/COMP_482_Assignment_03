using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class Inventory
	{
		public Item[] Items { get { return items.ToArray(); } }

		private readonly List<Item> items;

		public Inventory(Item[] _items)
		{
			items = _items.ToList();
		}

		public void Add(Item item)
		{
			// data validation should already be done
			// do a null check
		}

		public Item Remove(string ID)
		{
			return null;
		}

		public Item Get(string ID)
		{
			return null;
		}

	}
}
