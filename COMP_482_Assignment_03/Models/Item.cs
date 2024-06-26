﻿using System;
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
		public string Brand { get; set; }
		public string Size { get; set; }
		public int Quantity { get; set; }
		public float SellPrice { get; set; }
		public float BuyPrice { get; set; }
		public ItemCategory Category { get; set;  }
		public StoreDepartment Department { get; set; }

		public Item(string _name, string _id, string _brand, string _size, int _quantity, 
			float _sellPrice, float _buyPrice, ItemCategory _category, StoreDepartment _department)
		{
			Name = _name;
			ID = _id;
			Brand = _brand;
			Size = _size;
			Quantity = _quantity;
			SellPrice = _sellPrice;
			BuyPrice = _buyPrice;
			Category = _category;
			Department = _department;
		}

		public Item()
		{
			Name = string.Empty;
			ID = string.Empty;
			Brand = string.Empty;
			Size = string.Empty;
			Quantity = 0;
			SellPrice = 0;
			BuyPrice = 0;
			Category = ItemCategory.Frozen;
			Department = StoreDepartment.Grocery;
		}
	}
}
