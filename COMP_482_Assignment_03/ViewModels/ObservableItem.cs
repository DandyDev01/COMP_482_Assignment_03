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

				BasicStringFieldValidation(nameof(Size), Size);
			}
		}

		private float sellPrice;
		public float SellPrice
		{
			get
			{
				return sellPrice;
			}
			set
			{
				OnPropertyChanged(ref sellPrice, value);
				Item.SellPrice = value;

				PriceValidation(sellPrice, buyPrice);
			}
		}

		private float buyPrice;
		public float BuyPrice
		{
			get
			{
				return buyPrice;
			}
			set
			{
				OnPropertyChanged(ref buyPrice, value);
				Item.BuyPrice = value;

				PriceValidation(sellPrice, buyPrice);
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

				QuantityValidation();
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
			sellPrice = Item.SellPrice;
			buyPrice = Item.BuyPrice;
			quantity = Item.Quantity;
			category = Item.Category;
			department = Item.Department;
			isSelected = false;

			propertyNameToError = new Dictionary<string, List<string>>();
			
			BasicStringFieldValidation(nameof(Name), Name);
			BasicStringFieldValidation(nameof(Brand), Brand);
			BasicStringFieldValidation(nameof(ID), ID);
			BasicStringFieldValidation(nameof(Size), Size);
			PriceValidation(SellPrice, BuyPrice);
			QuantityValidation();
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			return propertyNameToError.GetValueOrDefault(propertyName, new List<string>());
		}

		internal void InvokeError(string propertyName, string message)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			propertyNameToError[propertyName].Add(message);
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			IsValid = false;
		}

		private void BasicStringFieldValidation(string propertyName, string propertyValue)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			if (string.IsNullOrEmpty(propertyValue) || string.IsNullOrWhiteSpace(propertyValue))
			{
				propertyNameToError[propertyName].Add("Cannot be empty or white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (char.IsWhiteSpace(propertyValue.FirstOrDefault()))
			{
				propertyNameToError[propertyName].Add("Cannot start with white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (propertyNameToError[propertyName].Any() == false)
			{
				propertyNameToError.Remove(propertyName);
			}

			IsValid = !HasErrors;
		}

		private void PriceValidation(float sellPrice, float buyPrice)
		{
			propertyNameToError.Remove(nameof(SellPrice));
			propertyNameToError.Remove(nameof(BuyPrice));

			List<string> retailErrors = new List<string>();
			List<string> errors = new List<string>();

			propertyNameToError.Add(nameof(SellPrice), retailErrors);
			propertyNameToError.Add(nameof(BuyPrice), errors);
			
			
			if (sellPrice < buyPrice)
			{
				propertyNameToError[nameof(SellPrice)].Add("Must be greater than buy price");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(SellPrice)));

				propertyNameToError[nameof(BuyPrice)].Add("Must be less than sell price");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(BuyPrice)));
			}

			if (sellPrice < 0.01)
			{
				propertyNameToError[nameof(SellPrice)].Add("Must be at least 0.01");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(SellPrice)));
			}

			if (buyPrice < 0.01)
			{
				propertyNameToError[nameof(BuyPrice)].Add("Must be at least 0.01");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(BuyPrice)));
			}

			if (propertyNameToError[nameof(SellPrice)].Any() == false)
			{
				propertyNameToError.Remove(nameof(SellPrice));
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(SellPrice)));
			}

			if (propertyNameToError[nameof(BuyPrice)].Any() == false)
			{
				propertyNameToError.Remove(nameof(BuyPrice));
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(BuyPrice)));
			}

			IsValid = !HasErrors;
		}

		private void QuantityValidation()
		{
			propertyNameToError.Remove(nameof(Quantity));

			List<string> errors = new List<string>();
			propertyNameToError.Add(nameof(Quantity), errors);
			if (Quantity < 0)
			{
				propertyNameToError[nameof(Quantity)].Add("Cannot be less than 0");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Quantity)));
			}


			if (propertyNameToError[nameof(Quantity)].Any() == false)
			{
				propertyNameToError.Remove(nameof(Quantity));
			}

			IsValid = !HasErrors;
		}
	}
}
