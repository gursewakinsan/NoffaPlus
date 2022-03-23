using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

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

		private void OnHotelBookingForCleningStaffInfoItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelBookingListForCleningStaffResponse response = e.Item as Models.HotelBookingListForCleningStaffResponse;
			listHotelBookingForCleningStaffInfo.SelectedItem = null;
			if (!response.RoomCleaningAllocated)
			{
				viewModel.SelectedCleningStaffId = response.Id;
			}
		}
	}
}