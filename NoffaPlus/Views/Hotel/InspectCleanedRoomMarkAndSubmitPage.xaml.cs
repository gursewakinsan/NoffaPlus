using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectCleanedRoomMarkAndSubmitPage : ContentPage
	{
		InspectCleanedRoomMarkAndSubmitPageViewModel viewModel;
		public InspectCleanedRoomMarkAndSubmitPage(Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse staff)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InspectCleanedRoomMarkAndSubmitPageViewModel(this.Navigation);
			viewModel.SelectedInspectedStaffInfo = staff;
		}
	}
}