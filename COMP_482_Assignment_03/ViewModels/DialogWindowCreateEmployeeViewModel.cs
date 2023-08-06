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
		public ICommand CreateCommand { get; }
		public ICommand CancelCommand { get; }

		public Employee Employee { get; }

		public Array WorkTimes { get; } = Enum.GetValues(typeof(EmployeeWorkTime));
		public Array Departments { get; } = Enum.GetValues(typeof(StoreDepartment));
		public Array Roles{ get; } = Enum.GetValues(typeof(EmployeeRole));

		private readonly Window window;

		public DialogWindowCreateEmployeeViewModel(Window _window)
		{
			window = _window;
			Employee = new Employee("","","","", StoreDepartment.Grocery, EmployeeRole.StoreManager, 
				EmployeeWorkTime.FullTime);

			CreateCommand = new RelayCommand(Create);
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
