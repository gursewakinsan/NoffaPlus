using Xamarin.Forms;
using Xamarin.Essentials;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
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

		#region Adults Minus Command.
		private ICommand adultsMinusCommand;
		public ICommand AdultsMinusCommand
		{
			get => adultsMinusCommand ?? (adultsMinusCommand = new Command( () => ExecuteAdultsMinusCommand()));
		}
		private void ExecuteAdultsMinusCommand()
		{
			if (AdultsCount > 1)
				AdultsCount = AdultsCount - 1;
		}
		#endregion

		#region Adults Plus Command.
		private ICommand adultsPlusCommand;
		public ICommand AdultsPlusCommand
		{
			get => adultsPlusCommand ?? (adultsPlusCommand = new Command(() => ExecuteAdultsPlusCommand()));
		}
		private void ExecuteAdultsPlusCommand()
		{
			if (AdultsCount < SelectedHotelBookingForFrontDeskCheckin.GuestAdult)
				AdultsCount = AdultsCount + 1;
		}
		#endregion

		#region Children Minus Command.
		private ICommand childrenMinusCommand;
		public ICommand ChildrenMinusCommand
		{
			get => childrenMinusCommand ?? (childrenMinusCommand = new Command(() => ExecuteChildrenMinusCommand()));
		}
		private void ExecuteChildrenMinusCommand()
		{
			if (ChildrenCount > 0)
				ChildrenCount = ChildrenCount - 1;
		}
		#endregion

		#region Children Plus Command.
		private ICommand childrenPlusCommand;
		public ICommand ChildrenPlusCommand
		{
			get => childrenPlusCommand ?? (childrenPlusCommand = new Command(() => ExecuteChildrenPlusCommand()));
		}
		private void ExecuteChildrenPlusCommand()
		{
			if (ChildrenCount < SelectedHotelBookingForFrontDeskCheckin.GuestChildren)
				ChildrenCount = ChildrenCount + 1;
		}
		#endregion

		#region Submit Front Desk Checked In Hotel Request Command.
		private ICommand submitFrontDeskCheckedInHotelRequestCommand;
		public ICommand SubmitFrontDeskCheckedInHotelRequestCommand
		{
			get => submitFrontDeskCheckedInHotelRequestCommand ?? (submitFrontDeskCheckedInHotelRequestCommand = new Command(async () => await ExecuteSubmitFrontDeskCheckedInHotelRequestCommand()));
		}
		private async Task ExecuteSubmitFrontDeskCheckedInHotelRequestCommand()
		{
			Models.GetFrontDeskCheckedInHotelRequest request = new Models.GetFrontDeskCheckedInHotelRequest()
			{
				Id = SelectedHotelBookingForFrontDeskCheckin.Id,
				GuestAdult = AdultsCount,
				GuestChildren = ChildrenCount
			};
			string jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(request);
			if (Device.RuntimePlatform == Device.iOS)
				await Launcher.OpenAsync($"QloudidUrl://NoffaPlusApp/FrontDeskCheckedInHotelRequest/{jsonRequest}");
			else
				await Launcher.OpenAsync($"https://qloudid.com/ip/NoffaPlusApp/FrontDeskCheckedInHotelRequest/{jsonRequest}");
			await Navigation.PopToRootAsync();
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
				if (selectedHotelBookingForFrontDeskCheckin != null)
				{
					AdultsCount = selectedHotelBookingForFrontDeskCheckin.GuestAdult;
					ChildrenCount = selectedHotelBookingForFrontDeskCheckin.GuestChildren;
				}
			}
		}

		private bool isSelected = false;
		public bool IsSelected
		{
			get => isSelected;
			set
			{
				isSelected = value;
				OnPropertyChanged("IsSelected");
			}
		}

		private int adultsCount;
		public int AdultsCount
		{
			get => adultsCount;
			set
			{
				adultsCount = value;
				OnPropertyChanged("AdultsCount");
			}
		}

		private int childrenCount;
		public int ChildrenCount
		{
			get => childrenCount;
			set
			{
				childrenCount = value;
				OnPropertyChanged("ChildrenCount");
			}
		}
		#endregion
	}
}
