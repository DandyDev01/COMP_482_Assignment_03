﻿using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;


namespace COMP_482_Assignment_03.ViewModels
{	
	public class OrderViewModel : ObservableObject, INotifyDataErrorInfo
	{
		public ICommand AddItemsCommand { get; }
		public ICommand RemoveItemsCommand { get; }
		public ICommand CancelCommand { get; }
		public ICommand CreateCommand { get; }

		private string date;
		public string Date
		{
			get
			{
				return date;
			}
			set
			{
				OnPropertyChanged(ref date, value);
			}
		}

		private string orderID;
		public string OrderID
		{
			get
			{
				return orderID;
			}
			set
			{
				OnPropertyChanged(ref orderID, value);
			}
		}

		public ItemsListViewModel ItemsListVM { get; }

		public Array Departments { get; } = Enum.GetValues(typeof(StoreDepartment));

		private StoreDepartment selectedDepartment;
		public StoreDepartment SelectedDepartment
		{
			get
			{
				return selectedDepartment;
			}
			set
			{
				OnPropertyChanged(ref selectedDepartment, value);
			}
		}

		private string errors;
		public string Errors
		{
			get
			{
				return errors;
			}
			set
			{
				OnPropertyChanged(ref errors, value);
			}
		}

		private bool isValid;
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				OnPropertyChanged(ref isValid, value);
			}
		}

		private Order order;
		public Order Order
		{
			get
			{
				return order;
			}
			set
			{
				OnPropertyChanged(ref order, value);
			}
		}

		private readonly OrdersViewModel ordersVM;
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly Dictionary<string, List<string>> propertyNameToError;

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		public OrderViewModel(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM)
		{
			inventory = _inventory;
			orderTracker = _orderTracker;
			ordersVM = _ordersVM;
			ItemsListVM = new ItemsListViewModel();
			propertyNameToError = new Dictionary<string, List<string>>();
			isValid = false;

			errors = string.Empty;
			date = DateTime.Now.ToString("yyyy-MMM-dd-ddd");
			order = new Order();
			orderTracker.Queued = order;

			orderID = "Order ID: " + order.ID;

			AddItemsCommand = new SelectItemsCommand(new SelectItemsForOrderData(inventory, orderTracker, ItemsListVM.Items));
			RemoveItemsCommand = new SelectItemsCommand(new SelectItemsToRemoveFromOrderData(orderTracker, ItemsListVM.Items));
			CreateCommand = new CreateOrderCommand(orderTracker, ordersVM, this);
			CancelCommand = new ClearOrderCommand(this);
			
			ItemsListVM.ItemsCollectionView.CollectionChanged += Validate;

			ItemsListVM.AddItemsCommand = AddItemsCommand;
			ItemsListVM.RemoveItemsCommand = RemoveItemsCommand;

			Validate(null, null);
		}

		/// <summary>
		/// remove the order from the orderTracker
		/// </summary>
		/// <param name="_inventory"></param>
		/// <param name="_orderTracker"></param>
		/// <param name="_ordersVM"></param>
		/// <param name="_order">order that will be removed from the order tracker</param>
		public OrderViewModel(Inventory _inventory, OrderTracker _orderTracker, OrdersViewModel _ordersVM, Order _order,
			ICommand _cancelCommand, ICommand _createCommand)
		{
			orderTracker = _orderTracker;
			inventory = _inventory;
			ordersVM = _ordersVM;
			ItemsListVM = new ItemsListViewModel(_order.Items);
			propertyNameToError = new Dictionary<string, List<string>>();
			isValid = false;

			errors = string.Empty;
			date = DateTime.Now.ToString("yyyy-MMM-dd-ddd");
			order = _order;
			orderTracker.Queued = order;

			orderID = "Order ID: " + order.ID;

			AddItemsCommand = new SelectItemsCommand(
				new SelectItemsForOrderData(inventory, orderTracker, ItemsListVM.Items));
			RemoveItemsCommand = new SelectItemsCommand(
				new SelectItemsToRemoveFromOrderData(orderTracker, ItemsListVM.Items));

			CreateCommand = _createCommand;
			CancelCommand = _cancelCommand;

			ItemsListVM.ItemsCollectionView.CollectionChanged += Validate;

			ItemsListVM.AddItemsCommand = AddItemsCommand;
			ItemsListVM.RemoveItemsCommand = RemoveItemsCommand;

			Validate(null, null);
		}

		private void Validate(object? sender, NotifyCollectionChangedEventArgs e)
		{
			propertyNameToError.Remove(nameof(ItemsListVM.ItemsCollectionView));

			List<string> errors = new List<string>();
			propertyNameToError.Add(nameof(ItemsListVM.ItemsCollectionView), errors);
			if (ItemsListVM.Items.Count <= 0)
			{
				propertyNameToError[nameof(ItemsListVM.ItemsCollectionView)].Add("Order must have at least 1 item");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(ItemsListVM.ItemsCollectionView)));
			}

			// there are no errors for the ItemsCollectionView
			if (propertyNameToError[nameof(ItemsListVM.ItemsCollectionView)].Any() == false)
			{
				propertyNameToError.Remove(nameof(ItemsListVM.ItemsCollectionView));
				Errors = string.Empty;
			}

			// get errors for ItemsCollectionView to a string for display
			foreach (string error in GetErrors(nameof(ItemsListVM.ItemsCollectionView)))
			{
				Errors += error + "\r\n";
			}

			IsValid = !HasErrors;
		}

		public IEnumerable GetErrors(string? propertyName)
		{
			return propertyNameToError.GetValueOrDefault(propertyName, new List<string>());
		}
	}
}
