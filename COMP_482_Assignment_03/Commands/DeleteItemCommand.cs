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
		private readonly InventoryViewModel inventoryVM;

		public DeleteItemCommand(InventoryViewModel _inventoryVM)
		{
			inventoryVM = _inventoryVM; 
		}

		public override void Execute(object parameter)
		{
			inventoryVM.DeleteItemCommand.Execute(parameter);
		}
	}
}
