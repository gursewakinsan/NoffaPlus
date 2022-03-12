using System;
using System.Timers;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class GenerateKeyForInstaBoxPageViewModel : BaseViewModel
	{
		#region Constructor.
		public GenerateKeyForInstaBoxPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Hotel Booking List For Key Generation Command.
		private ICommand hotelBookingListForKeyGenerationCommand;
		public ICommand HotelBookingListForKeyGenerationCommand
		{
			get => hotelBookingListForKeyGenerationCommand ?? (hotelBookingListForKeyGenerationCommand = new Command(async () => await ExecuteHotelBookingListForKeyGenerationCommand()));
		}
		private async Task ExecuteHotelBookingListForKeyGenerationCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IVerifyHotelStaffService service = new VerifyHotelStaffService();
			HotelBookingListForKeyGenerationInfo = await service.HotelBookingListForKeyGenerationAsync(new Models.HotelBookingListForKeyGenerationRequest()
			{
				HotelId = Helper.Helper.HotelId
			});

			HotelBookingInstaBoxListForKeyGenerationInfo = await service.HotelBookingInstaBoxListForKeyGenerationAsync(new Models.HotelBookingInstaBoxListForKeyGenerationRequest()
			{
				HotelId = Helper.Helper.HotelId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Submit Generate Key For Insta Box Command.
		private ICommand submitGenerateKeyForInstaBoxCommand;
		public ICommand SubmitGenerateKeyForInstaBoxCommand
		{
			get => submitGenerateKeyForInstaBoxCommand ?? (submitGenerateKeyForInstaBoxCommand = new Command(async () => await ExecuteSubmitGenerateKeyForInstaBoxCommand()));
		}
		private async Task ExecuteSubmitGenerateKeyForInstaBoxCommand()
		{
			if (SelectedBookingConfirmationCode == null)
				await Helper.Alert.DisplayAlert("Please select booking confirmation code.");
			else if (SelectedAvailableBox == null)
				await Helper.Alert.DisplayAlert("Please select available box.");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				IVerifyHotelStaffService service = new VerifyHotelStaffService();
				var response = await service.GenerateKeyForInstaBoxAsync(new Models.GenerateKeyForInstaBoxRequest()
				{
					BookingId = SelectedBookingConfirmationCode.Id,
					InstaBoxId = SelectedAvailableBox.Id,
					HotelId = Helper.Helper.HotelId
				});
				Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Properties.
		private List<Models.HotelBookingListForKeyGenerationResponse> hotelBookingListForKeyGenerationInfo;
		public List<Models.HotelBookingListForKeyGenerationResponse> HotelBookingListForKeyGenerationInfo
		{
			get => hotelBookingListForKeyGenerationInfo;
			set
			{
				hotelBookingListForKeyGenerationInfo = value;
				OnPropertyChanged("HotelBookingListForKeyGenerationInfo");
			}
		}

		private Models.HotelBookingListForKeyGenerationResponse selectedBookingConfirmationCode;
		public Models.HotelBookingListForKeyGenerationResponse SelectedBookingConfirmationCode
		{
			get => selectedBookingConfirmationCode;
			set
			{
				selectedBookingConfirmationCode = value;
				OnPropertyChanged("SelectedBookingConfirmationCode");
			}
		}

		private List<Models.HotelBookingInstaBoxListForKeyGenerationResponse> hotelBookingInstaBoxListForKeyGenerationInfo;
		public List<Models.HotelBookingInstaBoxListForKeyGenerationResponse> HotelBookingInstaBoxListForKeyGenerationInfo
		{
			get => hotelBookingInstaBoxListForKeyGenerationInfo;
			set
			{
				hotelBookingInstaBoxListForKeyGenerationInfo = value;
				OnPropertyChanged("HotelBookingInstaBoxListForKeyGenerationInfo");
			}
		}

		private Models.HotelBookingInstaBoxListForKeyGenerationResponse selectedAvailableBox;
		public Models.HotelBookingInstaBoxListForKeyGenerationResponse SelectedAvailableBox
		{
			get => selectedAvailableBox;
			set
			{
				selectedAvailableBox = value;
				OnPropertyChanged("SelectedAvailableBox");
			}
		}
		#endregion
	}
}
