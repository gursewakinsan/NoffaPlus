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

		#region On Appearing
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.CheckedInCommand.Execute(null);
		}
		#endregion

		#region On Checked In Item Tapped
		private void OnCheckedInItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelBookingListForCleningStaffResponse cleningStaff = e.Item as Models.HotelBookingListForCleningStaffResponse;
			listCheckedIn.SelectedItem = null;
			viewModel.SelectedCleningStaff = cleningStaff;
			if (!cleningStaff.RoomCleaningAllocated)
				viewModel.GoToCleanRoomPopupPageCommand.Execute(null);
			else
				viewModel.GoToCleanedRoomPopupPageCommand.Execute(null);
		}
		#endregion

		#region On Checked Out Item Tapped
		private void OnCheckedOutItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelCheckedOutListForCleningStaffResponse checkedOut = e.Item as Models.HotelCheckedOutListForCleningStaffResponse;
			listCheckedOut.SelectedItem = null;
			viewModel.SelectedCheckedOutItem = checkedOut;
			if (!checkedOut.CleaningWorkAssigned)
				viewModel.GoToCheckedOutCleanRoomPopupPageCommand.Execute(null);
			else
				viewModel.GoToCheckedOutCleanedRoomPopupPageCommand.Execute(null);
		}
		#endregion
	}
}