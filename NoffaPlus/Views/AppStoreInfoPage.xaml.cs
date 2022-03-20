using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppStoreInfoPage : ContentPage
	{
		AppStoreInfoPageViewModel appStoreInfoPageViewModel;
		public AppStoreInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = appStoreInfoPageViewModel = new AppStoreInfoPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			appStoreInfoPageViewModel.GetCompanyDownloadedAppsCommand.Execute(null);
			base.OnAppearing();
		}

		private async void OnAppStoreItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.CompanyDownloadedAppsResponse selectedCompany = e.Item as Models.CompanyDownloadedAppsResponse;
			listAppStore.SelectedItem = null;
			if (selectedCompany.AppName.Equals("Stay"))
				appStoreInfoPageViewModel.IsHotelCommand.Execute(null);
			else if (selectedCompany.AppName.Equals("Food & Drinks"))
				await Navigation.PushAsync(new Resturant.AvailableResturantListPage());
			else if (selectedCompany.AppName.Equals("Drop in"))
				await Navigation.PushAsync(new Queue.OperatorQueueListPage());
		}
	}
	
}
