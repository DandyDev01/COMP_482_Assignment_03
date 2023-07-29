using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class StoreOrder
	{
		private readonly List<Item> items;

		public StoreOrder()
		{
			items = new List<Item>();
		}

		public void Add(Item item)
		{
			items.Add(item);	
		}
	}
}
