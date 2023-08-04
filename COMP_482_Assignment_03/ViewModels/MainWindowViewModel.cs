using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Services;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class MainWindowViewModel : ObservableObject
	{
		public OrderViewModel OrderVM { get; }
		public OrdersViewModel OrdersVM { get; }
		public InventoryViewModel InventoryVM { get; }
		public OrderIssueViewModel OrderIssueVM { get; }
		public EmployeesViewModel EmployeesVM { get; }

		public ICommand CreateOrderCommand{ get; }
		public ICommand CreateItemCommand { get; }
		public ICommand CreateEmployeeCommand { get; }

		private readonly Store store;
		private readonly Inventory inventory;
		private readonly OrderTracker orderTracker;
		private readonly EmployeeManager employeesManager;
		private readonly OrderIssueTracker orderIssueTracker;

		private readonly ItemDataService itemDataService;
		private readonly OrderDataService orderDataService;
		private readonly EmployeeDataService employeeDataService;
		private readonly OrderIssueDataService orderIssueDataService;

		public MainWindowViewModel()
		{
			itemDataService = new ItemDataService();
			orderDataService = new OrderDataService();
			employeeDataService = new EmployeeDataService();
			orderIssueDataService = new OrderIssueDataService();

			inventory = new Inventory(itemDataService.GetAll().ToArray());
			orderTracker = new OrderTracker(orderDataService.GetAll().ToArray());
			employeesManager = new EmployeeManager(employeeDataService.GetAll().ToArray());
			orderIssueTracker = new OrderIssueTracker(orderIssueDataService.GetAll().ToArray());
			store = new Store(orderIssueTracker, inventory, employeesManager, orderTracker);

			OrdersVM = new OrdersViewModel(orderTracker);
			InventoryVM = new InventoryViewModel(inventory, orderTracker);
			OrderIssueVM = new OrderIssueViewModel(orderIssueTracker, orderTracker);
			EmployeesVM = new EmployeesViewModel(employeesManager);
			OrderVM = new OrderViewModel(inventory, orderTracker, OrdersVM);

			CreateItemCommand = new CreateItemCommand(inventory, InventoryVM);
		}
	}
}
