using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Models.SelectOrderData;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class SelectOrderCommand : BaseCommand
	{
		private readonly OrderTracker orderTracker;
		private readonly SelectOrderDataBase orderData;
		private readonly Inventory inventory;

		public SelectOrderCommand(OrderTracker _orderTracker, SelectOrderDataBase _orderData, Inventory _inventory)
		{
			orderTracker = _orderTracker;
			orderData = _orderData;
			inventory = _inventory;
		}

		public override void Execute(object parameter)
		{
			Window window = new SelectOrderDialogWindow();
			OrdersViewModel dialogContext = new OrdersViewModel(orderTracker, inventory);
			window.DataContext = dialogContext;

			window.ShowDialog();

			if (window.DialogResult == false) return;

			orderData.SelectedOrder = dialogContext.SelectedOrder;
		}
	}
}
