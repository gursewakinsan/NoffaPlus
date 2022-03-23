using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HandOverkeyPage : ContentPage
	{
		HandOverkeyPageViewModel viewModel;
		public HandOverkeyPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HandOverkeyPageViewModel(this.Navigation);
			viewModel.NewKeysCommand.Execute(null);
		}

		private void OnHotelBookingListForFrontDeskKeyHandlingItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelBookingListForFrontDeskKeyHandlingResponse info = e.Item as Models.HotelBookingListForFrontDeskKeyHandlingResponse;
			listHotelBookingForFrontDeskKeyHandling.SelectedItem = null;
			foreach (var item in viewModel.HotelBookingListForFrontDeskKeyHandlingInfo)
			{
				if (item.Id.Equals(info.Id))
				{
					viewModel.SelectedHandOverKey = info.Id;
					item.IsChecked = !item.IsChecked;
					viewModel.IsSubmitVisible = item.IsChecked;
				}
				else
					item.IsChecked = false;
			}
		}
	}
}