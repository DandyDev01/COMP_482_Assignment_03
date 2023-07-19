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
	public class InventoryViewModel : ObservableObject
	{
		public ICommand CreateItemCommand { get; }
		public ICommand DeleteItemCommand { get; }

		public string SearchTerm { get; set; }

		public ObservableCollection<Object> Items { get; }
		public ICollectionView ItemsCollectionView { get; }

		public string Date { get; }

		private readonly CollectionViewPropertySort collectionViewPropertySort;

		public InventoryViewModel()
		{
			Items = new ObservableCollection<Object>();
			ItemsCollectionView = CollectionViewSource.GetDefaultView(Items);

			collectionViewPropertySort = new CollectionViewPropertySort(ItemsCollectionView);

			Date = DateTime.Now.ToString();
		}
	}
}
