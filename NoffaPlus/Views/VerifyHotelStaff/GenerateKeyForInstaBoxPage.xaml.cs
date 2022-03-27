using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.VerifyHotelStaff
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerateKeyForInstaBoxPage : ContentPage
	{
		GenerateKeyForInstaBoxPageViewModel viewModel;
		public GenerateKeyForInstaBoxPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new GenerateKeyForInstaBoxPageViewModel(this.Navigation);
			viewModel.HotelBookingListForKeyGenerationCommand.Execute(null);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void OnBookingConfirmationCode(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (picker.SelectedIndex == -1)
				return;
			else
				viewModel.GetAvailableRoomsCommand.Execute(picker.SelectedIndex);
		}

		private void OnInstaBoxInfo(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (picker.SelectedIndex == -1)
				return;
		}

		private void OnSelectRoomChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (picker.SelectedIndex == -1)
				return;
		}
	}
}