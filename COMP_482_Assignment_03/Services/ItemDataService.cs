using COMP_482_Assignment_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Services
{
	public class ItemDataService : IDataService<Item>
	{
		public List<Item> GetAll()
		{
			return new List<Item>
			{
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
				new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one),
			};
		}
	}
}
