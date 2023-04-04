using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class AssignTaskToStaffPageViewModel : BaseViewModel
    {
		#region Constructor.
		public AssignTaskToStaffPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaners Assigned List Command.
		private ICommand cleanersAssignedListCommand;
		public ICommand CleanersAssignedListCommand
		{
			get => cleanersAssignedListCommand ?? (cleanersAssignedListCommand = new Command(async () => await ExecuteCleanersAssignedListCommand()));
		}
		private async Task ExecuteCleanersAssignedListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICleaningJobService service = new CleaningJobService();
			CleanersAssignedList = await service.CleanersAssignedListAsync(new Models.CleanersAssignedListRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Start Cleaning Job Command.
		private ICommand startCleaningJobCommand;
		public ICommand StartCleaningJobCommand
		{
			get => startCleaningJobCommand ?? (startCleaningJobCommand = new Command(async () => await ExecuteStartCleaningJobCommand()));
		}
		private async Task ExecuteStartCleaningJobCommand()
		{
			if (CleanersAssignedList?.Count > 0)
			{
				var checkedItem = CleanersAssignedList.FirstOrDefault(x => x.IsSelected);
				if (checkedItem != null)
				{
					DependencyService.Get<IProgressBar>().Show();
					ICleaningJobService service = new CleaningJobService();
					await service.StartCleaningJobAsync(new Models.StartCleaningJobRequest()
					{
						CleaningJobId = Helper.Helper.SelectedCleaningJob,
						CleanersActive = string.Join(", ", CleanersAssignedList.Select(x => x.Id))
					});
					Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
					DependencyService.Get<IProgressBar>().Hide();
				}
				else
					await Helper.Alert.DisplayAlert("Please select staff.");
			}
		}
		#endregion

		#region Properties.
		private List<Models.CleanersAssignedListResponse> cleanersAssignedList;
		public List<Models.CleanersAssignedListResponse> CleanersAssignedList
		{
			get => cleanersAssignedList;
			set
			{
				cleanersAssignedList = value;
				OnPropertyChanged("CleanersAssignedList");
			}
		}

		private bool isAllCheckedUnChecked;
		public bool IsAllCheckedUnChecked
		{
			get => isAllCheckedUnChecked;
			set
			{
				isAllCheckedUnChecked = value;
				OnPropertyChanged("IsAllCheckedUnChecked");
			}
		}
		#endregion
	}
}
