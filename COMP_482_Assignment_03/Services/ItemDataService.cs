using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
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
			// name id price brand size quantity retailCost cost cat dep
			return new List<Item>
			{
				new Item("Fries", "00000", "Fry Company 1", "100g", 20, 5.99f, 2.99f, 
					ItemCategory.Frozen, StoreDepartment.Grocery),

				new Item("Steak", "00010", "Steak Man", "100g", 15, 6.99f, 3.99f, 
					ItemCategory.Meat, StoreDepartment.Meat),

				new Item("Banana", "00023", "Fresh Fuit", "200g", 45, 2.99f, 1.49f, 
					ItemCategory.Fruit, StoreDepartment.Produce),

				new Item("Sweet & Salty bar", "03432", "Nature Bar", "525g", 23, 6.00f, 3.00f, 
					ItemCategory.Dry, StoreDepartment.Grocery),

				new Item("Dog Food", "23421", "Foods for Pets", "1kg", 12, 7.89f, 4.49f, 
					ItemCategory.Pets, StoreDepartment.Grocery),

				new Item("Cat Food", "23451", "Foods for Pets", "1kg", 10, 7.89f, 4.49f, 
					ItemCategory.Pets, StoreDepartment.Grocery),

				new Item("Fish", "0882123", "Fishermans Ship", "150g", 7, 10.00f, 5.00f, 
					ItemCategory.Meat, StoreDepartment.Meat),

				new Item("Gala Apples", "54363456", "The Apple Company", "25g", 1000, 0.060f, 0.40f, 
					ItemCategory.Fruit, StoreDepartment.Produce),

				new Item("Celery", "234208", "Produce-man", "200g", 50, 1.00f, 0.50f, 
					ItemCategory.Vegitable, StoreDepartment.Produce),

				new Item("Potatoe Chip", "7985342", "Layers", "400g", 34, 4.99f, 2.49f, 
					ItemCategory.Chips, StoreDepartment.Grocery),

				new Item("Candy Peaches", "36548976", "Candy Land", "30g", 32, 3.99f, 2.99f, 
					ItemCategory.Candy, StoreDepartment.Grocery),

				new Item("White Bread", "352489", "Bread Makers", "100g", 12, 1.99f, 0.99f, 
					ItemCategory.Baking, StoreDepartment.Bakery),

				new Item("Whole Grain Bread", "349857", "Bread Makers", "100g", 8, 2.99f, 1.49f, 
					ItemCategory.Baking, StoreDepartment.Bakery),

				new Item("Steak Spice", "534098", "Spicers", "100g", 0, 1.99f, 0.89f, 
					ItemCategory.Spice, StoreDepartment.Grocery),

				new Item("Chicken Spice", "09834", "Spicers", "100g", 0, 1.99f, 0.89f,
					ItemCategory.Spice, StoreDepartment.Grocery),

				new Item("Pretzels", "09902132", "Dough Makers", "300g", 34, 5.00f, 3.00f, 
					ItemCategory.Chips, StoreDepartment.Grocery),
			};
		}
	}
}
