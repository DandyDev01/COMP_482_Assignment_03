using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class SelectItemsToRemoveFromInventoryData : SelectItemsDataBase
	{
		public Item[] ItemsSource => inventory.Items;

		private readonly ObservableCollection<Item> sourceCollection;
		private readonly Inventory inventory;

		public SelectItemsToRemoveFromInventoryData(Inventory _inventory, ObservableCollection<Item> _sourceCollection)
		{
			sourceCollection = _sourceCollection;
			inventory = _inventory;
		}

		public void ManipulateData(ObservableCollection<ObservableItem> itemsToSelectFrom)
		{
			List<ObservableItem> selectedItems = itemsToSelectFrom.Where(x => x.IsSelected).ToList();
			foreach (ObservableItem observableItem in selectedItems)
			{
				inventory.Remove(observableItem.Item.ID);
				sourceCollection.Remove(observableItem.Item);
			}
		}
	}
}
