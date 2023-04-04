using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Landloard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApartmentConnectRequestPage : ContentPage
	{
        ApartmentConnectRequestPageViewModel viewModel;
        public ApartmentConnectRequestPage ()
		{
			InitializeComponent ();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ApartmentConnectRequestPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.SelectedTabCommand.Execute("Received");
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.ApartmentConnectRequestReceivedResponse);
        }

        private void OnStackLayoutTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnItemTapped(control.BindingContext as Models.ApartmentConnectRequestReceivedResponse);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.ApartmentConnectRequestReceivedResponse);
        }

        async void OnItemTapped(Models.ApartmentConnectRequestReceivedResponse apartment)
        {
            await Navigation.PushAsync(new ApartmentConnectRequestDetailsPage(apartment));
        }
    }
}