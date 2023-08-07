using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.Commands
{
	public class DeleteEmployeeCommand : BaseCommand
	{
		private readonly EmployeeManager employeeManager;
		private readonly EmployeesViewModel employeesVM;

		public DeleteEmployeeCommand(EmployeeManager _employeeManager, EmployeesViewModel _employeesVM)
		{
			employeeManager = _employeeManager;
			employeesVM = _employeesVM;
		}

		public override void Execute(object parameter)
		{
			employeeManager.Remove(employeesVM.SelectedEmployee.EmployeeNumber);
			employeesVM.Employees.Remove(employeesVM.SelectedEmployee);
			employeesVM.SelectedEmployee = employeesVM.Employees[0];
		}
	}
}
