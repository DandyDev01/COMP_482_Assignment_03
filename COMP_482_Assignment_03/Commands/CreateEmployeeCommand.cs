using COMP_482_Assignment_03.Models;
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
	public class CreateEmployeeCommand : BaseCommand
	{
		private readonly EmployeeManager employeeManager;
		private readonly EmployeesViewModel employeesVM;

		public CreateEmployeeCommand(EmployeeManager _employeeManager, EmployeesViewModel _employeesVM)
		{
			employeeManager = _employeeManager;
			employeesVM = _employeesVM;
		}

		public override void Execute(object parameter)
		{
			Window window = new CreateEmployeeDialogWindow();
			DialogWindowCreateEmployeeViewModel dialogContext =
				new DialogWindowCreateEmployeeViewModel(window);
			window.DataContext = dialogContext;

			window.ShowDialog();

			if (window.DialogResult == false) return;

			employeeManager.Add(dialogContext.ObservableEmployee.Employee);
			employeesVM.Employees.Add(dialogContext.ObservableEmployee.Employee);
		}
	}
}
