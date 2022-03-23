using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace NoffaPlus.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CleanRoomPopupPage : PopupPage
	{
		CleanRoomPopupPageViewModel viewModel;
		public CleanRoomPopupPage(Models.HotelBookingListForCleningStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new CleanRoomPopupPageViewModel(this.Navigation);
			viewModel.CleningStaffInfo = staff;
		}
	}
}