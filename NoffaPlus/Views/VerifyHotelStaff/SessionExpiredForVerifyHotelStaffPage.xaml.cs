using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoffaPlus.Views.VerifyHotelStaff
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SessionExpiredForVerifyHotelStaffPage : ContentPage
	{
		public SessionExpiredForVerifyHotelStaffPage ()
		{
			InitializeComponent ();
		}
		private void OnNotAuthorizedTapped(object sender, System.EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new CompanyDetailsPage());
		}
	}
}