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

		public ICommand NameSort { get; }
		public ICommand IDSort { get; }
		public ICommand BrandSort { get; }
		public ICommand SizeSort { get; }
		public ICommand QuantitySort { get; }
		public ICommand PriceSort { get; }
		public ICommand DepartmentSort { get; }
		public ICommand CategorySort { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;

		public ItemsListViewModel()
		{
			Items = new ObservableCollection<Item>();
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);
			selectedItem = Items.FirstOrDefault();

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			NameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Name));
			IDSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.ID));
			BrandSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Brand));
			SizeSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Size));
			QuantitySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Quantity));
			PriceSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Price));
			DepartmentSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Department));
			CategorySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Category));
		}

		public ItemsListViewModel(Item[] items)
		{
			Items = new ObservableCollection<Item>(items);
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);
			selectedItem = Items.FirstOrDefault();

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			NameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Name));
			IDSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.ID));
			BrandSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Brand));
			SizeSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Size));
			QuantitySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Quantity));
			PriceSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Price));
			DepartmentSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Department));
			CategorySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.Category));
		}
	}
}
