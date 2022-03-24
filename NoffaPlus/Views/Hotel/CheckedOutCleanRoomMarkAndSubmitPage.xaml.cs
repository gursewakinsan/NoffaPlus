using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedOutCleanRoomMarkAndSubmitPage : ContentPage
	{
		CheckedOutCleanRoomMarkAndSubmitPageViewModel viewModel;
		public CheckedOutCleanRoomMarkAndSubmitPage(Models.HotelCheckedOutListForCleningStaffResponse staffResponse)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckedOutCleanRoomMarkAndSubmitPageViewModel(this.Navigation);
			viewModel.CheckedOutCleningStaffInfo = staffResponse;
		}
	}
}