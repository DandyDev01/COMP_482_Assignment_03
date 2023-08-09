using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class DialogWindowUserLoginViewModel : ObservableObject
	{
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		private string employeeNumber;
		public string EmployeeNumber
		{
			get
			{
				return employeeNumber;
			}
			set
			{
				OnPropertyChanged(ref employeeNumber, value);
			}
		}

		private string password;
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				OnPropertyChanged(ref password, value);
			}
		}

		private readonly Window window;
		private readonly MainWindowViewModel mainWindowVM;
		private readonly EmployeeManager employeeManager;

		public DialogWindowUserLoginViewModel(Window _window, MainWindowViewModel mainWindowViewModel, 
			EmployeeManager _employeeManager)
		{
			window = _window;
			mainWindowVM = mainWindowViewModel;
			employeeManager = _employeeManager;

			employeeNumber = string.Empty;
			password = string.Empty;

			SubmitCommand = new RelayCommand(Submit);
			CancelCommand = new RelayCommand(Cancel);
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}

		private void Submit()
		{
			Employee employee = employeeManager.Get(EmployeeNumber);

			if (employee == null)
			{
				MessageBox.Show("Invalid Employee Number.", "Invalid Data", MessageBoxButton.OK, 
					MessageBoxImage.Information);
				
				return;
			}

			if (employee.Password != Password)
			{
				MessageBox.Show("Wrong password for employee " + EmployeeNumber, 
					"Invalid Data", MessageBoxButton.OK, MessageBoxImage.Information);
				
				return;
			}

			mainWindowVM.LoggedInEmployee = employee;

			window.DialogResult = true;
		}
	}
}
