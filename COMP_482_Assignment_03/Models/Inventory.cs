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
			if (item == null) 
				return;

			items.Add(item);
		}

		public Item Remove(string ID)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrWhiteSpace(ID))
				return null;

			Item item = items.Where(x => x.ID == ID).FirstOrDefault();
			
			if (item == null) 
				return null;

			items.Remove(item);

			return item;
		}

		public Item Get(string ID)
		{
			if (string.IsNullOrEmpty(ID) || string.IsNullOrWhiteSpace(ID))
				return null;

			Item item = items.Where(x => x.ID == ID).FirstOrDefault();

			if (item == null)
				return null;

			return item;
		}

	}
}
