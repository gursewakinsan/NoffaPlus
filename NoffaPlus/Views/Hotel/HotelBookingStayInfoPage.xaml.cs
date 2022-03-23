using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;


namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HotelBookingStayInfoPage : ContentPage
	{
		HotelBookingStayInfoPageViewModel viewModel;
		public HotelBookingStayInfoPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new HotelBookingStayInfoPageViewModel(this.Navigation);
		}
	}
}