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
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public ObservableCollection<Item> Items { get; }
		public ICollectionView ItemsCollectionView { get; }
		public SelectItemsDataBase SelectItemsData { get { return selectItemsData; } }
		public readonly ObservableCollection<ObservableItem> ObservableItems;

		private ObservableItem selectedItem;
		public ObservableItem SelectedItem
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

			SubmitCommand = new RelayCommand(Submit);
			CancelCommand = new RelayCommand(Cancel);
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
	}
}
