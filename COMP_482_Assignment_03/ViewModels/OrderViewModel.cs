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

public enum StoreDepartments { Grocery, Produce, Meat, Deliy, Bakery };

namespace COMP_482_Assignment_03.ViewModels
{
	public class OrderViewModel : ObservableObject
	{
		public ICommand AddItemsCommand { get; }
		public ICommand RemoveItemsCommand { get; }
		public ICommand CancelCommand { get; }
		public ICommand CreateCommand { get; }

		public ObservableCollection<Object> Items { get; }
		public ICollectionView ItemsCollectionView { get; }

		public Array Departments = Enum.GetValues(typeof(StoreDepartments));
		public string Date { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;

		public OrderViewModel()
		{
			Items = new ObservableCollection<Object>();
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			Date = DateTime.Now.ToString();
		}
	}
}
