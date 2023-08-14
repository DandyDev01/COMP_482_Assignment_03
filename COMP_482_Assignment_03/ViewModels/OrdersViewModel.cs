using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class OrdersViewModel : ObservableObject
	{
		public ICommand CreateOrderCommand { get; }
		public ICommand ViewOrderCommand { get; }
		public ICommand EditOrderCommand { get; }
		public ICommand CancelOrderCommand { get; }
		public ICommand RefreshCommand { get; }

		public ICommand OrderIDSort { get; }
		public ICommand OrderStatusSort { get; }
		public ICommand OrderWeightSort { get; }
		public ICommand OrderCostSort { get; }
		public ICommand ExpectedDeliveryDateSort { get; }
		public ICommand DateCreatedSort { get; }
		public ICommand OrderDepartementSort { get; }

		private Order? selectedOrder;
		public Order? SelectedOrder
		{
			get
			{
				return selectedOrder;
			}
			set
			{
				OnPropertyChanged(ref selectedOrder, value);
			}
		}

		public ObservableCollection<Order> Orders { get; }
		public ICollectionView OrdersCollectionView { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly OrderTracker orderTracker;

		public OrdersViewModel(OrderTracker _orderTracker)
		{
			orderTracker = _orderTracker;
			Orders = new ObservableCollection<Order>(orderTracker.Orders);
			OrdersCollectionView = CollectionViewSource.GetDefaultView(Orders);

			selectedOrder = Orders.FirstOrDefault();
			collectionViewPropertySort = new CollectionViewPropertySort(OrdersCollectionView);

			CreateOrderCommand = null;
			//EditOrderCommand = new EditOrderCommand(inventory, orderTracker, this);
			ViewOrderCommand = new ViewOrderCommand(this);
			CancelOrderCommand = new CancelOrderCommand(this, orderTracker);
			RefreshCommand = new RelayCommand(Refresh);

			OrderIDSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Order.ID));
			OrderStatusSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Order.OrderStatus));
			OrderWeightSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Order.Weight));
			OrderCostSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Order.Cost));
			ExpectedDeliveryDateSort = null;
			DateCreatedSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Order.DataCreated));
			OrderDepartementSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Order.Department));
		}

		private void Refresh()
		{
			OrdersCollectionView.Refresh();
		}
	}
}
