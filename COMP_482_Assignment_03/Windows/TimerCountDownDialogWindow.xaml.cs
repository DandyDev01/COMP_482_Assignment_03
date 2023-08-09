using COMP_482_Assignment_03.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace COMP_482_Assignment_03.Windows
{
	/// <summary>
	/// Interaction logic for TimerCountDownDialogWindow.xaml
	/// </summary>
	public partial class TimerCountDownDialogWindow : Window
	{
		public Action? OnTimerFinish { get; set; }

		private readonly DispatcherTimer timer;
		private int timeTillFinish = UserPrefs.ForcedLogOutTime;

		public TimerCountDownDialogWindow()
		{
			InitializeComponent();

			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += update;
			timer.Start();

			content_label.Content = "Forced logout in " + timeTillFinish + "s";
			
			ok_button.Command = new RelayCommand(ok_button_clicked);

			Closed += HandleClose;
		}

		private void HandleClose(object? sender, EventArgs e)
		{
			Closed -= HandleClose;
			OnTimerFinish = null;
		}

		private void update(object? sender, EventArgs e)
		{
			timeTillFinish -= 1;
			content_label.Content = "Forced logout in " + timeTillFinish + "s";

			if (timeTillFinish <= 0)
			{
				OnTimerFinish?.Invoke();
				timer.Stop();
				timeTillFinish = UserPrefs.ForcedLogOutTime;
				Close();
			}
		}

		private void ok_button_clicked()
		{
			DialogResult = true;
			timer.Stop();
			timeTillFinish = UserPrefs.ForcedLogOutTime;
		}

	}
}
