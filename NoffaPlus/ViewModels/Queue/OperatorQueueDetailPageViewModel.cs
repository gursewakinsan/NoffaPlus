using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class OperatorQueueDetailPageViewModel : BaseViewModel
	{
		#region Constructor.
		public OperatorQueueDetailPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Done Today Command.
		private ICommand doneTodayCommand;
		public ICommand DoneTodayCommand
		{
			get => doneTodayCommand ?? (doneTodayCommand = new Command(async () => await ExecuteDoneTodayCommand()));
		}
		private async Task ExecuteDoneTodayCommand()
		{
			Helper.Helper.SelectedTabQueueText = "Serviced";
			Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Go To List Command.
		private ICommand goToListCommand;
		public ICommand GoToListCommand
		{
			get => goToListCommand ?? (goToListCommand = new Command(async () => await ExecuteGoToListCommand()));
		}
		private async Task ExecuteGoToListCommand()
		{
			Helper.Helper.SelectedTabQueueText = "Waiting";
			Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Next In Line Command.
		private ICommand nextInLineCommand;
		public ICommand NextInLineCommand
		{
			get => nextInLineCommand ?? (nextInLineCommand = new Command(async () => await ExecuteNextInLineCommand()));
		}
		private async Task ExecuteNextInLineCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			var response = await service.GetOperatorQueueWaitingListAsync(new Models.OperatorQueueListRequest()
			{
				QueueId = SelectedOperatorQueue.Id
			});
			if (response?.Count > 0)
			{
				Helper.Helper.QueueGuestId = response[0].Id;
				Application.Current.MainPage = new NavigationPage(new Views.Queue.WaitingGuestServicesDetailPage());
				await Task.CompletedTask;
			}
			else
				await Helper.Alert.DisplayAlert("No record found.");
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			Helper.Helper.SelectedTabQueueText = "Waiting";
			Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Operator Queue Waiting Count Command.
		private ICommand operatorQueueWaitingCountCommand;
		public ICommand OperatorQueueWaitingCountCommand
		{
			get => operatorQueueWaitingCountCommand ?? (operatorQueueWaitingCountCommand = new Command(async () => await ExecuteOperatorQueueWaitingCountCommand()));
		}
		private async Task ExecuteOperatorQueueWaitingCountCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			PersonInLine = await service.OperatorQueueWaitingCountAsync(new Models.OperatorQueueListRequest()
			{
				QueueId = SelectedOperatorQueue.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		public Models.OperatorQueueResponse SelectedOperatorQueue => Helper.Helper.SelectedOperatorQueue;

		private int personInLine;
		public int PersonInLine
		{
			get => personInLine;
			set
			{
				personInLine = value;
				OnPropertyChanged("PersonInLine");
			}
		}
		#endregion
	}
}
