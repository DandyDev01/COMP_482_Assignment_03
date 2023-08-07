using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace COMP_482_Assignment_03.ViewModels
{
	public class DialogWindowCreateItemViewModel : ObservableObject
	{
		public ICommand SubmitCommand { get; }
		public ICommand CancelCommand { get; }

		public ObservableItem ObservableItem { get; }

		public Array Categories { get; } = Enum.GetValues(typeof(ItemCategory));
		public Array Departments { get; } = Enum.GetValues(typeof(StoreDepartment));

		private string nameErrors;
		public string NameErrors
		{
			get
			{
				return nameErrors;
			}
			set
			{
				OnPropertyChanged(ref nameErrors, value);
			}
		}

		private string idErrors;
		public string IDErrors
		{
			get
			{
				return idErrors;
			}
			set
			{
				OnPropertyChanged(ref idErrors, value);
			}
		}

		private string brandErrors;
		public string BrandErrors
		{
			get
			{
				return brandErrors;
			}
			set
			{
				OnPropertyChanged(ref brandErrors, value);
			}
		}

		private string retailCostErrors;
		public string RetailCostErrors
		{
			get
			{
				return retailCostErrors;
			}
			set
			{
				OnPropertyChanged(ref retailCostErrors, value);
			}
		}

		private string costErrors;
		public string CostErrors
		{
			get
			{
				return costErrors;
			}
			set
			{
				OnPropertyChanged(ref costErrors, value);
			}
		}

		private string quantityErrors;

		public string QuantityErrors
		{
			get
			{
				return quantityErrors;
			}
			set
			{
				OnPropertyChanged(ref quantityErrors, value);
			}
		}

		private readonly Item item;
		private readonly Window window;

		public DialogWindowCreateItemViewModel(Window _window)
		{
			window = _window;

			item = new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.Frozen, StoreDepartment.Grocery);
			ObservableItem = new ObservableItem(item);
			ObservableItem.ErrorsChanged += UpdateErrorMessages;

			nameErrors = string.Empty;
			idErrors = string.Empty;
			brandErrors = string.Empty;
			retailCostErrors = string.Empty;
			costErrors = string.Empty;
			quantityErrors = string.Empty;

			SubmitCommand = new RelayCommand(Create);
			CancelCommand = new RelayCommand(Cancel);
		}

		public DialogWindowCreateItemViewModel(Window _window, Item _item) : this(_window)
		{
			ObservableItem = new ObservableItem(_item);
		}

		private void UpdateErrorMessages(object? sender, DataErrorsChangedEventArgs e)
		{
			NameErrors = string.Empty;
			IDErrors = string.Empty;
			BrandErrors = string.Empty;
			RetailCostErrors = string.Empty;
			CostErrors = string.Empty;

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.Name)))
			{
				NameErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.ID)))
			{
				IDErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.Brand)))
			{
				BrandErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.RetailCost)))
			{
				RetailCostErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.Cost)))
			{
				CostErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.Quantity)))
			{
				QuantityErrors += item + "\r\n";
			}
		}

		private void Create()
		{
			window.DialogResult = true;
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}
	}
}
