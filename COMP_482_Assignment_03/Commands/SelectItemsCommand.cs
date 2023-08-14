using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class SelectItemsCommand : BaseCommand
	{
		private readonly SelectItemsDataBase selectItemsData;

		public SelectItemsCommand(SelectItemsDataBase _selectItemsData)
		{
			selectItemsData = _selectItemsData;
		}

		public override void Execute(object parameter)
		{
			Window window = new SelectItemsDialogWindow();
			DialogWindowSelectedItemsViewModel dialogContext =
				new DialogWindowSelectedItemsViewModel(window, selectItemsData);
			window.DataContext = dialogContext;

			window.ShowDialog();

			if (window.DialogResult == false) return;

		}
	}
}
