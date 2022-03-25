using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace NoffaPlus.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectRoomPopupPage : PopupPage
	{
		InspectRoomPopupPageViewModel viewModel;
		public InspectRoomPopupPage(Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new InspectRoomPopupPageViewModel(this.Navigation);
			viewModel.SelectedIncepectionStaffInfo = staff;
		}
	}
}