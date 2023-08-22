using COMP_482_Assignment_03.Models;
using COMP_482_Assignment_03.Utility;
using COMP_482_Assignment_03.ViewModels;
using COMP_482_Assignment_03.Views;
using COMP_482_Assignment_03.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace COMP_482_Assignment_03
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainWindowViewModel mainWindowVM;
		private readonly DispatcherTimer notifyTimer;

		public MainWindow()
		{
			InitializeComponent();

			createOrderMenuItem.Command = new RelayCommand(CreateOrder);
			createOrderIssueMenuItem.Command = new RelayCommand(CreateOrderIssue);
			mainWindowVM = (MainWindowViewModel)DataContext;
			mainWindowVM.OnLoggedInEmployeeChanged += LoggedInUserChanged;
			mainWindowVM.UserSignIn();

			this.InputBindings.Add(new KeyBinding(createOrderMenuItem.Command, Key.O, ModifierKeys.Control));
			this.InputBindings.Add(new KeyBinding(createOrderIssueMenuItem.Command, Key.J, ModifierKeys.Control));

			tabControl.SelectedIndex = 1;
			OrdersView ordersView = (OrdersView)tabControl.SelectedContent;
			ordersView.CreateOrderButton.Command = new RelayCommand(CreateOrder);
			tabControl.SelectedIndex = 0;

			//notifyTimer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
			//notifyTimer.Interval = TimeSpan.FromSeconds(UserPrefs.ForcedLogOutTime);
			//notifyTimer.Tick += NotifyTimerTick;
			//notifyTimer.Start();
		}

		private void CreateOrderIssue()
		{
			tabControl.SelectedIndex = 3;
		}

		private void CreateOrder()
		{
			tabControl.SelectedIndex = 0;
		}

		private void NotifyTimerTick(object? sender, EventArgs e)
		{
			//notifyTimer.Stop();

			//MainWindowViewModel mainWindowVM = DataContext as MainWindowViewModel;

			//TimerCountDownDialogWindow window = new TimerCountDownDialogWindow();
			//window.OnTimerFinish += mainWindowVM.UserSignIn;
			//window.ShowDialog();

			//notifyTimer.Start();
		}

		private void LoggedInUserChanged(Employee employee)
		{
			tabControl.SelectedIndex = 0;
		}
	}
}
