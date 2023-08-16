using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Models.SelectedItemsData
{
	public class SelectItemForEditData : SelectItemsDataBase
	{
		public Item[] ItemsSource => inventory.Items.ToArray();

		private readonly Inventory inventory;
		private readonly InventoryViewModel InventoryVM;

		public SelectItemForEditData(Inventory _inventory, InventoryViewModel _InventoryVM)
		{
			inventory = _inventory;
			InventoryVM = _InventoryVM;
		}

		public bool ManipulateData(ObservableCollection<ObservableItem> itemsToSelectFrom)
		{
			List<ObservableItem> selectedItems = itemsToSelectFrom.Where(x => x.IsSelected).ToList();

			if (selectedItems.Count > 1)
			{
				MessageBox.Show("more than one item is selcted", "to many items selected", 
					MessageBoxButton.OK, MessageBoxImage.Error);

				return false;
			}

			if (selectedItems.FirstOrDefault() != null)
				InventoryVM.ItemsListVM.SelectedItem = selectedItems.FirstOrDefault().Item;

			return true;
		}
	}
}
