using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class CreateItemCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly InventoryViewModel inventoryVM;

		public CreateItemCommand(Inventory _inventory, InventoryViewModel _inventoryVM)
		{
			inventory = _inventory;
			inventoryVM = _inventoryVM;
		}

		public override void Execute(object parameter)
		{
			Window window = new CreateItemDialogWindow();
			DialogWindowCreateItemViewModel dialogContext =
				new DialogWindowCreateItemViewModel(window);
			window.DataContext = dialogContext;

			window.ShowDialog();

			if (window.DialogResult == false) return;

			inventory.Add(dialogContext.ObservableItem.Item);
			inventoryVM.Items.Add(dialogContext.ObservableItem.Item);
		}
	}
}
