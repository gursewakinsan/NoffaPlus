using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class CheckInGuestPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckInGuestPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Booking List For Front Desk Checkin Command.
		private ICommand hotelBookingListForFrontDeskCheckinCommand;
		public ICommand HotelBookingListForFrontDeskCheckinCommand
		{
			get => hotelBookingListForFrontDeskCheckinCommand ?? (hotelBookingListForFrontDeskCheckinCommand = new Command(async () => await ExecuteHotelBookingListForFrontDeskCheckinCommand()));
		}
		private async Task ExecuteHotelBookingListForFrontDeskCheckinCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			HotelBookingListForFrontDeskCheckinInfo = await service.HotelBookingListForFrontDeskCheckinAsync(new Models.HotelBookingRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.HotelBookingListForFrontDeskCheckinResponse> hotelBookingListForFrontDeskCheckinInfo;
		public List<Models.HotelBookingListForFrontDeskCheckinResponse> HotelBookingListForFrontDeskCheckinInfo
		{
			get => hotelBookingListForFrontDeskCheckinInfo;
			set
			{
				hotelBookingListForFrontDeskCheckinInfo = value;
				OnPropertyChanged("HotelBookingListForFrontDeskCheckinInfo");
			}
		}

		private Models.HotelBookingListForFrontDeskCheckinResponse selectedHotelBookingForFrontDeskCheckin;
		public Models.HotelBookingListForFrontDeskCheckinResponse SelectedHotelBookingForFrontDeskCheckin
		{
			get => selectedHotelBookingForFrontDeskCheckin;
			set
			{
				selectedHotelBookingForFrontDeskCheckin = value;
				OnPropertyChanged("SelectedHotelBookingForFrontDeskCheckin");
			}
		}
		#endregion
	}
}
