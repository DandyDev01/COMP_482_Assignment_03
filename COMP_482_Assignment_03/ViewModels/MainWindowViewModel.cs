using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Services;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.Windows;
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
		public Action<Employee> OnLoggedInEmployeeChanged;

		public OrderViewModel OrderVM { get; }
		public OrdersViewModel OrdersVM { get; }
		public InventoryViewModel InventoryVM { get; }
		public OrderIssueViewModel OrderIssueVM { get; }
		public EmployeesViewModel EmployeesVM { get; }

		public ICommand CreateOrderCommand{ get; }
		public ICommand CreateOrderIssueCommand{ get; }
		public ICommand CreateItemCommand { get; }
		public ICommand CreateEmployeeCommand { get; }
		public ICommand DeleteItemCommand { get; }
		public ICommand DeleteEmployeeCommand { get; }
		public ICommand EditOrderCommand { get; }
		public ICommand EditItemCommand { get; }
		public ICommand SignOutCommand { get; }
		public ICommand SignInCommand { get; }
		public ICommand HelpCommand { get; }

		private Employee? loggedInEmployee;
		public Employee? LoggedInEmployee
		{
			get
			{
				return loggedInEmployee;
			}
			set
			{
				OnPropertyChanged(ref loggedInEmployee, value);

				OnLoggedInEmployeeChanged?.Invoke(value);

				if (value == null)
					SignOutHeader = "Sign Out";
				else
					SignOutHeader = "Sign Out: " + value.EmployeeNumber;
			}
		}

		private string signOutHeader;
		public string SignOutHeader
		{
			get
			{
				return signOutHeader;
			}
			set
			{
				OnPropertyChanged(ref signOutHeader, value);
			}
		}

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
			signOutHeader = string.Empty;

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
			CreateOrderIssueCommand = new RelayCommand(null);
			CreateEmployeeCommand = new CreateEmployeeCommand(employeesManager, EmployeesVM);
			CreateOrderCommand = new CreateOrderCommand(orderTracker, OrdersVM, OrderVM);
			DeleteEmployeeCommand = new DeleteEmployeeCommand(employeesManager, EmployeesVM);
			DeleteItemCommand = new DeleteItemCommand(inventory, InventoryVM);
			EditOrderCommand = new SelectAndEditOrderCommand(inventory, orderTracker, OrdersVM);
			EditItemCommand = new EditItemCommand(inventory, InventoryVM);
			SignOutCommand = new UserSignoutCommand(this);
			SignInCommand = new RelayCommand(UserSignIn);
			HelpCommand = new RelayCommand(null);

			OnLoggedInEmployeeChanged += OrderIssueVM.LoggedInEmployeeChanged;
			OnLoggedInEmployeeChanged += EmployeesVM.LoggedInEmployeeChanged;
			UserSignIn();
		}

		public void UserSignIn()
		{
			UserLoginDialogWindow window = new UserLoginDialogWindow();
			DialogWindowUserLoginViewModel dataContext =
				new DialogWindowUserLoginViewModel(window, this, employeesManager);

			window.DataContext = dataContext;
			window.ShowDialog();
		}
	}
}
