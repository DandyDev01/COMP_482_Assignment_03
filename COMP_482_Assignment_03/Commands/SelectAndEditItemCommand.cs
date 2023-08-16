using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Models.SelectedItemsData;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace COMP_482_Assignment_03.Commands
{
	public class SelectAndEditItemCommand : BaseCommand
	{
		private readonly Inventory inventory;
		private readonly InventoryViewModel inventoryVM;

		public SelectAndEditItemCommand(Inventory _inventory, InventoryViewModel _inventoryVM)
		{
			inventory = _inventory;
			inventoryVM = _inventoryVM;
		}
		
		public override void Execute(object parameter)
		{
			SelectItemForEditData data = new SelectItemForEditData(inventory, inventoryVM);
			ICommand selectItemCommand = new SelectItemsCommand(data, 1);
			
			
			selectItemCommand.Execute(parameter);
			inventoryVM.EditItemCommand.Execute(parameter);
		}
	}
}
