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

		private readonly DispatcherTimer timer;
		private bool isRunning = true;

		public MainWindow()
		{
			InitializeComponent();

			timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
			timer.Interval = TimeSpan.FromSeconds(30);
			timer.Tick += TimerTick;
			timer.Start();
		}

		private void TimerTick(object? sender, EventArgs e)
		{
			MessageBox.Show("timer: ", "re-athenticate", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
