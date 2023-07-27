using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.ViewModels
{
	public class ObservableItem : ObservableObject
	{
		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				OnPropertyChanged(ref name, value);
				item.Name = value;
			}
		}

		private string id;
		public string ID
		{
			get
			{
				return id;
			}
			set
			{
				OnPropertyChanged(ref id, value);
				item.ID = value;
			}
		}

		private string price;
		public string Price
		{
			get
			{
				return price;
			}
			set
			{
				OnPropertyChanged(ref price, value);
				item.Price = value;
			}
		}

		private string brand;
		public string Brand
		{
			get
			{
				return brand;
			}
			set
			{
				OnPropertyChanged(ref brand, value);
				item.Brand = value;
			}
		}

		private string size;
		public string Size
		{
			get
			{
				return size;
			}
			set
			{
				OnPropertyChanged(ref size, value);
				item.Size = value;
			}
		}

		private float retailCost;
		public float RetailCost
		{
			get
			{
				return retailCost;
			}
			set
			{
				OnPropertyChanged(ref retailCost, value);
				item.RetailCost = value;
			}
		}

		private float cost;
		public float Cost
		{
			get
			{
				return cost;
			}
			set
			{
				OnPropertyChanged(ref cost, value);
				item.Cost = value;
			}
		}

		private int quantity;
		public int Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				OnPropertyChanged(ref quantity, value);
				item.Quantity = value;
			}
		}

		private ItemCategory category;
		public ItemCategory Category
		{
			get
			{
				return category;
			}
			set
			{
				OnPropertyChanged(ref category, value);
				item.Category = value;
			}
		}

		private Item item;

		public ObservableItem(Item _item)
		{
			item = _item;
			name = item.Name;
			id = item.ID;
			price = item.Price;
			brand = item.Brand;
			size = item.Size;
			retailCost = item.RetailCost;
			cost = item.Cost;
			quantity = item.Quantity;
			category = item.Category;
		}
	}
}
