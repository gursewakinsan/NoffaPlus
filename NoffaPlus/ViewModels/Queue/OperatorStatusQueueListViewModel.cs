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
					WaitingTabTextColor = Color.White;
					InServiceTabTextColor = Color.FromHex("#7d8fbe");
					ServicedTabTextColor = Color.FromHex("#7d8fbe");
					IsWaiting = true;
					GetOperatorQueueWaitingCommand.Execute(null);
					break;
				case "In service":
					InServiceTabTextColor = Color.White;
					WaitingTabTextColor = Color.FromHex("#7d8fbe");
					ServicedTabTextColor = Color.FromHex("#7d8fbe");
					IsInService = true;
					GetOperatorQueueServingListCommand.Execute(null);
					break;
				case "Serviced":
					ServicedTabTextColor = Color.White;
					WaitingTabTextColor = Color.FromHex("#7d8fbe");
					InServiceTabTextColor = Color.FromHex("#7d8fbe");
					IsServiced = true;
					GetOperatorQueueServedListCommand.Execute(null);
					break;
			}
			OperatorQueueWaitingCountCommand.Execute(null);
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

		private Color waitingTabTextColor= Color.White;
		public Color WaitingTabTextColor
		{
			get => waitingTabTextColor;
			set
			{
				waitingTabTextColor = value;
				OnPropertyChanged("WaitingTabTextColor");
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

		private Color inServiceTabTextColor = Color.FromHex("#7d8fbe");
		public Color InServiceTabTextColor
		{
			get => inServiceTabTextColor;
			set
			{
				inServiceTabTextColor = value;
				OnPropertyChanged("InServiceTabTextColor");
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

		private Color servicedTabTextColor = Color.FromHex("#7d8fbe");
		public Color ServicedTabTextColor
		{
			get => servicedTabTextColor;
			set
			{
				servicedTabTextColor = value;
				OnPropertyChanged("ServicedTabTextColor");
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
		#endregion
	}
}
