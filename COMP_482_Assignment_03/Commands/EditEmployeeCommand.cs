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
	public class EditEmployeeCommand : BaseCommand
	{
		private readonly EmployeeManager employeeManager;
		private readonly EmployeesViewModel employeesVM;

		public EditEmployeeCommand(EmployeeManager _employeeManager, EmployeesViewModel _employeesVM)
		{
			employeeManager = _employeeManager;
			employeesVM = _employeesVM;
		}

		public override void Execute(object parameter)
		{
			Window window = new CreateEmployeeDialogWindow();
			DialogWindowCreateEmployeeViewModel dialogContext =
				new DialogWindowCreateEmployeeViewModel(window, employeesVM.SelectedEmployee);
			window.DataContext = dialogContext;

			Employee temp = new Employee(employeesVM.SelectedEmployee.FirstName, employeesVM.SelectedEmployee.LastName,
				employeesVM.SelectedEmployee.PhoneNumber, employeesVM.SelectedEmployee.Password, 
				employeesVM.SelectedEmployee.EmployeeNumber, employeesVM.SelectedEmployee.Department, 
				employeesVM.SelectedEmployee.Role, employeesVM.SelectedEmployee.WorkTime);

			window.ShowDialog();

			if (window.DialogResult == false)
			{
				employeesVM.SelectedEmployee.FirstName = temp.FirstName;
				employeesVM.SelectedEmployee.LastName = temp.LastName;
				employeesVM.SelectedEmployee.PhoneNumber = temp.PhoneNumber;
				employeesVM.SelectedEmployee.EmployeeNumber = temp.EmployeeNumber;
				employeesVM.SelectedEmployee.Password = temp.Password;
				employeesVM.SelectedEmployee.Department = temp.Department;
				employeesVM.SelectedEmployee.Role = temp.Role;
				employeesVM.SelectedEmployee.WorkTime = temp.WorkTime;
				
				employeesVM.EmployeesCollectionView.Refresh();
				return;
			}

			employeesVM.EmployeesCollectionView.Refresh();
		}
	}
}
