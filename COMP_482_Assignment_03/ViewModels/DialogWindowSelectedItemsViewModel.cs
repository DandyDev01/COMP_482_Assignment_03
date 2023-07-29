using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class DialogWindowSelectedItemsViewModel : ObservableObject
	{
		public ICommand AddCommand { get; }
		public ICommand CancelCommand { get; }

		public ObservableCollection<Item> Items { get; }
		public ICollectionView ItemsCollectionView { get; }

		private string searchTerm;
		public string SearchTerm
		{
			get
			{
				return searchTerm;
			}
			set
			{
				OnPropertyChanged(ref searchTerm, value);
			}
		}

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly ObservableCollection<ObservableItem> observableItems;
		private readonly Window window;
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly ObservableCollection<Item> items;

		public DialogWindowSelectedItemsViewModel(Window _window, Inventory _inventory, OrderTracker _orderTracker, 
			ObservableCollection<Item> _items)
		{
			window = _window;
			inventory = _inventory;
			orderTracker = _orderTracker;
			items = _items;

			observableItems = _inventory.Items.GetObservableItems();

			Items = new ObservableCollection<Item>(_inventory.Items);
			ItemsCollectionView = CollectionViewSource.GetDefaultView(observableItems);
			
			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);
			searchTerm = string.Empty;

			AddCommand = new RelayCommand(Add);
			CancelCommand = new RelayCommand(Cancel);
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}

		private void Add()
		{
			window.DialogResult = true;

			StoreOrder order = orderTracker.Last;

			List<ObservableItem> selectedItems = observableItems.Where(x => x.IsSelected).ToList();
			foreach (ObservableItem observableItem in selectedItems)
			{
				order.Add(observableItem.Item);
				items.Add(observableItem.Item);
			}
		}
	}
}
