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
			Models.HotelBookingListForCleningStaffResponse cleningStaff = e.Item as Models.HotelBookingListForCleningStaffResponse;
			listHotelBookingForCleningStaffInfo.SelectedItem = null;
			viewModel.SelectedCleningStaff = cleningStaff;
			if (!cleningStaff.RoomCleaningAllocated)
				viewModel.GoToCleanRoomPopupPageCommand.Execute(null);
			else
				viewModel.GoToCleanedRoomPopupPageCommand.Execute(null);
		}
	}
}