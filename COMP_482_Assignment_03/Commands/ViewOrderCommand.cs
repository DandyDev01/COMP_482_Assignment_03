using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Views;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class ViewOrderCommand : BaseCommand
	{
		private readonly OrdersViewModel ordersViewModel;

		public ViewOrderCommand(OrdersViewModel _ordersViewModel)
		{
			ordersViewModel = _ordersViewModel;
		}

		public override void Execute(object parameter)
		{
			ViewOrderDialogWindow window = new ViewOrderDialogWindow();
			ItemsListViewModel dialogContext =
				new ItemsListViewModel(ordersViewModel.SelectedOrder.Items);
			window.list.DataContext = dialogContext;

			window.ShowDialog();

			if (window.DialogResult == false) return;
		}
	}
}
