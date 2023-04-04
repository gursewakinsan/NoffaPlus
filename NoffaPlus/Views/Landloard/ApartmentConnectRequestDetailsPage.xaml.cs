using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Landloard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApartmentConnectRequestDetailsPage : ContentPage
	{
        ApartmentConnectRequestDetailsPageViewModel viewModel;
        public ApartmentConnectRequestDetailsPage (Models.ApartmentConnectRequestReceivedResponse apartment)
		{
			InitializeComponent ();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ApartmentConnectRequestDetailsPageViewModel(this.Navigation);
			viewModel.SelectedApartmentConnectRequest = apartment;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetAvailableApartmentCommand.Execute(null);
        }
    }
}