using COMP_482_Assignment_03.Utility;
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
		private readonly DispatcherTimer notifyTimer;

		public MainWindow()
		{
			InitializeComponent();

			notifyTimer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
			notifyTimer.Interval = TimeSpan.FromSeconds(UserPrefs.ForcedLogOutTime);
			notifyTimer.Tick += NotifyTimerTick;
			notifyTimer.Start();
		}

		private void NotifyTimerTick(object? sender, EventArgs e)
		{
			notifyTimer.Stop();

			TimerCountDownDialogWindow window = new TimerCountDownDialogWindow();
			window.OnTimerFinish += ReAuthenticateTimerTick;
			window.ShowDialog();

			notifyTimer.Start();
		}
		
		private void ReAuthenticateTimerTick(object? sender, EventArgs e)
		{
			UserLoginDialogWindow window = new UserLoginDialogWindow();
			window.ShowDialog();
			
		}
	}
}
