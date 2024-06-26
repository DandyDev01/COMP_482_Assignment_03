﻿using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Models.SelectOrderData;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class EditOrderCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly OrdersViewModel ordersVM;
		private readonly SelectOrderForEditData? selectOrderForEditData;
		private readonly Order? order;
		private Window window;

		public EditOrderCommand(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM,
			SelectOrderForEditData _selectOrderForEditData)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;
			selectOrderForEditData = _selectOrderForEditData;
			window = new Window();
		}

		public EditOrderCommand(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;
			window = new Window();
		}

		public override void Execute(object parameter)
		{
			window.Content = new OrderView();

			if (selectOrderForEditData != null)
			{
				window.DataContext = new OrderViewModel(inventory, orderTracker, ordersVM,
						selectOrderForEditData.SelectedOrder, new RelayCommand(Cancel), new RelayCommand(Create));
			}
			else 
			{
				window.DataContext = new OrderViewModel(inventory, orderTracker, ordersVM,
						ordersVM.SelectedOrder, new RelayCommand(Cancel), new RelayCommand(Create));
			}

			window.ShowDialog();
		}

		private void Create()
		{

			if (selectOrderForEditData != null)
			{
				selectOrderForEditData.SelectedOrder.DataLastModified = DateTime.Now.ToString();
			}
			else
			{
				ordersVM.SelectedOrder.DataLastModified = DateTime.Now.ToString();
			}

			window.DialogResult = true;
			window = new Window();
		}

		private void Cancel()
		{
			//orderTracker.Add(selectOrderForEditData.SelectedOrder);
			window.DialogResult = false;
			window = new Window();
		}
	}
}
