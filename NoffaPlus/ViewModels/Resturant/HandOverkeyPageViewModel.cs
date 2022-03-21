using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class HandOverkeyPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HandOverkeyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Booking List For Front Desk Key Handling Command.
		private ICommand hotelBookingListForFrontDeskKeyHandlingCommand;
		public ICommand HotelBookingListForFrontDeskKeyHandlingCommand
		{
			get => hotelBookingListForFrontDeskKeyHandlingCommand ?? (hotelBookingListForFrontDeskKeyHandlingCommand = new Command(async () => await ExecuteHotelBookingListForFrontDeskKeyHandlingCommand()));
		}
		private async Task ExecuteHotelBookingListForFrontDeskKeyHandlingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			var responses = await service.HotelBookingListForFrontDeskKeyHandlingAsync(new Models.HotelBookingListForFrontDeskKeyHandlingRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			HotelBookingListForFrontDeskKeyHandlingInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskKeyHandlingResponse>(responses);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Hand Over Key Command.
		private ICommand submitHandOverKeyCommand;
		public ICommand SubmitHandOverKeyCommand
		{
			get => submitHandOverKeyCommand ?? (submitHandOverKeyCommand = new Command<int>(async (selectedHandOverKey) => await ExecuteSubmitHandOverKeyCommand(selectedHandOverKey)));
		}
		private async Task ExecuteSubmitHandOverKeyCommand(int selectedHandOverKey)
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			var responses = await service.HandOverKeyAsync(new Models.HandoverKeyRequest()
			{
				Id = selectedHandOverKey
			});
			await Navigation.PopAsync();
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.HotelBookingListForFrontDeskKeyHandlingResponse> hotelBookingListForFrontDeskKeyHandlingInfo;
		public ObservableCollection<Models.HotelBookingListForFrontDeskKeyHandlingResponse> HotelBookingListForFrontDeskKeyHandlingInfo
		{
			get => hotelBookingListForFrontDeskKeyHandlingInfo;
			set
			{
				hotelBookingListForFrontDeskKeyHandlingInfo = value;
				OnPropertyChanged("HotelBookingListForFrontDeskKeyHandlingInfo");
			}
		}

		private bool isSubmitVisible = false;
		public bool IsSubmitVisible
		{
			get => isSubmitVisible;
			set
			{
				isSubmitVisible = value;
				OnPropertyChanged("IsSubmitVisible");
			}
		}
		#endregion
	}
}
