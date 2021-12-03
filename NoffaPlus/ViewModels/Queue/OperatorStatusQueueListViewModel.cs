using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class OperatorStatusQueueListViewModel : BaseViewModel
	{
		#region Constructor.
		public OperatorStatusQueueListViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Operator Queue Waiting Command.
		private ICommand getOperatorQueueWaitingCommand;
		public ICommand GetOperatorQueueWaitingCommand
		{
			get => getOperatorQueueWaitingCommand ?? (getOperatorQueueWaitingCommand = new Command(async () => await ExecuteGetOperatorQueueWaitingCommand()));
		}
		private async Task ExecuteGetOperatorQueueWaitingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			WaitingList = await service.GetOperatorQueueWaitingListAsync(new Models.OperatorQueueListRequest()
			{
				QueueId = SelectedOperatorQueue.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Get Operator Queue Serving List Command.
		private ICommand getOperatorQueueServingListCommand;
		public ICommand GetOperatorQueueServingListCommand
		{
			get => getOperatorQueueServingListCommand ?? (getOperatorQueueServingListCommand = new Command(async () => await ExecuteGetOperatorQueueServingListCommand()));
		}
		private async Task ExecuteGetOperatorQueueServingListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			InserviceInfoList = await service.GetOperatorQueueServingListAsync(new Models.OperatorQueueListRequest()
			{
				QueueId = SelectedOperatorQueue.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Get Operator Queue Served List Command.
		private ICommand getOperatorQueueServedListCommand;
		public ICommand GetOperatorQueueServedListCommand
		{
			get => getOperatorQueueServedListCommand ?? (getOperatorQueueServedListCommand = new Command(async () => await ExecuteGetOperatorQueueServedListCommand()));
		}
		private async Task ExecuteGetOperatorQueueServedListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			ServicedInfoList = await service.OperatorQueueServedListAsync(new Models.OperatorQueueListRequest()
			{
				QueueId = SelectedOperatorQueue.Id
			});
			DependencyService.Get<IProgressBar>().Hide();
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

		#region Tab Selected Command.
		private ICommand tabSelectedCommand;
		public ICommand TabSelectedCommand
		{
			get => tabSelectedCommand ?? (tabSelectedCommand = new Command<string>((tabText) => ExecuteTabSelectedCommand(tabText)));
		}
		private void ExecuteTabSelectedCommand(string tabText)
		{
			IsWaiting = IsInService = IsServiced = false;
			switch (tabText)
			{
				case "Waiting":
					ListTopText = "Waiting to be served";
					WaitingButtonBg = Color.FromHex("#6263ED");
					InServiceButtonBg = Color.FromHex("#2A2A31");
					ServicedButtonBg = Color.FromHex("#2A2A31");
					IsWaiting = true;
					GetOperatorQueueWaitingCommand.Execute(null);
					break;
				case "In service":
					ListTopText = "People being served";
					WaitingButtonBg = Color.FromHex("#2A2A31");
					InServiceButtonBg = Color.FromHex("#6263ED");
					ServicedButtonBg = Color.FromHex("#2A2A31");
					IsInService = true;
					GetOperatorQueueServingListCommand.Execute(null);
					break;
				case "Served":
					ListTopText = "People that´s been served";
					WaitingButtonBg = Color.FromHex("#2A2A31");
					InServiceButtonBg = Color.FromHex("#2A2A31");
					ServicedButtonBg = Color.FromHex("#6263ED");
					IsServiced = true;
					GetOperatorQueueServedListCommand.Execute(null);
					break;
			}
			OperatorQueueWaitingCountCommand.Execute(null);
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

		#region Properties.
		public Models.OperatorQueueResponse SelectedOperatorQueue => Helper.Helper.SelectedOperatorQueue;

		private List<Models.OperatorQueueListResponse> waitingList;
		public List<Models.OperatorQueueListResponse> WaitingList
		{
			get => waitingList;
			set
			{
				waitingList = value;
				OnPropertyChanged("WaitingList");
			}
		}

		private List<Models.OperatorQueueListResponse> inserviceInfoList;
		public List<Models.OperatorQueueListResponse> InserviceInfoList
		{
			get => inserviceInfoList;
			set
			{
				inserviceInfoList = value;
				OnPropertyChanged("InserviceInfoList");
			}
		}

		private List<Models.OperatorQueueListResponse> servicedInfoList;
		public List<Models.OperatorQueueListResponse> ServicedInfoList
		{
			get => servicedInfoList;
			set
			{
				servicedInfoList = value;
				OnPropertyChanged("ServicedInfoList");
			}
		}

		private bool isWaiting = true;
		public bool IsWaiting
		{
			get => isWaiting;
			set
			{
				isWaiting = value;
				OnPropertyChanged("IsWaiting");
			}
		}

		private Color waitingButtonBg = Color.FromHex("#6263ED");
		public Color WaitingButtonBg
		{
			get => waitingButtonBg;
			set
			{
				waitingButtonBg = value;
				OnPropertyChanged("WaitingButtonBg");
			}
		}

		private bool isInService;
		public bool IsInService
		{
			get => isInService;
			set
			{
				isInService = value;
				OnPropertyChanged("IsInService");
			}
		}

		private Color inServiceButtonBg = Color.FromHex("#2A2A31");
		public Color InServiceButtonBg
		{
			get => inServiceButtonBg;
			set
			{
				inServiceButtonBg = value;
				OnPropertyChanged("InServiceButtonBg");
			}
		}

		private bool isServiced;
		public bool IsServiced
		{
			get => isServiced;
			set
			{
				isServiced = value;
				OnPropertyChanged("IsServiced");
			}
		}

		private Color servicedButtonBg = Color.FromHex("#2A2A31");
		public Color ServicedButtonBg
		{
			get => servicedButtonBg;
			set
			{
				servicedButtonBg = value;
				OnPropertyChanged("ServicedButtonBg");
			}
		}

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

		private string listTopText = "Waiting to be served";
		public string ListTopText
		{
			get => listTopText;
			set
			{
				listTopText = value;
				OnPropertyChanged("ListTopText");
			}
		}
		#endregion
	}
}
