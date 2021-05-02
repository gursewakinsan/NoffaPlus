using System;
using System.Timers;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class AttendanceTimerPageViewModel : BaseViewModel
	{
		#region Local Variable.
		Timer timer;
		int count = 0;
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
			DependencyService.Get<IProgressBar>().Show();
			IAtendenceService service = new AtendenceService();
			int response = await service.UpdateExitAsync(new Models.UpdateExitRequest()
			{
				Eid = EmployeeTime.Eid
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Check Employee Time Command.
		private ICommand checkEmployeeTimeCommand;
		public ICommand CheckEmployeeTimeCommand
		{
			get => checkEmployeeTimeCommand ?? (checkEmployeeTimeCommand = new Command(async () => await ExecuteCheckEmployeeTimeCommand()));
		}
		private async Task ExecuteCheckEmployeeTimeCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAtendenceService service = new AtendenceService();
			EmployeeTime = await service.CheckEmployeeTimeAsync(new Models.EmployeeAtendenceRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			});
			DependencyService.Get<IProgressBar>().Hide();
			string hours = "00";
			string minutes = "00";
			if (EmployeeTime.DiffHr > 0)
			{
				if (EmployeeTime.DiffHr < 10)
					hours = $"0{EmployeeTime.DiffHr}";
				else
					hours = $"{EmployeeTime.DiffHr}";
			}

			if (EmployeeTime.DiffM > 0)
			{
				if (EmployeeTime.DiffM < 10)
					minutes = $"0{EmployeeTime.DiffM}";
				else
					minutes = $"{EmployeeTime.DiffM}";
			}
			count = EmployeeTime.DiffM;
			timer.Stop();
			timer.Start();
			DisplayCurrentTime = $"{hours}:{minutes}";
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

		public Models.EmployeeAtendenceResponse EmployeeTime { get; set; }
		#endregion
	}
}
