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
				new DialogWindowCreateItemViewModel(window, inventoryVM.SelectedItem);
			window.DataContext = dialogContext;

			Item temp = new Item(inventoryVM.SelectedItem.Name, inventoryVM.SelectedItem.ID, inventoryVM.SelectedItem.Price,
				inventoryVM.SelectedItem.Brand, inventoryVM.SelectedItem.Size, inventoryVM.SelectedItem.Quantity,
				inventoryVM.SelectedItem.RetailCost, inventoryVM.SelectedItem.Cost, inventoryVM.SelectedItem.Category,
				inventoryVM.SelectedItem.Department);

			window.ShowDialog();

			if (window.DialogResult == false)
			{
				inventoryVM.SelectedItem.Name = temp.Name;
				inventoryVM.SelectedItem.ID = temp.ID;
				inventoryVM.SelectedItem.Price = temp.Price;
				inventoryVM.SelectedItem.Brand = temp.Brand;
				inventoryVM.SelectedItem.Size = temp.Size;
				inventoryVM.SelectedItem.Quantity = temp.Quantity;
				inventoryVM.SelectedItem.Cost = temp.Cost;
				inventoryVM.SelectedItem.Category = temp.Category;
				inventoryVM.SelectedItem.Department = temp.Department;

				inventoryVM.ItemsListVM.ItemsCollectionView.Refresh();
				return;
			}

			inventoryVM.ItemsListVM.ItemsCollectionView.Refresh();
		}
	}
}
