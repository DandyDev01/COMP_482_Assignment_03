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
	public class SelectAndEditEmployeeCommand : BaseCommand
	{
		private readonly EmployeeManager employeeManager;
		private readonly EmployeesViewModel employeesVM;
		private Window window;

		public SelectAndEditEmployeeCommand(EmployeeManager _employeeManager, EmployeesViewModel _employeesVM)
		{
			employeeManager = _employeeManager;
			employeesVM= _employeesVM;
			window = new SelectEmployeeDialogWindow();
		}

		public override void Execute(object parameter)
		{
			// open window to select employee
			EmployeesViewModel employeesVM = new EmployeesViewModel(employeeManager, new RelayCommand(Submit), 
				new RelayCommand(Cancel));
			window.DataContext = employeesVM;
			window.ShowDialog();

			EditEmployeeCommand editEmployeeCommand = new EditEmployeeCommand(employeeManager, employeesVM);
			editEmployeeCommand.Execute(null);
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}

		private void Submit()
		{
			window.DialogResult = true;
		}
	}
}
