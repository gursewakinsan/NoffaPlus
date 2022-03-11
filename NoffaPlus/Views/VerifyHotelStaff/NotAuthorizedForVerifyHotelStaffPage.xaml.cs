using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoffaPlus.Views.VerifyHotelStaff
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotAuthorizedForVerifyHotelStaffPage : ContentPage
	{
		public NotAuthorizedForVerifyHotelStaffPage()
		{
			InitializeComponent();
		}

		private void OnNotAuthorizedTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new CompanyDetailsPage());
		}
	}
}