using COMP_482_Assignment_03.Utility;
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

namespace COMP_482_Assignment_03.Windows
{
	/// <summary>
	/// Interaction logic for SelectOrderDialogWindow.xaml
	/// </summary>
	public partial class SelectOrderDialogWindow : Window
	{
		public SelectOrderDialogWindow()
		{
			InitializeComponent();
			Submit_Btn.Command = new RelayCommand(Submit_Btn_Click);
			Cancel_Btn.Command = new RelayCommand(Cancel_Btn_Click);
		}

		private void Submit_Btn_Click()
		{
			DialogResult = true;
		}

		private void Cancel_Btn_Click()
		{
			DialogResult = false;
		}
	}
}
