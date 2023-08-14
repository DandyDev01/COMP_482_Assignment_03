using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class EmployeesViewModel : ObservableObject 
	{
		public ICommand CreateEmployeeCommand { get; }
		public ICommand DeleteEmployeeCommand { get; }
		public ICommand EditEmployeeCommand { get; }
		public ICommand FirstNameSort { get; }
		public ICommand LastNameSort { get; }
		public ICommand PhoneNumberSort{ get; }
		public ICommand EmployeeNumberSort { get; }
		public ICommand RoleSort { get; }
		public ICommand DepartmentSort { get; }
		public ICommand WorkTimeSort { get; }

		public ObservableCollection<Employee> Employees { get; }
		public ICollectionView EmployeesCollectionView { get; }

		private Employee selectedEmployee;
		public Employee SelectedEmployee
		{
			get
			{
				return selectedEmployee;
			}
			set
			{
				OnPropertyChanged(ref selectedEmployee, value);
				IsValid = selectedEmployee != null && selectedEmployee != loggedInEmployee;
			}
		}

		private bool isValid;
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				OnPropertyChanged(ref isValid, value);
			}
		}

		private Employee? loggedInEmployee;

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly EmployeeManager employeeManager;

		public EmployeesViewModel(EmployeeManager _employeeManager)
		{
			employeeManager = _employeeManager;

			Employees = new ObservableCollection<Employee>(employeeManager.Employees);
			EmployeesCollectionView = CollectionViewSource.GetDefaultView(Employees);
			selectedEmployee = Employees[0];

			collectionViewPropertySort = new CollectionViewPropertySort(EmployeesCollectionView);
			
			CreateEmployeeCommand = new CreateEmployeeCommand(employeeManager, this);
			DeleteEmployeeCommand = new DeleteEmployeeCommand(employeeManager, this);
			EditEmployeeCommand = new EditEmployeeCommand(employeeManager, this);
			FirstNameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.FirstName));
			LastNameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.LastName));
			PhoneNumberSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.PhoneNumber));
			EmployeeNumberSort= new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.EmployeeNumber));
			RoleSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.Role));
			DepartmentSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.Department));
			WorkTimeSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.WorkTime));
		}

		public void LoggedInEmployeeChanged(Employee employee)
		{
			IsValid = selectedEmployee != null && selectedEmployee != employee;
			loggedInEmployee = employee;
		}
	}
}
