using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using System.Collections.ObjectModel;

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

		#region Checked In Command.
		private ICommand checkedInCommand;
		public ICommand CheckedInCommand
		{
			get => checkedInCommand ?? (checkedInCommand = new Command( () => ExecuteCheckedInCommand()));
		}
		private void ExecuteCheckedInCommand()
		{
			IsCheckedInList = true;
			IsCheckedOutList = false;
			CheckedInButtonBg = Color.FromHex("#4C7CE5");
			CheckedOutButtonBg = Color.FromHex("#1F1F23");
			HotelBookingListForCleningStaffCommand.Execute(null);
		}
		#endregion

		#region Checked Out Command.
		private ICommand checkedOutCommand;
		public ICommand CheckedOutCommand
		{
			get => checkedOutCommand ?? (checkedOutCommand = new Command(() => ExecuteCheckedOutCommand()));
		}
		private void ExecuteCheckedOutCommand()
		{
			IsCheckedInList = false;
			IsCheckedOutList = true;
			CheckedInButtonBg = Color.FromHex("#1F1F23");
			CheckedOutButtonBg = Color.FromHex("#4C7CE5");
			HotelCheckedOutListForCleningStaffCommand.Execute(null);
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

		#region Hotel Checked Out List For Clening Staff Command.
		private ICommand hotelCheckedOutListForCleningStaffCommand;
		public ICommand HotelCheckedOutListForCleningStaffCommand
		{
			get => hotelCheckedOutListForCleningStaffCommand ?? (hotelCheckedOutListForCleningStaffCommand = new Command(async () => await ExecuteHotelCheckedOutListForCleningStaffCommand()));
		}
		private async Task ExecuteHotelCheckedOutListForCleningStaffCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.HotelCheckedOutListForCleningStaffAsync(new Models.HotelCheckedOutListForCleningStaffRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			SearchText = string.Empty;
			HotelCheckedOutListForCleningStaffInfo?.Clear();
			CopyHotelCheckedOutListForCleningStaffInfo?.Clear();
			if (responses != null)
			{
				foreach (var item in responses)
				{
					if (item.CleaningWorkAssigned)
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
				CopyHotelCheckedOutListForCleningStaffInfo = responses;
				HotelCheckedOutListForCleningStaffInfo = new ObservableCollection<Models.HotelCheckedOutListForCleningStaffResponse>(responses);
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
			if (IsCheckedInList)
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
			else
			{
				if (!string.IsNullOrWhiteSpace(SearchText))
				{
					string text = SearchText.ToLower();
					if (CopyHotelCheckedOutListForCleningStaffInfo?.Count > 0)
					{
						var searchResult = CopyHotelCheckedOutListForCleningStaffInfo.Where(x => x.CheckoutTimeDiff.ToLower().Contains(text)).ToList();
						HotelCheckedOutListForCleningStaffInfo = new ObservableCollection<Models.HotelCheckedOutListForCleningStaffResponse>(searchResult);
					}
				}
				else
					HotelCheckedOutListForCleningStaffInfo = new ObservableCollection<Models.HotelCheckedOutListForCleningStaffResponse>(CopyHotelCheckedOutListForCleningStaffInfo);
			}
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
			CheckedInCommand.Execute(null);
		}
		#endregion

		#region Go To Cleaned Room Popup Page Command.
		private ICommand goToCleanedRoomPopupPageCommand;
		public ICommand GoToCleanedRoomPopupPageCommand
		{
			get => goToCleanedRoomPopupPageCommand ?? (goToCleanedRoomPopupPageCommand = new Command(async () => await ExecuteGoToCleanedRoomPopupPageCommand()));
		}
		private async Task ExecuteGoToCleanedRoomPopupPageCommand()
		{
			SelectedCleningStaff.CallBack = CallBackCleanedStaff;
			await Navigation.PushPopupAsync(new PopupPages.Hotel.CleanedRoomByNamePopupPage(SelectedCleningStaff));
		}

		private async void CallBackCleanedStaff()
		{
			await Navigation.PushAsync(new Views.Hotel.CleanRoomMarkAndSubmitPage(SelectedCleningStaff));
		}
		#endregion

		#region Go To Checked Out Clean Room Popup Page Command.
		private ICommand goToCheckedOutCleanRoomPopupPageCommand;
		public ICommand GoToCheckedOutCleanRoomPopupPageCommand
		{
			get => goToCheckedOutCleanRoomPopupPageCommand ?? (goToCheckedOutCleanRoomPopupPageCommand = new Command(async () => await ExecuteGoToCheckedOutCleanRoomPopupPageCommand()));
		}
		private async Task ExecuteGoToCheckedOutCleanRoomPopupPageCommand()
		{
			SelectedCheckedOutItem.CallBack = CallBackCheckedOut;
			await Navigation.PushPopupAsync(new PopupPages.Hotel.CheckedOutCleanRoomPopupPage(SelectedCheckedOutItem));
		}

		private void CallBackCheckedOut()
		{
			CheckedOutCommand.Execute(null);
		}
		#endregion

		#region Go To Checked Out Cleaned Room Popup Page Command.
		private ICommand goToCheckedOutCleanedRoomPopupPageCommand;
		public ICommand GoToCheckedOutCleanedRoomPopupPageCommand
		{
			get => goToCheckedOutCleanedRoomPopupPageCommand ?? (goToCheckedOutCleanedRoomPopupPageCommand = new Command(async () => await ExecuteGoToCheckedOutCleanedRoomPopupPageCommand()));
		}
		private async Task ExecuteGoToCheckedOutCleanedRoomPopupPageCommand()
		{
			SelectedCheckedOutItem.CallBack = CallBackCheckedOutCleanedStaff;
			await Navigation.PushPopupAsync(new PopupPages.Hotel.CheckedOutCleanedRoomPopupPage(SelectedCheckedOutItem));
		}

		private async void CallBackCheckedOutCleanedStaff()
		{
			await Navigation.PushAsync(new Views.Hotel.CheckedOutCleanRoomMarkAndSubmitPage(SelectedCheckedOutItem));
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

		public Models.HotelCheckedOutListForCleningStaffResponse SelectedCheckedOutItem { get; set; }
		public List<Models.HotelCheckedOutListForCleningStaffResponse> CopyHotelCheckedOutListForCleningStaffInfo { get; set; }

		private ObservableCollection<Models.HotelCheckedOutListForCleningStaffResponse> hotelCheckedOutListForCleningStaffInfo;
		public ObservableCollection<Models.HotelCheckedOutListForCleningStaffResponse> HotelCheckedOutListForCleningStaffInfo
		{
			get => hotelCheckedOutListForCleningStaffInfo;
			set
			{
				hotelCheckedOutListForCleningStaffInfo = value;
				OnPropertyChanged("HotelCheckedOutListForCleningStaffInfo");
			}
		}

		private string searchText;
		public string SearchText
		{
			get => searchText;
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}

		private Color checkedInButtonBg;
		public Color CheckedInButtonBg
		{
			get => checkedInButtonBg;
			set
			{
				checkedInButtonBg = value;
				OnPropertyChanged("CheckedInButtonBg");
			}
		}

		private Color checkedOutButtonBg;
		public Color CheckedOutButtonBg
		{
			get => checkedOutButtonBg;
			set
			{
				checkedOutButtonBg = value;
				OnPropertyChanged("CheckedOutButtonBg");
			}
		}

		private bool isCheckedInList;
		public bool IsCheckedInList
		{
			get => isCheckedInList;
			set
			{
				isCheckedInList = value;
				OnPropertyChanged("IsCheckedInList");
			}
		}

		private bool isCheckedOutList;
		public bool IsCheckedOutList
		{
			get => isCheckedOutList;
			set
			{
				isCheckedOutList = value;
				OnPropertyChanged("IsCheckedOutList");
			}
		}
		#endregion
	}
}
