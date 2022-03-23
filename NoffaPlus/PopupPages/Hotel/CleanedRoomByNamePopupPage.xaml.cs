using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace NoffaPlus.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CleanedRoomByNamePopupPage : PopupPage
	{
		CleanedRoomByNamePopupPageViewModel viewModel;
		public CleanedRoomByNamePopupPage(Models.HotelBookingListForCleningStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new CleanedRoomByNamePopupPageViewModel(this.Navigation);
			if (staff.RoomCleaningStaffId.Equals(Helper.Helper.LoggedInUserId))
				btnCleanedRoom.Text = "Yes, I do";
			else
				btnCleanedRoom.Text = "Got it";
			viewModel.CleningStaffInfo = staff;
		}
	}
}