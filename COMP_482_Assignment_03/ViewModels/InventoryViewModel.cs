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
		public ICommand EditItemCommand { get; }

		public ItemsListViewModel ItemsListVM { get; }
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

		private readonly ObservableCollection<ObservableItem> observableItems;

		public InventoryViewModel(Inventory _inventory, OrderTracker _orderTracker)
		{
			ItemsListVM = new ItemsListViewModel(_inventory.Items);
			selectedItem = ItemsListVM.Items[0];
			searchTerm = string.Empty;

			observableItems = _inventory.Items.GetObservableItems();

			Date = DateTime.Now.ToString();

			CreateItemCommand = new CreateItemCommand(_inventory, this);
			DeleteItemCommand = new SelectItemsCommand(new SelectItemsToRemoveFromInventoryData(_inventory, 
				ItemsListVM.Items));
			EditItemCommand = new EditItemCommand(_inventory, this);
		}
	}
}
