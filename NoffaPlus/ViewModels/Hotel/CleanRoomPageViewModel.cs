using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Extensions;
using System;

namespace NoffaPlus.ViewModels
{
	public class CleanRoomPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleanRoomPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Booking List For Clening Staff Command.
		private ICommand hotelBookingListForCleningStaffCommand;
		public ICommand HotelBookingListForCleningStaffCommand
		{
			get => hotelBookingListForCleningStaffCommand ?? (hotelBookingListForCleningStaffCommand = new Command(async () => await ExecuteHotelBookingListForCleningStaffCommand()));
		}
		private async Task ExecuteHotelBookingListForCleningStaffCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.HotelBookingListForCleningStaffAsync(new Models.HotelBookingListForCleningStaffRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			SearchText = string.Empty;
			HotelBookingListForCleningStaffInfo?.Clear();
			CopyHotelBookingListForCleningStaffInfo?.Clear();
			if (responses != null)
			{
				foreach (var item in responses)
				{
					if (item.RoomCleaningAllocated)
					{
						item.RoomNameTextColor = Color.FromHex("#FF9129");
						item.RoomNameBgColor = Color.FromHex("#342B20");
						item.RowBorderColor = Color.FromHex("#FF9129");
					}
					else
					{
						item.RoomNameTextColor = Color.FromHex("#4C7CE5");
						item.RoomNameBgColor = Color.FromHex("#242A37");
						item.RowBorderColor = Color.FromHex("#2A2A31");
					}
				}
				CopyHotelBookingListForCleningStaffInfo = responses;
				HotelBookingListForCleningStaffInfo = new ObservableCollection<Models.HotelBookingListForCleningStaffResponse>(responses);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(() => ExecuteSearchCommand()));
		}
		private void ExecuteSearchCommand()
		{
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string text = SearchText.ToLower();
				if (CopyHotelBookingListForCleningStaffInfo?.Count > 0)
				{
					var searchResult = CopyHotelBookingListForCleningStaffInfo.Where(x => x.Name.ToLower().Contains(text)).ToList();
					HotelBookingListForCleningStaffInfo = new ObservableCollection<Models.HotelBookingListForCleningStaffResponse>(searchResult);
				}
			}
			else
				HotelBookingListForCleningStaffInfo = new ObservableCollection<Models.HotelBookingListForCleningStaffResponse>(CopyHotelBookingListForCleningStaffInfo);
		}
		#endregion

		#region Go To Clean Room Popup Page Command.
		private ICommand goToCleanRoomPopupPageCommand;
		public ICommand GoToCleanRoomPopupPageCommand
		{
			get => goToCleanRoomPopupPageCommand ?? (goToCleanRoomPopupPageCommand = new Command(async () => await ExecuteGoToCleanRoomPopupPageCommand()));
		}
		private async Task ExecuteGoToCleanRoomPopupPageCommand()
		{
			SelectedCleningStaff.CallBack = CallBackCleningStaff;
			await Navigation.PushPopupAsync(new PopupPages.Hotel.CleanRoomPopupPage(SelectedCleningStaff));
		}

		private void CallBackCleningStaff()
		{
			HotelBookingListForCleningStaffCommand.Execute(null);
		}
		#endregion

		#region Properties.
		public Models.HotelBookingListForCleningStaffResponse SelectedCleningStaff { get; set; }
		public List<Models.HotelBookingListForCleningStaffResponse> CopyHotelBookingListForCleningStaffInfo { get; set; }

		private ObservableCollection<Models.HotelBookingListForCleningStaffResponse> hotelBookingListForCleningStaffInfo;
		public ObservableCollection<Models.HotelBookingListForCleningStaffResponse> HotelBookingListForCleningStaffInfo
		{
			get => hotelBookingListForCleningStaffInfo;
			set
			{
				hotelBookingListForCleningStaffInfo = value;
				OnPropertyChanged("HotelBookingListForCleningStaffInfo");
			}
		}

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}
		#endregion
	}
}
