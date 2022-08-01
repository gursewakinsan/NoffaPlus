using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinishPage : ContentPage
    {
        FinishPageViewModel viewModel;
        public FinishPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new FinishPageViewModel(this.Navigation);
        }

        #region On List Tapped Functionality.
        private async void OnListClicked(ApartmentCommunityTicketModel apartmentCommunityTicketModel)
        {
            await Navigation.PushAsync(new FinishedDetailsPage(apartmentCommunityTicketModel));
        }
        private void OnFrameNotStartedListTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            OnListClicked(control.BindingContext as ApartmentCommunityTicketModel);
        }

        private void OnGridNotStartedListTapped(object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnListClicked(control.BindingContext as ApartmentCommunityTicketModel);
        }

        private void OnBoxViewNotStartedListTapped(object sender, System.EventArgs e)
        {
            BoxView control = sender as BoxView;
            OnListClicked(control.BindingContext as ApartmentCommunityTicketModel);
        }

        private void OnLabelNotStartedListTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnListClicked(control.BindingContext as ApartmentCommunityTicketModel);
        }

        private void OnStackLayoutNotStartedListTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnListClicked(control.BindingContext as ApartmentCommunityTicketModel);
        }
        #endregion
    }
}