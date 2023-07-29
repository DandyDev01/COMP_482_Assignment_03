using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class CreateOrderCommand : BaseCommand
	{
		private OrderTracker orderTracker;
		private OrderViewModel orderVM;

		public CreateOrderCommand(OrderTracker _orderTracker, OrderViewModel _orderVM)
		{
			orderTracker = _orderTracker;
			orderVM = _orderVM;
		}

		public override void Execute(object parameter)
		{
			orderVM.Order = new StoreOrder();
			orderTracker.Add(orderVM.Order);
		}
	}
}
