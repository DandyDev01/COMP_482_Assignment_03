using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COMP_482_Assignment_03.Views
{
	/// <summary>
	/// Interaction logic for InventoryView.xaml
	/// </summary>
	public partial class InventoryView : UserControl
	{
		public InventoryView()
		{
			InitializeComponent();
			this.InputBindings.Add(new KeyBinding(new RelayCommand(Delete), Key.Delete, ModifierKeys.None));
		}

		private void Delete()
		{
			InventoryViewModel viewModel = (InventoryViewModel)DataContext;

			while (list.list.SelectedItems.Count > 0)
			{
				viewModel.ItemsListVM.SelectedItem = list.list.SelectedItems[0] as Item;
				viewModel.DeleteItemCommand.Execute(null);
			}		
		}
	}
}
