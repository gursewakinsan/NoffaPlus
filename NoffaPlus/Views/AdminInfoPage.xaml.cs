using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminInfoPage : ContentPage
	{
		AdminInfoPageViewModel adminInfoPageViewModel;
		public AdminInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = adminInfoPageViewModel = new AdminInfoPageViewModel(this.Navigation);
		}

		private async void OnAdminInfoItemTapped(object sender, ItemTappedEventArgs e)
		{
			AdminInfo info = e.Item as AdminInfo;
			listAdminInfo.SelectedItem = null;
			if (info.InfoName.Equals("Appstore"))
				await adminInfoPageViewModel.Navigation.PushAsync(new AppStoreInfoPage());
			else if (info.InfoName.Equals("Resources"))
				await adminInfoPageViewModel.Navigation.PushAsync(new ContactListPage());
			else if (info.InfoName.Equals("Market place"))
				await adminInfoPageViewModel.Navigation.PushAsync(new MarketPlace.MarketPlaceListPage());
		}

		private async void OnImageButtonClicked(object sender, System.EventArgs e)
		{
			ImageButton button = sender as ImageButton;
			AdminInfo info = button.BindingContext as AdminInfo;
			if (info.InfoName.Equals("Appstore"))
				await adminInfoPageViewModel.Navigation.PushAsync(new AppStoreInfoPage());
			else if (info.InfoName.Equals("Resources"))
				await adminInfoPageViewModel.Navigation.PushAsync(new ContactListPage());
            else if (info.InfoName.Equals("Market place"))
                await adminInfoPageViewModel.Navigation.PushAsync(new MarketPlace.MarketPlaceListPage());
        }
	}
}