using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Queue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitingGuestServicesDetailPage : ContentPage
	{
		WaitingGuestServicesDetailViewModel viewModel;
		public WaitingGuestServicesDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WaitingGuestServicesDetailViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.QueueGuestDetailCommand.Execute(null);
		}
	}
}