using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class CollectionViewSortByPropertyCommand : BaseCommand
	{
		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly string propertyName;

		public CollectionViewSortByPropertyCommand(CollectionViewPropertySort _collectionViewPropertySort, string _propertyName)
		{
			collectionViewPropertySort = _collectionViewPropertySort;
			propertyName = _propertyName;
		}

		public override void Execute(object parameter)
		{
			collectionViewPropertySort.Sort(propertyName);
		}
	}
}
