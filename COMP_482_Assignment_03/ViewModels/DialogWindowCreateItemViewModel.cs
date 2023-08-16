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

		private string sellPriceErrors;
		public string SellPriceErrors
		{
			get
			{
				return sellPriceErrors;
			}
			set
			{
				OnPropertyChanged(ref sellPriceErrors, value);
			}
		}

		private string buyPriceErrors;
		public string BuyPriceErrors
		{
			get
			{
				return buyPriceErrors;
			}
			set
			{
				OnPropertyChanged(ref buyPriceErrors, value);
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
		private readonly InventoryViewModel inventoryVM;

		public DialogWindowCreateItemViewModel(Window _window, InventoryViewModel _inventryVM)
		{
			window = _window;
			inventoryVM = _inventryVM;

			item = new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.Frozen, StoreDepartment.Grocery);
			ObservableItem = new ObservableItem(item);
			ObservableItem.ErrorsChanged += UpdateErrorMessages;

			nameErrors = string.Empty;
			idErrors = string.Empty;
			brandErrors = string.Empty;
			sellPriceErrors = string.Empty;
			buyPriceErrors = string.Empty;
			quantityErrors = string.Empty;

			SubmitCommand = new RelayCommand(Create);
			CancelCommand = new RelayCommand(Cancel);
		}

		public DialogWindowCreateItemViewModel(Window _window, InventoryViewModel _inventryVM, Item _item) 
			: this(_window, _inventryVM)
		{
			ObservableItem.ErrorsChanged -= UpdateErrorMessages;
			ObservableItem = new ObservableItem(_item);
			ObservableItem.ErrorsChanged += UpdateErrorMessages;
		}

		private void UpdateErrorMessages(object? sender, DataErrorsChangedEventArgs e)
		{
			NameErrors = string.Empty;
			IDErrors = string.Empty;
			BrandErrors = string.Empty;
			SellPriceErrors = string.Empty;
			BuyPriceErrors = string.Empty;

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

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.SellPrice)))
			{
				SellPriceErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.BuyPrice)))
			{
				BuyPriceErrors += item + "\r\n";
			}

			foreach (var item in ObservableItem.GetErrors(nameof(ObservableItem.Quantity)))
			{
				QuantityErrors += item + "\r\n";
			}
		}

		private void Create()
		{

			Item item = inventoryVM.ItemsListVM.Items.Where(x => x.ID.Equals(ObservableItem.ID, 
				StringComparison.OrdinalIgnoreCase) && x != ObservableItem.Item).FirstOrDefault();

			// an item with some ID already exists and that item is not the item 
			// being edited
			if (item != null && item != ObservableItem.Item)
			{
				ObservableItem.InvokeError(nameof(ObservableItem.ID), "Item with ID already exists");

				return;
			}

			window.DialogResult = true;
		}

		private void Cancel()
		{
			window.DialogResult = false;
		}
	}
}
