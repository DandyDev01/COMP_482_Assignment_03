using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.Commands;
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
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }ss
		public ICommand NameSort { get; }
		public ICommand IDSort { get; }
		public ICommand BrandSort { get; }
		public ICommand SizeSort { get; }
		public ICommand QuantitySort { get; }
		public ICommand DepartmentSort { get; }
		public ICommand CategorySort { get; }
		public ICommand BuyPriceSort { get; }
		public ICommand SellPriceSort { get; }

		public ObservableCollection<Item> Items { get; }
		public ICollectionView ItemsCollectionView { get; }
		public SelectItemsDataBase SelectItemsData { get { return selectItemsData; } }
		public readonly ObservableCollection<ObservableItem> ObservableItems;

		private ObservableItem? selectedItem;
		public ObservableItem? SelectedItem
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
				ItemsCollectionView.Refresh();
			}
		}

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly Window window;
		private readonly SelectItemsDataBase selectItemsData;

		public DialogWindowSelectedItemsViewModel(Window _window, SelectItemsDataBase _selectItemsData)
		{
			window = _window;
			selectItemsData = _selectItemsData;
			ObservableItems = selectItemsData.ItemsSource.GetObservableItems();

			Items = new ObservableCollection<Item>(selectItemsData.ItemsSource);
			ItemsCollectionView = CollectionViewSource.GetDefaultView(ObservableItems);
			
			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);
			searchTerm = string.Empty;

			ItemsCollectionView.Filter = Filter;
			ItemsCollectionView.SortDescriptions.Add(
				new SortDescription(nameof(selectedItem.Name), ListSortDirection.Ascending));

			SubmitCommand = new RelayCommand(Submit);
			CancelCommand = new RelayCommand(Cancel);
			NameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.Name));
			IDSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.ID));
			BrandSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.Brand));
			SizeSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.Size));
			QuantitySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.Quantity));
			DepartmentSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.Department));
			CategorySort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(selectedItem.Category));
			SellPriceSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.SellPrice));
			BuyPriceSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Item.BuyPrice));
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}

		private void Submit()
		{
			window.DialogResult = true;

			selectItemsData.ManipulateData(ObservableItems);
		}

		private bool Filter(object obj)
		{
			if (obj is ObservableItem observableItem)
			{

				if (searchTerm.Equals(string.Empty)) return true;

				if (observableItem.Item.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) return true;
			}

			return false;
		}
	}
}
