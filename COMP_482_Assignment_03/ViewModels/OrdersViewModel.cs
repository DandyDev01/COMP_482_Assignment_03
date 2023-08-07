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

		private StoreOrder? selectedOrder;
		public StoreOrder? SelectedOrder
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

		public ObservableCollection<StoreOrder> Orders { get; }
		public ICollectionView OrdersCollectionView { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly OrderTracker orderTracker;

		public OrdersViewModel(OrderTracker _orderTracker)
		{
			orderTracker = _orderTracker;
			Orders = new ObservableCollection<StoreOrder>(orderTracker.Orders);
			OrdersCollectionView = CollectionViewSource.GetDefaultView(Orders);

			selectedOrder = Orders.FirstOrDefault();
			collectionViewPropertySort = new CollectionViewPropertySort(OrdersCollectionView);

			ViewOrderCommand = new ViewOrderCommand(this);
			CancelOrderCommand = new CancelOrderCommand(this, orderTracker);
		}
	}
}
