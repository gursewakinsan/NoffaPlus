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

		private void OnAppStoreItemTapped(object sender, ItemTappedEventArgs e)
		{
			listAppStore.SelectedItem = null;
		}
	}
}