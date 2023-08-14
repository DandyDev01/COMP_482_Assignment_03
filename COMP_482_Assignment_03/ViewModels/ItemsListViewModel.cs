using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
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
	public class ItemsListViewModel : ObservableObject
	{
		private Item? selectedItem;
		public Item? SelectedItem
		{
			get
			{
				return selectedItem;
			}
			set
			{
				OnPropertyChanged(ref selectedItem, value);
			}
		}

		public ObservableCollection<Item> Items { get; }
		public ICollectionView ItemsCollectionView { get; }

		private bool any;
		public bool Any
		{
			get
			{
				return any;
			}
			set
			{
				OnPropertyChanged(ref any, value);
			}
		}

		private bool hasContextMenu;
		public bool HasContextMenu
		{
			get
			{
				return hasContextMenu;
			}
			set
			{
				OnPropertyChanged(ref hasContextMenu, value);
			}
		}

		public ICommand? AddItemsCommand { get; set; }
		public ICommand? RemoveItemsCommand { get; set; }	
		public ICommand NameSort { get; }
		public ICommand IDSort { get; }
		public ICommand BrandSort { get; }
		public ICommand SizeSort { get; }
		public ICommand QuantitySort { get; }
		public ICommand PriceSort { get; }
		public ICommand DepartmentSort { get; }
		public ICommand CategorySort { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;

		public ItemsListViewModel(bool _hasContextMenu = true)
		{
			hasContextMenu = _hasContextMenu;

			Items = new ObservableCollection<Item>();
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);
			selectedItem = Items.FirstOrDefault();
			Any = Items.Any();

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			Items.CollectionChanged += UpdateAny;

			NameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Name));
			IDSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.ID));
			BrandSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Brand));
			SizeSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Size));
			QuantitySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Quantity));
			PriceSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Price));
			DepartmentSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Department));
			CategorySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Category));
		}

		public ItemsListViewModel(Item[] items, bool _hasContextMenu = true)
		{
			hasContextMenu = _hasContextMenu;

			Items = new ObservableCollection<Item>(items);
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);
			selectedItem = Items.FirstOrDefault();
			Any = Items.Any();

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			Items.CollectionChanged += UpdateAny;

			NameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Name));
			IDSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.ID));
			BrandSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Brand));
			SizeSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Size));
			QuantitySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Quantity));
			PriceSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Price));
			DepartmentSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Department));
			CategorySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Category));
		}

		private void UpdateAny(object? sender, NotifyCollectionChangedEventArgs e)
		{
			Any = Items.Any();
		}


		public void Clear()
		{
			Items.Clear();
		}

		public void Populate(Item[] items)
		{
			Items.Clear();
			foreach (var item in items)
			{
				Items.Add(item);
			}
		}
	}
}
