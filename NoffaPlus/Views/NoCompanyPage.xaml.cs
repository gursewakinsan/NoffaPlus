using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoCompanyPage : ContentPage
	{
		public NoCompanyPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
		}

		private void OnCloseButtonClicked(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new LoginPage());
		}
	}
}