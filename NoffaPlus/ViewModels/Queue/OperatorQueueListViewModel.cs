using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class OperatorQueueListViewModel : BaseViewModel
	{
		#region Constructor.
		public OperatorQueueListViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Operator Queue Command.
		private ICommand getContactsCommand;
		public ICommand GetOperatorQueueCommand
		{
			get => getContactsCommand ?? (getContactsCommand = new Command(async () => await ExecuteGetOperatorQueueCommand()));
		}
		private async Task ExecuteGetOperatorQueueCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			var operatorQueue = await service.GetOperatorQueueAsync(new Models.OperatorQueueRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			});
			if (operatorQueue?.Count > 0)
				OperatorQueueAddress = operatorQueue[0].Address;

			int index = 0;
			foreach (var queue in operatorQueue)
			{
				queue.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
				queue.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
				index = index + 1;
			}
			OperatorQueueList = operatorQueue;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Operator Status Queue List Command.
		private ICommand goToOperatorStatusQueueListCommand;
		public ICommand GoToOperatorStatusQueueListCommand
		{
			get => goToOperatorStatusQueueListCommand ?? (goToOperatorStatusQueueListCommand = new Command(async () => await ExecuteGoToOperatorStatusQueueListCommand()));
		}
		private async Task ExecuteGoToOperatorStatusQueueListCommand()
		{
			Helper.Helper.SelectedTabQueueText = "Waiting";
			await Navigation.PushAsync(new Views.Queue.OperatorStatusQueueListPage());
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
			Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private List<Models.OperatorQueueResponse> operatorQueueList;
		public List<Models.OperatorQueueResponse> OperatorQueueList
		{
			get => operatorQueueList;
			set
			{
				operatorQueueList = value;
				OnPropertyChanged("OperatorQueueList");
			}
		}

		private string operatorQueueAddress;
		public string OperatorQueueAddress
		{
			get => operatorQueueAddress;
			set
			{
				operatorQueueAddress = value;
				OnPropertyChanged("OperatorQueueAddress");
			}
		}
		#endregion
	}
}
