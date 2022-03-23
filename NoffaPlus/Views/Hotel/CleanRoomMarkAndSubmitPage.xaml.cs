using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CleanRoomMarkAndSubmitPage : ContentPage
	{
		CleanRoomMarkAndSubmitPageViewModel viewModel;
		public CleanRoomMarkAndSubmitPage (Models.HotelBookingListForCleningStaffResponse staffResponse)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CleanRoomMarkAndSubmitPageViewModel(this.Navigation);
			viewModel.CleningStaffInfo = staffResponse;
		}
	}
}