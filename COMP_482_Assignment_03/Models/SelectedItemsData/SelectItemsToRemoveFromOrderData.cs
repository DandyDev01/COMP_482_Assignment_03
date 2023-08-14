using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public class SelectItemsToRemoveFromOrderData : SelectItemsDataBase
	{
		public Item[] ItemsSource => orderTracker.Last.Items;

		public OrderTracker OrderTracker => orderTracker;

		private readonly OrderTracker orderTracker;
		private readonly ObservableCollection<Item> sourceCollection;

		public SelectItemsToRemoveFromOrderData(OrderTracker _orderTracker, ObservableCollection<Item> _sourceCollection)
		{
			orderTracker = _orderTracker;
			sourceCollection = _sourceCollection;
		}

		public void ManipulateData(ObservableCollection<ObservableItem> itemsToSelectFrom)
		{
			Order order = orderTracker.Last;

			List<ObservableItem> selectedItems = itemsToSelectFrom.Where(x => x.IsSelected).ToList();
			foreach (ObservableItem observableItem in selectedItems)
			{
				order.Remove(observableItem.Item);
				sourceCollection.Remove(observableItem.Item);
			}
		}
	}
}
