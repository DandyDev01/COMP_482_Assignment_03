using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Models
{
	public interface SelectItemsDataBase
	{
		public Item[] ItemsSource { get; }

		public void ManipulateData(ObservableCollection<ObservableItem> itemsToSelectFrom);
	}
}
