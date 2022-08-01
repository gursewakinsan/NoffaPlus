using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Apartment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CancelledDetailsPage : ContentPage
	{
		NotStartedDetailsPageViewModel viewModel;
		public CancelledDetailsPage (ApartmentCommunityTicketModel apartment)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new NotStartedDetailsPageViewModel(this.Navigation);
			viewModel.SelectedApartmentCommunityTicket = apartment;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ApartmentCommunityTicketDetailCommand.Execute(null);
		}
	}
}