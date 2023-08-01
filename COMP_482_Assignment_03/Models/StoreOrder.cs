using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP_482_Assignment_03.ViewModels;

namespace COMP_482_Assignment_03.Models
{
	public enum OrderStatus { shipped, delivered };

	public class StoreOrder
	{
		public Item[] Items { get { return items.ToArray(); } }

		public string ID { get; }
		public float Cost { get; set; }
		public float Weight { get; set; }
		public string DataCreated { get; }
		public string DataLastModified { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public StoreDepartment Department { get; set; }

		private readonly List<Item> items;

		public StoreOrder()
		{
			Random random = new Random();

			ID = random.Next(10000, 99999).ToString();


			items = new List<Item>();
		}

		public void Clear()
		{
			items.Clear();
		}

		public void Add(Item item)
		{
			items.Add(item);
			Weight += 1;	
			Cost += item.Cost;
		}

		public void Remove(Item item)
		{
			items.Remove(item);
		}
	}
}
