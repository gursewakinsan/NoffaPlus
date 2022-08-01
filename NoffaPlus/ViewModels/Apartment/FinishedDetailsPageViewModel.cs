using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
    public class FinishedDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public FinishedDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Apartment Community Ticket Detail Command.
		private ICommand apartmentCommunityTicketDetailCommand;
		public ICommand ApartmentCommunityTicketDetailCommand
		{
			get => apartmentCommunityTicketDetailCommand ?? (apartmentCommunityTicketDetailCommand = new Command(async () => await ExecuteApartmentCommunityTicketDetailCommand()));
		}
		private async Task ExecuteApartmentCommunityTicketDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IApartmentService service = new ApartmentService();
			var response = await service.ApartmentCommunityTicketDetailAsync(new Models.ApartmentCommunityTicketDetailRequest()
			{
				Id = SelectedApartmentCommunityTicket.Id
			});
			if (response.Images?.Count == 0)
			{
				IsApartmentNoImageAvailable = true;
			}
			else if (response.Images?.Count == 1)
			{
				IsApartmentNoImageAvailable = false;
				int deviceWidth = App.ScreenWidth - 56;
				foreach (var item in response.Images)
					item.ItemWidth = deviceWidth;
			}
			else if (response.Images?.Count > 1)
			{
				IsApartmentNoImageAvailable = false;
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 85 / 100;
				foreach (var item in response.Images)
					item.ItemWidth = imgWidth;
			}
			ApartmentCommunityTicketDetail = response;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.ApartmentCommunityTicketDetailResponse apartmentCommunityTicketDetail;
		public Models.ApartmentCommunityTicketDetailResponse ApartmentCommunityTicketDetail
		{
			get => apartmentCommunityTicketDetail;
			set
			{
				apartmentCommunityTicketDetail = value;
				OnPropertyChanged("ApartmentCommunityTicketDetail");
			}
		}

		private bool isApartmentNoImageAvailable = false;
		public bool IsApartmentNoImageAvailable
		{
			get => isApartmentNoImageAvailable;
			set
			{
				isApartmentNoImageAvailable = value;
				OnPropertyChanged("IsApartmentNoImageAvailable");
			}
		}
		public ApartmentCommunityTicketModel SelectedApartmentCommunityTicket { get; set; }
		#endregion
	}
}
