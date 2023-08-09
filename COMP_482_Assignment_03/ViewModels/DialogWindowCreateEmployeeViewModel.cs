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
	public class DialogWindowCreateEmployeeViewModel : ObservableObject
	{
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public ObservableEmployee ObservableEmployee { get; }

		public Array WorkTimes { get; } = Enum.GetValues(typeof(EmployeeWorkTime));
		public Array Departments { get; } = Enum.GetValues(typeof(StoreDepartment));
		public Array Roles { get; } = Enum.GetValues(typeof(EmployeeRole));

		private readonly Window window;

		public DialogWindowCreateEmployeeViewModel(Window _window)
		{
			window = _window;
			Employee employee = new Employee("","","","", "", StoreDepartment.Grocery, EmployeeRole.StoreManager, 
				EmployeeWorkTime.FullTime);
			ObservableEmployee = new ObservableEmployee(employee);

			SubmitCommand = new RelayCommand(Create);
			CancelCommand = new RelayCommand(Cancel);
		}

		public DialogWindowCreateEmployeeViewModel(Window _window, Employee _employee)
		{
			window = _window;
			ObservableEmployee = new ObservableEmployee(_employee);

			SubmitCommand = new RelayCommand(Create);
			CancelCommand = new RelayCommand(Cancel);
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}

		private void Create()
		{
			window.DialogResult = true;
		}
	}
}
