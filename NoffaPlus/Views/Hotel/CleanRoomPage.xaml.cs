using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CleanRoomPage : ContentPage
	{
		CleanRoomPageViewModel viewModel;
		public CleanRoomPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CleanRoomPageViewModel(this.Navigation);
		}
	}
}