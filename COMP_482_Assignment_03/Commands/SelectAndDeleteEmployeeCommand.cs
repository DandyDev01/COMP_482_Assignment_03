using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COMP_482_Assignment_03.Commands
{
	public class SelectAndDeleteEmployeeCommand : BaseCommand
	{
		private readonly EmployeeManager employeeManager;
		private readonly EmployeesViewModel employeesVM;
		private Window window;

		public SelectAndDeleteEmployeeCommand(EmployeeManager _employeeManager, EmployeesViewModel _employeesVM)
		{
			employeeManager = _employeeManager;
			employeesVM = _employeesVM;
			window = new SelectEmployeeDialogWindow();
		}

		public override void Execute(object parameter)
		{
			// open window to select employee
			EmployeesViewModel employeesVM = new EmployeesViewModel(employeeManager, new RelayCommand(Submit),
				new RelayCommand(Cancel));
			window.DataContext = employeesVM;
			window.ShowDialog();
		}

		private void Cancel()
		{
			window.DialogResult = false;
			window = new SelectEmployeeDialogWindow();
		}

		private void Submit()
		{
			EmployeesViewModel vm = ((EmployeesViewModel)window.DataContext);
			
			employeeManager.Remove(vm.SelectedEmployee.EmployeeNumber);
			employeesVM.Employees.Remove(vm.SelectedEmployee);
			employeesVM.SelectedEmployee = vm.Employees[0];

			window.DialogResult = true;
			window = new SelectEmployeeDialogWindow();
		}
	}
}
