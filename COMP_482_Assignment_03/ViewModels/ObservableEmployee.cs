using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP_482_Assignment_03.ViewModels
{
	public class ObservableEmployee : ObservableObject, INotifyDataErrorInfo
	{
		private string firstName;
		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				OnPropertyChanged(ref firstName, value);
				BasicStringFieldValidation(nameof(FirstName), FirstName);
				Employee.FirstName = value;
			}
		}

		private string lastName;
		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				OnPropertyChanged(ref lastName, value);
				BasicStringFieldValidation(nameof(LastName), LastName);
				Employee.LastName = value;
			}
		}

		private string phoneNumber;
		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				OnPropertyChanged(ref phoneNumber, value);
				BasicStringFieldValidation(nameof(PhoneNumber), PhoneNumber);
				Employee.PhoneNumber = value;
			}
		}

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
				Employee.EmployeeNumber = value;
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

		private StoreDepartment department;
		public StoreDepartment Department
		{
			get
			{
				return department;
			}
			set
			{
				OnPropertyChanged(ref department, value);
				Employee.Department = value;
			}
		}

		private EmployeeRole role;
		public EmployeeRole Role
		{
			get
			{
				return role;
			}
			set
			{
				OnPropertyChanged(ref role, value);
				Employee.Role = value;
			}
		}

		private EmployeeWorkTime workTime;
		public EmployeeWorkTime WorkTime
		{
			get
			{
				return workTime;
			}
			set
			{
				OnPropertyChanged(ref workTime, value);
				Employee.WorkTime = value;
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

		public Employee Employee { get; }

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		private readonly Dictionary<string, List<string>> propertyNameToError;

		public ObservableEmployee(Employee employee)
		{
			Employee = employee;
			propertyNameToError = new Dictionary<string, List<string>>();

			firstName = employee.FirstName;
			lastName = employee.LastName;
			phoneNumber = employee.PhoneNumber;
			employeeNumber = employee.EmployeeNumber;
			password = employee.Password;
			Department = employee.Department;
			role = employee.Role;
			workTime = employee.WorkTime;

			BasicStringFieldValidation(nameof(FirstName), FirstName);
			BasicStringFieldValidation(nameof(LastName), LastName);
			BasicStringFieldValidation(nameof(PhoneNumber), PhoneNumber);
			BasicStringFieldValidation(nameof(EmployeeNumber), EmployeeNumber);
			BasicStringFieldValidation(nameof(Password), Password);
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
