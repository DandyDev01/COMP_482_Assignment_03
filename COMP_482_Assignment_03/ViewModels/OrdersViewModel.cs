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

		public ObservableCollection<Object> Orders { get; }
		public ICollectionView OrdersCollectionView { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;

		public OrdersViewModel()
		{
			Orders = new ObservableCollection<Object>();
			OrdersCollectionView = CollectionViewSource.GetDefaultView(Orders);

			collectionViewPropertySort = new CollectionViewPropertySort(OrdersCollectionView);
		}
	}
}
