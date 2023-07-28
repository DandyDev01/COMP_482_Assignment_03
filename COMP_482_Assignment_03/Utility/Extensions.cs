using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Utility
{
	public static class Extensions
	{
		public static ObservableCollection<ObservableItem> GetObservableItems(this Item[] items)
		{
			ObservableCollection<ObservableItem> result = new ObservableCollection<ObservableItem>();
			foreach (Item item in items)
			{
				result.Add(new ObservableItem(item));
			}

			return result;
		}
	}
}
