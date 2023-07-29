using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class DeleteItemCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly InventoryViewModel inventoryVM;

		public DeleteItemCommand(Inventory _inventory, InventoryViewModel _inventoryVM)
		{
			inventory = _inventory;
			inventoryVM = _inventoryVM; 
		}

		public override void Execute(object parameter)
		{
			//TODO: ADD VALIDATION

			inventory.Remove(inventoryVM.SelectedItem.ID);
			inventoryVM.Items.Remove(inventoryVM.SelectedItem);
		}
	}
}
