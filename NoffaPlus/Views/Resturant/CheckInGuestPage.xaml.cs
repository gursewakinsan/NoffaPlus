using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Resturant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckInGuestPage : ContentPage
	{
		CheckInGuestPageViewModel viewModel;
		public CheckInGuestPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckInGuestPageViewModel(this.Navigation);
			viewModel.HotelBookingListForFrontDeskCheckinCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
		
		private void OnHotelRoomCode(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (picker.SelectedIndex == -1)
				return;
		}
	}
}