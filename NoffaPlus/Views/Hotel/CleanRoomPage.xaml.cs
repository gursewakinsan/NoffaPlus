using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CleanRoomPage : ContentPage
	{
		CleanRoomPageViewModel viewModel;
		public CleanRoomPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CleanRoomPageViewModel(this.Navigation);
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.HotelBookingListForCleningStaffCommand.Execute(null);
		}

		private async void OnHotelBookingForCleningStaffInfoItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelBookingListForCleningStaffResponse cleningStaff = e.Item as Models.HotelBookingListForCleningStaffResponse;
			listHotelBookingForCleningStaffInfo.SelectedItem = null;
			if (!cleningStaff.RoomCleaningAllocated)
			{
				viewModel.SelectedCleningStaffId = cleningStaff.Id;
				await Navigation.PushPopupAsync(new PopupPages.Hotel.CleanRoomPopupPage(cleningStaff));
			}
		}
	}
}