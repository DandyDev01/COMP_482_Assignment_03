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
	public class EditItemCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly InventoryViewModel inventoryVM;

		public EditItemCommand(Inventory _inventory, InventoryViewModel _inventoryVM)
		{
			inventory = _inventory;
			inventoryVM = _inventoryVM;
		}

		public override void Execute(object parameter)
		{
			Window window = new CreateItemDialogWindow();
			DialogWindowCreateItemViewModel dialogContext =
				new DialogWindowCreateItemViewModel(window, inventoryVM, inventoryVM.ItemsListVM.SelectedItem);
			window.DataContext = dialogContext;

			Item selected = inventoryVM.ItemsListVM.SelectedItem;

			Item temp = new Item(selected.Name, selected.ID, selected.Price,
				selected.Brand, selected.Size, selected.Quantity,
				selected.RetailCost, selected.Cost, selected.Category,
				selected.Department);

			window.ShowDialog();

			if (window.DialogResult == false)
			{
				selected.Name = temp.Name;
				selected.ID = temp.ID;
				selected.Price = temp.Price;
				selected.Brand = temp.Brand;
				selected.Size = temp.Size;
				selected.Quantity = temp.Quantity;
				selected.Cost = temp.Cost;
				selected.Category = temp.Category;
				selected.Department = temp.Department;

				inventoryVM.ItemsListVM.ItemsCollectionView.Refresh();
				return;
			}

			inventoryVM.ItemsListVM.ItemsCollectionView.Refresh();
		}
	}
}
