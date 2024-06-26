﻿using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace COMP_482_Assignment_03.Windows
{
	/// <summary>
	/// Interaction logic for SelectItemsDialogWindow.xaml
	/// </summary>
	public partial class SelectItemsDialogWindow : Window
	{
		private readonly int maxSelections;
		private int numberSelected;

		public SelectItemsDialogWindow(int _maxSelections)
		{
			InitializeComponent();
			maxSelections = _maxSelections;

			seachBox.Focus();

			this.InputBindings.Add(new KeyBinding(new RelayCommand(Delete), Key.Delete, ModifierKeys.None));
			list.SelectionChanged += ToggleItemSelection;
		}

		private void ToggleItemSelection(object sender, SelectionChangedEventArgs e)
		{
			if (list.SelectedItem == null)
				return;

			ObservableItem item = list.SelectedItem as ObservableItem;
			item.IsSelected = !item.IsSelected;

			if (maxSelections == -1)
				return;

			if (item.IsSelected)
			{
				numberSelected += 1;
				if (numberSelected > maxSelections)
				{
					item.IsSelected = false;
					numberSelected -= 1;
				}
			}
			else
			{
				numberSelected -= 1;
			}

			list.SelectedItem = null;
		}

		private void Delete()
		{
			DialogWindowSelectedItemsViewModel viewModel = (DialogWindowSelectedItemsViewModel)DataContext;

			if (viewModel.SelectItemsData is SelectItemsForOrderData)
				return;

			viewModel.SubmitCommand.Execute(null);
		}
	}
}
