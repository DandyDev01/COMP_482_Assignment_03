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
		public ICommand FirstNameSort { get; }
		public ICommand LastNameSort { get; }
		public ICommand PhoneNumberSort{ get; }
		public ICommand EmployeeNumberSort { get; }

		public ObservableCollection<Employee> Employees;
		public ICollectionView EmployeesCollectionView;

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
			}
		}

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly EmployeeManager employeeManager;

		public EmployeesViewModel(EmployeeManager _employeeManager)
		{
			employeeManager = _employeeManager;

			Employees = new ObservableCollection<Employee>(employeeManager.Employees);
			EmployeesCollectionView = CollectionViewSource.GetDefaultView(Employees);

			collectionViewPropertySort = new CollectionViewPropertySort(EmployeesCollectionView);

			FirstNameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.FirstName));
			LastNameSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.LastName));
			PhoneNumberSort = new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.PhoneNumber));
			EmployeeNumberSort= new CollectionViewSortByPropertyCommand(collectionViewPropertySort, nameof(Employee.EmployeeNumber));
		}
	}
}
