using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.ViewModels
{
	public class ObservableItem : ObservableObject, INotifyDataErrorInfo
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
				Item.Name = value;

				BasicStringFieldValidation(nameof(Name), Name);
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
				Item.ID = value;

				BasicStringFieldValidation(nameof(ID), ID);
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
				Item.Price = value;
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
				Item.Brand = value;
				BasicStringFieldValidation(nameof(Brand), Brand);
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
				Item.Size = value;
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
				Item.RetailCost = value;
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
				Item.Cost = value;
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
				Item.Quantity = value;
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
				Item.Category = value;
			}
		}

		private StoreDepartment department;
		public StoreDepartment Department
		{
			get
			{
				return department;
			}
			set
			{
				OnPropertyChanged(ref department, value);
			}
		}

		private bool isSelected;
		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				OnPropertyChanged(ref isSelected, value);
			}
		}

		private bool isValid;
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				OnPropertyChanged(ref isValid, value);
			}
		}

		public Item Item { get; }

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		private readonly Dictionary<string, List<string>> propertyNameToError;

		public ObservableItem(Item _item)
		{
			Item = _item;

			name = Item.Name;
			id = Item.ID;
			price = Item.Price;
			brand = Item.Brand;
			size = Item.Size;
			retailCost = Item.RetailCost;
			cost = Item.Cost;
			quantity = Item.Quantity;
			category = Item.Category;
			department = Item.Department;
			isSelected = false;

			propertyNameToError = new Dictionary<string, List<string>>();
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			return propertyNameToError.GetValueOrDefault(propertyName, new List<string>());
		}

		private void BasicStringFieldValidation(string propertyName, string propertyValue)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			if (string.IsNullOrEmpty(propertyValue) || string.IsNullOrWhiteSpace(propertyValue))
			{
				propertyNameToError[propertyName].Add("Name cannot be empty or white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (char.IsWhiteSpace(propertyValue.FirstOrDefault()))
			{
				propertyNameToError[propertyName].Add("Name start with white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (propertyNameToError[propertyName].Any() == false)
			{
				propertyNameToError.Remove(propertyName);
			}

			IsValid = !HasErrors;
		}
	}
}
