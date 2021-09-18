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
			OperatorQueueList = await service.GetOperatorQueueAsync(new Models.OperatorQueueRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			});
			if (OperatorQueueList?.Count > 0)
				OperatorQueueAddress = OperatorQueueList[0].Address;
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
			await Navigation.PushAsync(new Views.Queue.OperatorStatusQueueListPage());
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
