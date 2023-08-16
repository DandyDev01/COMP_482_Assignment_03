using System;
using System.Collections.Generic;
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

using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Controls.Primitives;
using COMP_482_Assignment_03.ViewModels;
using System.ComponentModel;

namespace COMP_482_Assignment_03.Windows
{
	/// <summary>
	/// Interaction logic for UserLoginDialogWindow.xaml
	/// </summary>
	public partial class UserLoginDialogWindow : Window
	{
		public UserLoginDialogWindow()
		{
			InitializeComponent();
			EmployeeNumberTextBox.Focus();
			Closing += Check;
		}

		private void Check(object? sender, CancelEventArgs e)
		{ 
			if (((DialogWindowUserLoginViewModel)DataContext).MainWindowVM.LoggedInEmployee == null)
			{
				e.Cancel = true;
			}
		}
	}
}
