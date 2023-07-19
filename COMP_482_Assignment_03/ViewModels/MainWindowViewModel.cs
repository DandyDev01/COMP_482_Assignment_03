using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.ViewModels
{
	public class MainWindowViewModel : ObservableObject
	{
		public OrderViewModel OrderVM { get; }
		public OrdersViewModel OrdersVM { get; }
		public InventoryViewModel InventoryVM { get; }
		public OrderIssueViewModel OrderIssueVM { get; }
		public EmployeesViewModel EmployeesVM { get; }

		public MainWindowViewModel()
		{
			OrderVM = new OrderViewModel();
			OrdersVM = new OrdersViewModel();
			InventoryVM = new InventoryViewModel();
			OrderIssueVM = new OrderIssueViewModel();
			EmployeesVM = new EmployeesViewModel();
		}
	}
}
