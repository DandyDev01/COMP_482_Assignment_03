using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class SelectItemsForOrderData : SelectItemsDataBase
	{
		public Item[] ItemsSource => inventory.Items.ToArray();
		
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly ObservableCollection<Item> destinationCollection;

		public SelectItemsForOrderData(Inventory _inventory, OrderTracker _orderTracker,
			ObservableCollection<Item> _destinationCollection)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			destinationCollection = _destinationCollection;
		}

		public void ManipulateData(ObservableCollection<ObservableItem> itemsToSelectFrom)
		{
			Order order = orderTracker.Last;

			List<ObservableItem> selectedItems = itemsToSelectFrom.Where(x => x.IsSelected).ToList();
			foreach (ObservableItem observableItem in selectedItems)
			{
				order.Add(observableItem.Item);
				destinationCollection.Add(observableItem.Item);
			}
		}
	}
}
