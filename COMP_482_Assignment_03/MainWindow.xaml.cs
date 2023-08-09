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
		private readonly DispatcherTimer reAuthenticateTimer;
		private bool isRunning = true;

		public MainWindow()
		{
			InitializeComponent();

			notifyTimer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
			notifyTimer.Interval = TimeSpan.FromSeconds(15);
			notifyTimer.Tick += NotifyTimerTick;
			notifyTimer.Start();
			reAuthenticateTimer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
			reAuthenticateTimer.Interval = TimeSpan.FromSeconds(15);
			reAuthenticateTimer.Tick += ReAuthenticateTimerTick;
		}


		private void NotifyTimerTick(object? sender, EventArgs e)
		{
			reAuthenticateTimer.Start();
			notifyTimer.Stop();
			MessageBox.Show("No user activity in the last 15 seconds, you will need to re-authenticate in 15 seconds",
				"re-authenticate notification", MessageBoxButton.OK, MessageBoxImage.Information);
		}
		
		private void ReAuthenticateTimerTick(object? sender, EventArgs e)
		{
			MessageBox.Show("No user activity in the last 30 seconds, please re-authenticate", 
				"", MessageBoxButton.OK, MessageBoxImage.Information);
			notifyTimer.Start();
			reAuthenticateTimer.Stop();
		}
	}
}
