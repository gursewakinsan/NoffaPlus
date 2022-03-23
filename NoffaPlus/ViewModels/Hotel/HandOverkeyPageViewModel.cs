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
	public class HandOverkeyPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HandOverkeyPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region New Keys Command.
		private ICommand newKeysCommand;
		public ICommand NewKeysCommand
		{
			get => newKeysCommand ?? (newKeysCommand = new Command(() => ExecuteNewKeysCommand()));
		}
		private void ExecuteNewKeysCommand()
		{
			IsNewKey = true;
			NewKeysButtonBg = Color.FromHex("#D23CE6");
			ChangeKeysButtonBg = Color.FromHex("#2A2A31");
			HotelBookingListForFrontDeskKeyHandlingCommand.Execute(null);
		}
		#endregion

		#region Change Keys Command.
		private ICommand changeKeysCommand;
		public ICommand ChangeKeysCommand
		{
			get => changeKeysCommand ?? (changeKeysCommand = new Command(() => ExecuteChangeKeysCommand()));
		}
		private void ExecuteChangeKeysCommand()
		{
			IsNewKey = false;
			NewKeysButtonBg = Color.FromHex("#2A2A31");
			ChangeKeysButtonBg = Color.FromHex("#D23CE6");
			HotelBookingListForFrontDeskReceivedKeyCommand.Execute(null);
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
			IHotelService service = new HotelService();
			var responses = await service.HotelBookingListForFrontDeskKeyHandlingAsync(new Models.HotelBookingListForFrontDeskKeyHandlingRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			SearchText = string.Empty;
			IsSubmitVisible = false;
			HotelBookingListForFrontDeskKeyHandlingInfo?.Clear();
			CopyHotelBookingListForFrontDeskKeyHandlingInfo?.Clear();
			if (responses != null)
			{
				CopyHotelBookingListForFrontDeskKeyHandlingInfo = responses;
				HotelBookingListForFrontDeskKeyHandlingInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskKeyHandlingResponse>(responses);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Hotel Booking List For Front Desk Received Key Command.
		private ICommand hotelBookingListForFrontDeskReceivedKeyCommand;
		public ICommand HotelBookingListForFrontDeskReceivedKeyCommand
		{
			get => hotelBookingListForFrontDeskReceivedKeyCommand ?? (hotelBookingListForFrontDeskReceivedKeyCommand = new Command(async () => await ExecuteHotelBookingListForFrontDeskReceivedKeyCommand()));
		}
		private async Task ExecuteHotelBookingListForFrontDeskReceivedKeyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.HotelBookingListForFrontDeskReceivedKeyAsync(new Models.HotelBookingListForFrontDeskKeyHandlingRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			SearchText = string.Empty;
			IsSubmitVisible = false;
			HotelBookingListForFrontDeskKeyHandlingInfo?.Clear();
			CopyHotelBookingListForFrontDeskKeyHandlingInfo?.Clear();
			if (responses != null)
			{
				CopyHotelBookingListForFrontDeskKeyHandlingInfo = responses;
				HotelBookingListForFrontDeskKeyHandlingInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskKeyHandlingResponse>(responses);
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Hand Over Key Command.
		private ICommand submitHandOverKeyCommand;
		public ICommand SubmitHandOverKeyCommand
		{
			get => submitHandOverKeyCommand ?? (submitHandOverKeyCommand = new Command(async () => await ExecuteSubmitHandOverKeyCommand()));
		}
		private async Task ExecuteSubmitHandOverKeyCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.HandOverKeyAsync(new Models.HandoverKeyRequest()
			{
				Id = SelectedHandOverKey
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
				if (CopyHotelBookingListForFrontDeskKeyHandlingInfo?.Count > 0)
				{
					var searchResult = CopyHotelBookingListForFrontDeskKeyHandlingInfo.Where(x => x.Name.ToLower().Contains(text)).ToList();
					HotelBookingListForFrontDeskKeyHandlingInfo = new ObservableCollection<Models.HotelBookingListForFrontDeskKeyHandlingResponse>(searchResult);
				}
			}
			else
			{
				if (IsNewKey)
					NewKeysCommand.Execute(null);
				else
					ChangeKeysCommand.Execute(null);
			}
		}
		#endregion

		#region Properties.
		public int SelectedHandOverKey { get; set; }
		public List<Models.HotelBookingListForFrontDeskKeyHandlingResponse> CopyHotelBookingListForFrontDeskKeyHandlingInfo { get; set; }

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

		private Color newKeysButtonBg;
		public Color NewKeysButtonBg
		{
			get => newKeysButtonBg;
			set
			{
				newKeysButtonBg = value;
				OnPropertyChanged("NewKeysButtonBg");
			}
		}

		private Color changeKeysButtonBg;
		public Color ChangeKeysButtonBg
		{
			get => changeKeysButtonBg;
			set
			{
				changeKeysButtonBg = value;
				OnPropertyChanged("ChangeKeysButtonBg");
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

		public bool IsNewKey { get; set; }
		#endregion
	}
}
