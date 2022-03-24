using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace NoffaPlus.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedOutCleanRoomPopupPage : PopupPage
	{
		CheckedOutCleanRoomPopupPageViewModel viewModel;
		public CheckedOutCleanRoomPopupPage(Models.HotelCheckedOutListForCleningStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new CheckedOutCleanRoomPopupPageViewModel(this.Navigation);
			viewModel.CheckedOutCleningStaffInfo = staff;
		}
	}
}