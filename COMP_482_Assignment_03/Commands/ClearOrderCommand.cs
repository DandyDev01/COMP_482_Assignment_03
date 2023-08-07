using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class ClearOrderCommand : BaseCommand
	{
		private readonly OrderViewModel orderVM;

		public ClearOrderCommand(OrderViewModel _orderViewModel)
		{
			orderVM = _orderViewModel;
		}

		public override void Execute(object parameter)
		{
			orderVM.Order.Clear();
			orderVM.ItemsListVM.Items.Clear();
		}
	}
}
