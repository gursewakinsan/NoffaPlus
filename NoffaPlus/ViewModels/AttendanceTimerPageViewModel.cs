using System;
using System.Timers;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class AttendanceTimerPageViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		int count = 8;
		#endregion

		#region Constructor.
		public AttendanceTimerPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 60000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			if (count < 9)
				DisplayCurrentTime = $"00:0{count = count + 1} ";
			else
				DisplayCurrentTime = $"00:{count = count + 1} ";
			DisplayCurrentDate = DateTime.Now.Date.ToString("dddd - MMMM dd");
			timer.Start();
		}
		#endregion

		#region Stop Attendance Timer Command.
		private ICommand stopAttendanceTimerCommand;
		public ICommand StopAttendanceTimerCommand
		{
			get => stopAttendanceTimerCommand ?? (stopAttendanceTimerCommand = new Command(async () => await ExecuteStopAttendanceTimerCommand()));
		}
		private async Task ExecuteStopAttendanceTimerCommand()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		private string displayCurrentTime = "00:00";
		public string DisplayCurrentTime
		{
			get => displayCurrentTime;
			set
			{
				displayCurrentTime = value;
				OnPropertyChanged("DisplayCurrentTime");
			}
		}

		private string displayCurrentDate = DateTime.Now.Date.ToString("dddd - MMMM dd");
		public string DisplayCurrentDate
		{
			get => displayCurrentDate;
			set
			{
				displayCurrentDate = value;
				OnPropertyChanged("DisplayCurrentDate");
			}
		}
		#endregion
	}
}
