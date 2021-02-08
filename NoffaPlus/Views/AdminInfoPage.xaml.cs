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
			listAdminInfo.SelectedItem = null;
			await adminInfoPageViewModel.Navigation.PushAsync(new AppStoreInfoPage());
		}
	}
}