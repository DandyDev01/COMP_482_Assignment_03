using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;


namespace COMP_482_Assignment_03.ViewModels
{
	public enum StoreDepartment { Grocery, Produce, Meat, Deliy, Bakery };
	
	public class OrderViewModel : ObservableObject, INotifyDataErrorInfo
	{
		public ICommand AddItemsCommand { get; }
		public ICommand RemoveItemsCommand { get; }
		public ICommand CancelCommand { get; }
		public ICommand CreateCommand { get; }

		private string date;
		public string Date
		{
			get
			{
				return date;
			}
			set
			{
				OnPropertyChanged(ref date, value);
			}
		}

		public ObservableCollection<Item> Items { get; }
		public ICollectionView ItemsCollectionView { get; }

		public Array Departments { get; } = Enum.GetValues(typeof(StoreDepartment));

		private StoreDepartment selectedDepartment;
		public StoreDepartment SelectedDepartment
		{
			get
			{
				return selectedDepartment;
			}
			set
			{
				OnPropertyChanged(ref selectedDepartment, value);
			}
		}

		private string errors;
		public string Errors
		{
			get
			{
				return errors;
			}
			set
			{
				OnPropertyChanged(ref errors, value);
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

		public StoreOrder Order;

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly OrdersViewModel ordersVM;
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly Dictionary<string, List<string>> propertyNameToError;

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		public OrderViewModel(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;
			propertyNameToError = new Dictionary<string, List<string>>();
			isValid = false;

			Items = new ObservableCollection<Item>();
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			Date = DateTime.Now.ToString();
			Order = new StoreOrder();
			orderTracker.Add(Order);

			AddItemsCommand = new SelectItemsCommand(new SelectItemsForOrderData(inventory, orderTracker, Items));
			RemoveItemsCommand = new SelectItemsCommand(new SelectItemsToRemoveFromOrderData(orderTracker, Items));
			CreateCommand = new CreateOrderCommand(orderTracker, ordersVM, this);
			CancelCommand = new ClearOrderCommand(orderTracker, ordersVM, this);

			Items.CollectionChanged += Validate;

			Validate(null, null);
		}

		private void Validate(object? sender, NotifyCollectionChangedEventArgs e)
		{
			propertyNameToError.Remove(nameof(ItemsCollectionView));

			List<string> errors = new List<string>();
			propertyNameToError.Add(nameof(ItemsCollectionView), errors);
			if (Items.Count <= 0)
			{
				propertyNameToError[nameof(ItemsCollectionView)].Add("Order must have at least 1 item");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(ItemsCollectionView)));
			}

			if (propertyNameToError[nameof(ItemsCollectionView)].Any() == false)
			{
				propertyNameToError.Remove(nameof(ItemsCollectionView));
				Errors = string.Empty;
			}

			foreach (string error in GetErrors(nameof(ItemsCollectionView)))
			{
				Errors += error + "\r\n";
			}

			IsValid = !HasErrors;
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			return propertyNameToError.GetValueOrDefault(propertyName, new List<string>());
		}
	}
}
