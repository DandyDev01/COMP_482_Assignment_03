using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class SelectItemsCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly ObservableCollection<Item> items;

		public SelectItemsCommand(Inventory _inventory, OrderTracker _orderTracker, ObservableCollection<Item> _items)
		{
			inventory = _inventory; 
			orderTracker = _orderTracker;
			items = _items;
		}

		public override void Execute(object parameter)
		{
			// TODO: ADD VALIDATION

			Window window = new SelectItemsDialogWindow();
			DialogWindowSelectedItemsViewModel dialogContext =
				new DialogWindowSelectedItemsViewModel(window, inventory, orderTracker, items);
			window.DataContext = dialogContext;

			window.ShowDialog();

			if (window.DialogResult == false) return;

		}
	}
}
