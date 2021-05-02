using System;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class SickPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SickPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Update Leave Command.
		private ICommand updateLeaveCommand;
		public ICommand UpdateLeaveCommand
		{
			get => updateLeaveCommand ?? (updateLeaveCommand = new Command(async () => await ExecuteUpdateLeaveCommand()));
		}
		private async Task ExecuteUpdateLeaveCommand()
		{
			if (string.IsNullOrWhiteSpace(TotalLeaveDays))
				await Helper.Alert.DisplayAlert("Total leave days is required.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IAtendenceService service = new AtendenceService();
				int response = await service.UpdateLeaveAsync(new Models.UpdateLeaveRequest()
				{
					UserId = Helper.Helper.LoggedInUserId,
					CompanyId = Helper.Helper.CompanyId,
					DayLeave = Convert.ToInt32(TotalLeaveDays),
					LeaveDescription = LeaveDescription
				});
				await Navigation.PopAsync();
				DependencyService.Get<IProgressBar>().Hide();
			}
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

		public string TotalLeaveDays { get; set; }
		public string LeaveDescription { get; set; }
		#endregion
	}
}
