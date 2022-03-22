using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class CheckOutGuestPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckOutGuestPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Booking List For Front Desk Checkout Command.
		private ICommand hotelBookingListForFrontDeskCheckoutCommand;
		public ICommand HotelBookingListForFrontDeskCheckoutCommand
		{
			get => hotelBookingListForFrontDeskCheckoutCommand ?? (hotelBookingListForFrontDeskCheckoutCommand = new Command(async () => await ExecuteHotelBookingListForFrontDeskCheckoutCommand()));
		}
		private async Task ExecuteHotelBookingListForFrontDeskCheckoutCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			var responses = await service.HotelBookingListForFrontDeskCheckoutAsync(new Models.HotelBookingListForFrontDeskKeyHandlingRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			SearchText = string.Empty;
			IsSubmitVisible = false;
			HotelBookingListForFrontDeskCheckoutInfo?.Clear();
			CopyHotelBookingListForFrontDeskCheckoutInfo?.Clear();
			if (responses != null)
			{
				CopyHotelBookingListForFrontDeskCheckoutInfo = responses;
				HotelBookingListForFrontDeskCheckoutInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskCheckoutResponse>(responses);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Check Out Guest Command.
		private ICommand submitCheckOutGuestCommand;
		public ICommand SubmitCheckOutGuestCommand
		{
			get => submitCheckOutGuestCommand ?? (submitCheckOutGuestCommand = new Command(async () => await ExecuteSubmitCheckOutGuestCommand()));
		}
		private async Task ExecuteSubmitCheckOutGuestCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			await service.CheckOutGuestAsync(new Models.HandoverKeyRequest()
			{
				Id = SelectedCheckoutId
			});
			await Navigation.PopAsync();
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
				if (CopyHotelBookingListForFrontDeskCheckoutInfo?.Count > 0)
				{
					var searchResult = CopyHotelBookingListForFrontDeskCheckoutInfo.Where(x => x.Name.ToLower().Contains(text)).ToList();
					HotelBookingListForFrontDeskCheckoutInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskCheckoutResponse>(searchResult);
				}
			}
			else
				HotelBookingListForFrontDeskCheckoutInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskCheckoutResponse>(CopyHotelBookingListForFrontDeskCheckoutInfo);
		}
		#endregion

		#region Properties.
		public int SelectedCheckoutId { get; set; }
		public List<Models.HotelBookingListForFrontDeskCheckoutResponse> CopyHotelBookingListForFrontDeskCheckoutInfo { get; set; }

		private ObservableCollection<Models.HotelBookingListForFrontDeskCheckoutResponse> hotelBookingListForFrontDeskCheckoutInfo;
		public ObservableCollection<Models.HotelBookingListForFrontDeskCheckoutResponse> HotelBookingListForFrontDeskCheckoutInfo
		{
			get => hotelBookingListForFrontDeskCheckoutInfo;
			set
			{
				hotelBookingListForFrontDeskCheckoutInfo = value;
				OnPropertyChanged("HotelBookingListForFrontDeskCheckoutInfo");
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
