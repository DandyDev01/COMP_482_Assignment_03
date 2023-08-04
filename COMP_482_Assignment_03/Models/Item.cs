using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMP_482_Assignment_03.Utility;

namespace COMP_482_Assignment_03.Models
{
	public enum ItemCategory { Frozen, Baking, Spice, Chips, Pop, Candy, Vegitable, Fruit, Meat, Dry, Pets }

	public class Item
	{
		public string Name { get; set; }
		public string ID { get; set; }
		public string Price { get; set; }
		public string Brand { get; set; }
		public string Size { get; set; }
		public int Quantity { get; set; }
		public float RetailCost { get; set; }
		public float Cost { get; set; }
		public ItemCategory Category { get; set;  }
		public StoreDepartment Department { get; }

		public Item(string _name, string _id, string _price, string _brand, string _size, int _quantity, 
			float _retailCost, float _cost, ItemCategory _category, StoreDepartment _department)
		{
			Name = _name;
			ID = _id;
			Price = _price;
			Brand = _brand;
			Size = _size;
			Quantity = _quantity;
			RetailCost = _retailCost;
			Cost = _cost;
			Category = _category;
			Department = _department;
		}

		public Item()
		{
			Name = string.Empty;
			ID = string.Empty;
			Price = string.Empty;
			Brand = string.Empty;
			Size = string.Empty;
			Quantity = 0;
			RetailCost = 0;
			Cost = 0;
			Category = ItemCategory.Frozen;
			Department = StoreDepartment.Grocery;
		}
	}
}
