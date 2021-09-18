using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class OperatorStatusQueueListViewModel : BaseViewModel
	{
		#region Constructor.
		public OperatorStatusQueueListViewModel(INavigation navigation)
		{
			Navigation = navigation;
			WaitingList = new ObservableCollection<WaitingListInfo>();
			InserviceInfoList = new ObservableCollection<WaitingListInfo>();
			ServicedInfoList = new ObservableCollection<WaitingListInfo>();

			for (int i = 1; i < 10; i++)
			{
				WaitingList.Add(new WaitingListInfo()
				{
					Name = $"Waiting {i}",
					TotalPerson = $"Total person {i}"
				});
			}

			for (int i = 1; i < 10; i++)
			{
				InserviceInfoList.Add(new WaitingListInfo()
				{
					Name = $"Inservice {i}",
					TotalPerson = $"Total person {i}"
				});
			}

			for (int i = 1; i < 10; i++)
			{
				ServicedInfoList.Add(new WaitingListInfo()
				{
					Name = $"Serviced {i}",
					TotalPerson = $"Total person {i}"
				});
			}
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
					break;
				case "In service":
					InServiceTabTextColor = Color.White;
					WaitingTabTextColor = Color.FromHex("#7d8fbe");
					ServicedTabTextColor = Color.FromHex("#7d8fbe");
					IsInService = true;
					break;
				case "Serviced":
					ServicedTabTextColor = Color.White;
					WaitingTabTextColor = Color.FromHex("#7d8fbe");
					InServiceTabTextColor = Color.FromHex("#7d8fbe");
					IsServiced = true;
					break;
			}
		}
		#endregion

		#region Properties.
		public ObservableCollection<WaitingListInfo> WaitingList { get; set; }
		public ObservableCollection<WaitingListInfo> InserviceInfoList { get; set; }
		public ObservableCollection<WaitingListInfo> ServicedInfoList { get; set; }

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
		#endregion
	}
}


public class WaitingListInfo
{
	public string Name { get; set; }
	public string TotalPerson { get; set; }
	public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(Name, 0);
}