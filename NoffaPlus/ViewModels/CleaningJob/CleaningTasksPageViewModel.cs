using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class CleaningTasksPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleaningTasksPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaning To Do List Command.
		private ICommand cleaningToDoListCommand;
		public ICommand CleaningToDoListCommand
		{
			get => cleaningToDoListCommand ?? (cleaningToDoListCommand = new Command(async () => await ExecuteCleaningToDoListCommand()));
		}
		private async Task ExecuteCleaningToDoListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICleaningJobService service = new CleaningJobService();
			CleaningToDoList = await service.CleaningServiceAvailableTodoDetailAsync(new Models.CleaningServiceAvailableTodoDetailRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Start Command.
		private ICommand startCommand;
		public ICommand StartCommand
		{
			get => startCommand ?? (startCommand = new Command(async () => await ExecuteStartCommand()));
		}
		private async Task ExecuteStartCommand()
		{
			await Navigation.PushAsync(new Views.CleaningJob.AssignTaskToStaffPage());
		}
		#endregion

		#region Properties.
		private List<Models.CleaningServiceAvailableTodoDetailResponse> cleaningToDoList;
		public List<Models.CleaningServiceAvailableTodoDetailResponse> CleaningToDoList
		{
			get => cleaningToDoList;
			set
			{
				cleaningToDoList = value;
				OnPropertyChanged("CleaningToDoList");
			}
		}
		#endregion
	}
}
