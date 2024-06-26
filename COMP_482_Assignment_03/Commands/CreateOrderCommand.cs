﻿using COMP_482_Assignment_03.Models;
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
		private readonly OrderTracker orderTracker;
		private readonly OrderViewModel orderVM;
		private readonly OrdersViewModel ordersVM;

		public CreateOrderCommand(OrderTracker _orderTracker, OrdersViewModel _ordersVM, OrderViewModel _orderVM)
		{
			orderTracker = _orderTracker;
			orderVM = _orderVM;
			ordersVM = _ordersVM;
		}

		public override void Execute(object parameter)
		{
			orderTracker.Add(orderTracker.Queued);
			ordersVM.Orders.Add(orderTracker.Queued);

			orderVM.Order = new Order();
			orderTracker.Queued = orderVM.Order;

			orderVM.ItemsListVM.Items.Clear();
			orderVM.Date = DateTime.Now.ToString();
			orderVM.OrderID = "Order ID: " + orderVM.Order.ID;
		}
	}
}
