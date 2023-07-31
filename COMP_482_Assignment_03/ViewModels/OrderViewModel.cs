using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;


namespace COMP_482_Assignment_03.ViewModels
{
	public enum StoreDepartment { Grocery, Produce, Meat, Deliy, Bakery };
	
	public class OrderViewModel : ObservableObject
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

		public StoreOrder Order;

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly OrdersViewModel ordersVM;
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;

		public OrderViewModel(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;

			Items = new ObservableCollection<Item>();
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			Date = DateTime.Now.ToString();
			Order = new StoreOrder();
			orderTracker.Add(Order);

			AddItemsCommand = new SelectItemsCommand(new SelectItemsForOrderData(inventory, orderTracker, Items));
			RemoveItemsCommand = new SelectItemsCommand(new SelectItemsToRemoveData(orderTracker, Items));
			CreateCommand = new CreateOrderCommand(orderTracker, ordersVM, this);
		}
	}
}
