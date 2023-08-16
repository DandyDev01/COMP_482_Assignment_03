using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class DialogWindowUserLoginViewModel : ObservableObject, INotifyDataErrorInfo
	{
		public ICommand SubmitCommand { get; }

		public MainWindowViewModel MainWindowVM => mainWindowVM;

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
				BasicStringFieldValidation(nameof(EmployeeNumber), EmployeeNumber);
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
				BasicStringFieldValidation(nameof(Password), Password);
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

		private readonly Window window;
		private readonly MainWindowViewModel mainWindowVM;
		private readonly EmployeeManager employeeManager;
		private readonly Dictionary<string, List<string>> propertyNameToError;

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		public DialogWindowUserLoginViewModel(Window _window, MainWindowViewModel mainWindowViewModel, 
			EmployeeManager _employeeManager)
		{
			window = _window;
			mainWindowVM = mainWindowViewModel;
			employeeManager = _employeeManager;
			propertyNameToError = new Dictionary<string, List<string>>();

			employeeNumber = string.Empty;
			password = string.Empty;

			SubmitCommand = new RelayCommand(Submit);

			BasicStringFieldValidation(nameof(EmployeeNumber), EmployeeNumber);
			BasicStringFieldValidation(nameof(Password), Password);
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

		public IEnumerable GetErrors(string? propertyName)
		{
			return propertyNameToError.GetValueOrDefault(propertyName, new List<string>());
		}

		private void BasicStringFieldValidation(string propertyName, string propertyValue)
		{
			propertyNameToError.Remove(propertyName);

			List<string> errors = new List<string>();
			propertyNameToError.Add(propertyName, errors);
			if (string.IsNullOrEmpty(propertyValue) || string.IsNullOrWhiteSpace(propertyValue))
			{
				propertyNameToError[propertyName].Add("Cannot be empty or white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (char.IsWhiteSpace(propertyValue.FirstOrDefault()))
			{
				propertyNameToError[propertyName].Add("Cannot start with white space");
				ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
			}

			if (propertyNameToError[propertyName].Any() == false)
			{
				propertyNameToError.Remove(propertyName);
			}

			IsValid = !HasErrors;
		}
	}
}
