﻿using COMP_482_Assignment_03.Models;
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
	public class DialogWindowCreateItemViewModel : ObservableObject
	{
		public ICommand CreateCommand { get; }
		public ICommand CancelCommand { get; }

		public ObservableItem ObservableItem { get; }

		private readonly Item item;
		private readonly Window window;

		public DialogWindowCreateItemViewModel(Window _window)
		{
			window = _window;

			item = new Item("", "", "", "", "", 0, 0.00f, 0.00f, ItemCategory.one);
			ObservableItem = new ObservableItem(item);

			CreateCommand = new RelayCommand(Create);
			CancelCommand = new RelayCommand(Cancel);
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
