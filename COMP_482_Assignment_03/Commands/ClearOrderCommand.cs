using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class ClearOrderCommand : BaseCommand
	{
		private readonly OrderTracker orderTracker;
		private readonly OrdersViewModel ordersVM;
		private readonly OrderViewModel orderVM;

		public ClearOrderCommand(OrderTracker _orderTracker, OrdersViewModel _ordersVM, OrderViewModel _orderViewModel)
		{
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;
			orderVM = _orderViewModel;
		}

		public override void Execute(object parameter)
		{
			orderVM.Order.Clear();
			orderVM.Items.Clear();
		}
	}
}
