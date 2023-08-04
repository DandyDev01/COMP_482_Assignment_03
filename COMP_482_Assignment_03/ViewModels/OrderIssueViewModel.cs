using COMP_482_Assignment_03.Commands;
using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Models.SelectOrderData;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections;
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
	public class OrderIssueViewModel : ObservableObject, INotifyDataErrorInfo
	{
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }
		public ICommand SelectOrderCommand { get; }

		public ObservableCollection<OrderIssue> OpenOrderIssues { get; }
		public ICollectionView OpenOrderIssuesCollectionView { get; }
		public Array IssueTypes { get; } = Enum.GetValues(typeof(IssueType));
		public Array Departments { get; } = Enum.GetValues(typeof(StoreDepartment));
		public string Date { get; }

		private IssueType selectedIssueType;
		public IssueType SelectedIssueType
		{
			get
			{
				return selectedIssueType;
			}
			set
			{
				OnPropertyChanged(ref selectedIssueType, value);
			}
		}

		private StoreDepartment selectedDepartment;
		public StoreDepartment SelectedDepartment
		{
			get
			{
				return selectedDepartment;
			}
			set
			{
				OnPropertyChanged(ref selectedDepartment, value);
			}
		}

		private string issueDescription;
		public string IssueDescription
		{
			get
			{
				return issueDescription;
			}
			set
			{
				OnPropertyChanged(ref issueDescription, value);
				BasicStringFieldValidation(nameof(IssueDescription), IssueDescription);
			}
		}

		private string employeeName;
		public string EmployeeName
		{
			get
			{
				return employeeName;
			}
			set
			{
				OnPropertyChanged(ref employeeName, value);
				BasicStringFieldValidation(nameof(EmployeeName), EmployeeName);
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
			}
		}

		private StoreOrder selectedOrder;
		public StoreOrder SelectedOrder
		{
			get
			{
				return selectedOrder;
			}
			set
			{
				OnPropertyChanged(ref selectedOrder, value);
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

		private string issueDescriptionErrors;
		public string IssueDescriptionErrors
		{
			get
			{
				return issueDescriptionErrors;
			}
			set
			{
				OnPropertyChanged(ref issueDescriptionErrors, value);
			}
		}

		private string employeeNameErrors;
		public string EmployeeNameErrors
		{
			get
			{
				return employeeNameErrors;
			}
			set
			{
				OnPropertyChanged(ref employeeNameErrors, value);
			}
		}

		private string employeeNumberErrors;
		public string EmployeeNumberErrors
		{
			get
			{
				return employeeNumberErrors;
			}
			set
			{
				OnPropertyChanged(ref employeeNumberErrors, value);
			}
		}

		private readonly CollectionViewPropertySort collectionViewPropertySort;
		private readonly OrderIssueTracker orderIssueTracker;
		private readonly Dictionary<string, List<string>> propertyNameToError;

		public bool HasErrors => propertyNameToError.Any();
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		public OrderIssueViewModel(OrderIssueTracker _orderIssueTracker, OrderTracker _orderTracker)
		{
			orderIssueTracker = _orderIssueTracker;

			OpenOrderIssues = new ObservableCollection<OrderIssue>();
			OpenOrderIssuesCollectionView = CollectionViewSource.GetDefaultView(OpenOrderIssues);

			collectionViewPropertySort = new CollectionViewPropertySort(OpenOrderIssuesCollectionView);
			propertyNameToError = new Dictionary<string, List<string>>();

			Date = DateTime.Now.ToString("yyyy-MMM-ddd-dd");
			employeeName = string.Empty;
			employeeNumber = string.Empty;
			issueDescription = string.Empty;

			employeeNameErrors = string.Empty;
			employeeNumberErrors = string.Empty;
			issueDescriptionErrors = string.Empty;

			SubmitCommand = new RelayCommand(Submit);
			CancelCommand = new RelayCommand(Cancel);
			SelectOrderCommand = new SelectOrderCommand(_orderTracker, new SelectOrderForOrderIssueData(this));

			ErrorsChanged += UpdateErrorMessages;

			BasicStringFieldValidation(nameof(EmployeeName), EmployeeName);
			BasicStringFieldValidation(nameof(EmployeeNumber), EmployeeNumber);
			BasicStringFieldValidation(nameof(IssueDescription), IssueDescription);
		}

		private void Cancel()
		{
			EmployeeName = string.Empty;
			EmployeeNumber = string.Empty;
			IssueDescription = string.Empty;
		}

		private void Submit()
		{
			Random random = new Random();

			string issueID = random.Next(10000, 99999).ToString();
			OrderIssue newIssue = new OrderIssue(issueID, issueID, IssueDescription, EmployeeName, employeeNumber,
				SelectedDepartment, SelectedIssueType);

			orderIssueTracker.Add(newIssue);
			OpenOrderIssues.Add(newIssue);

			EmployeeName = string.Empty;
			EmployeeNumber = string.Empty;
			IssueDescription = string.Empty;
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

		private void UpdateErrorMessages(object? sender, DataErrorsChangedEventArgs e)
		{
			employeeNameErrors = string.Empty;
			employeeNumberErrors = string.Empty;
			issueDescriptionErrors = string.Empty;

			foreach (var item in GetErrors(nameof(EmployeeName)))
			{
				EmployeeNameErrors += item + "\r\n";
			}

			foreach (var item in GetErrors(nameof(IssueDescription)))
			{
				IssueDescriptionErrors += item + "\r\n";
			}

			foreach (var item in GetErrors(nameof(EmployeeNumber)))
			{
				EmployeeNumberErrors += item + "\r\n";
			}
		}
	}
}
