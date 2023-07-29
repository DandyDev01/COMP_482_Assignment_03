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
	public class InventoryViewModel : ObservableObject
	{
		public ICommand CreateItemCommand { get; }
		public ICommand DeleteItemCommand { get; }

		public ObservableCollection<Item> Items { get; }
		public ICollectionView ItemsCollectionView { get; }
		public string Date { get; }

		private Item selectedItem;
		public Item SelectedItem
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
		private readonly ObservableCollection<ObservableItem> observableItems;

		public InventoryViewModel(Inventory _inventory)
		{
			Items = new ObservableCollection<Item>(_inventory.Items);
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);
			observableItems = _inventory.Items.GetObservableItems();

			Date = DateTime.Now.ToString();

			CreateItemCommand = new CreateItemCommand(_inventory, this);
			DeleteItemCommand = new DeleteItemCommand(_inventory, this);
		}
	}
}
