using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Resturant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckOutGuestPage : ContentPage
	{
		CheckOutGuestPageViewModel viewModel;
		public CheckOutGuestPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckOutGuestPageViewModel(this.Navigation);
			viewModel.HotelBookingListForFrontDeskCheckoutCommand.Execute(null);
		}

		private void OnHotelBookingListForFrontDeskCheckoutInfoItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelBookingListForFrontDeskCheckoutResponse info = e.Item as Models.HotelBookingListForFrontDeskCheckoutResponse;
			listHotelBookingListForFrontDeskCheckoutInfo.SelectedItem = null;
			foreach (var item in viewModel.HotelBookingListForFrontDeskCheckoutInfo)
			{
				if (item.Id.Equals(info.Id))
				{
					viewModel.SelectedCheckoutId = info.Id;
					item.IsChecked = !item.IsChecked;
					viewModel.IsSubmitVisible = item.IsChecked;
				}
				else
					item.IsChecked = false;
			}
		}
	}
}