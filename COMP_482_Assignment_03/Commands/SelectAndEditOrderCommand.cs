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
		private readonly SelectOrderForEditData selectOrderForEditData;
		private readonly SelectOrderCommand selectOrderCommand;
		private readonly EditOrderCommand editOrderCommand;

		public SelectAndEditOrderCommand(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;

			selectOrderForEditData = new SelectOrderForEditData();

			selectOrderCommand = new SelectOrderCommand(orderTracker, selectOrderForEditData);
			editOrderCommand = new EditOrderCommand();
		}

		public override void Execute(object parameter)
		{
			
		}
	}
}
