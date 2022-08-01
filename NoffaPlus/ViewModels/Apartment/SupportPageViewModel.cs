using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
    public class SupportPageViewModel : BaseViewModel
    {
		#region Constructor.
		public SupportPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Not Started Command.
		private ICommand notStartedCommand;
		public ICommand NotStartedCommand
		{
			get => notStartedCommand ?? (notStartedCommand = new Command(() => ExecuteNotStartedCommand()));
		}
		private void ExecuteNotStartedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.NotStartedPage());
		}
		#endregion

		#region Started Command.
		private ICommand startedCommand;
		public ICommand StartedCommand
		{
			get => startedCommand ?? (startedCommand = new Command(() => ExecuteStartedCommand()));
		}
		private void ExecuteStartedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.StartedPage());
		}
		#endregion

		#region Finished Command.
		private ICommand finishedCommand;
		public ICommand FinishedCommand
		{
			get => finishedCommand ?? (finishedCommand = new Command(() => ExecuteFinishedCommand()));
		}
		private void ExecuteFinishedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.FinishPage());
		}
		#endregion

		#region Cancelled Command.
		private ICommand cancelledCommand;
		public ICommand CancelledCommand
		{
			get => cancelledCommand ?? (cancelledCommand = new Command(() => ExecuteCancelledCommand()));
		}
		private void ExecuteCancelledCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.CancelledPage());
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
		}
		#endregion

		#region Apartment Community Ticket List Command.
		private ICommand apartmentCommunityTicketListCommand;
		public ICommand ApartmentCommunityTicketListCommand
		{
			get => apartmentCommunityTicketListCommand ?? (apartmentCommunityTicketListCommand = new Command(async () => await ExecuteApartmentCommunityTicketListCommand()));
		}
		private async Task ExecuteApartmentCommunityTicketListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IApartmentService service = new ApartmentService();
			var response = await service.ApartmentCommunityTicketListAsync(new Models.ApartmentCommunityTicketListRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId,
				ApartmentId = Helper.Helper.ApartmentId
			});
			if (response != null)
			{
				DisplayApartmentName = response.ApartmentName;
				NotStartedCount = response.NotStartedList?.Count ?? 0;
				StartedCount = response.StartedList?.Count ?? 0;
				FinishCount = response.FinishedList?.Count ?? 0;
				CancelledCount = response.CancelledList?.Count ?? 0;
				Helper.Helper.ApartmentCommunityTicketInfo = response;
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private string displayApartmentName;
		public string DisplayApartmentName
		{
			get => displayApartmentName;
			set
			{
				displayApartmentName = value;
				OnPropertyChanged("DisplayApartmentName");
			}
		}

		private int notStartedCount;
		public int NotStartedCount
		{
			get => notStartedCount;
			set
			{
				notStartedCount = value;
				OnPropertyChanged("NotStartedCount");
			}
		}

		private int startedCount;
		public int StartedCount
		{
			get => startedCount;
			set
			{
				startedCount = value;
				OnPropertyChanged("StartedCount");
			}
		}
		
		private int finishCount;
		public int FinishCount
		{
			get => finishCount;
			set
			{
				finishCount = value;
				OnPropertyChanged("FinishCount");
			}
		}
		
		private int cancelledCount;
		public int CancelledCount
		{
			get => cancelledCount;
			set
			{
				cancelledCount = value;
				OnPropertyChanged("CancelledCount");
			}
		}
		#endregion
	}
}
