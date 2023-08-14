using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Models.SelectOrderData;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class SelectAndEditOrderCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly OrdersViewModel ordersVM;
		private readonly OrderViewModel orderVM;
		private readonly SelectOrderForEditData selectOrderForEditData;
		private readonly SelectOrderCommand selectOrderCommand;
		private readonly EditOrderCommand editOrderCommand;

		public SelectAndEditOrderCommand(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM,
			OrderViewModel _orderVM)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;
			orderVM = _orderVM;

			selectOrderForEditData = new SelectOrderForEditData();

			selectOrderCommand = new SelectOrderCommand(orderTracker, selectOrderForEditData, inventory);
			editOrderCommand = new EditOrderCommand(inventory, orderTracker, ordersVM,
				selectOrderForEditData);
		}

		public override void Execute(object parameter)
		{
			selectOrderCommand.Execute(null);

			editOrderCommand.Execute(null);
		}
	}
}
