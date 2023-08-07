using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class CancelOrderCommand : BaseCommand
	{
		private readonly OrdersViewModel ordersViewModel;
		private readonly OrderTracker orderTracker;

		public CancelOrderCommand(OrdersViewModel _ordersViewModel, OrderTracker _orderTracker)
		{
			ordersViewModel = _ordersViewModel;
			orderTracker = _orderTracker;
		}

		public override void Execute(object parameter)
		{
			orderTracker.Remove(ordersViewModel.SelectedOrder.ID);
			ordersViewModel.Orders.Remove(ordersViewModel.SelectedOrder);
		}
	}
}
