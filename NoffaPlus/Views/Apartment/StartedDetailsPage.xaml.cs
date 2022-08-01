using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using System.Collections.Generic;

namespace NoffaPlus.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartedDetailsPage : ContentPage
    {
        StartedDetailsPageViewModel viewModel;
        public StartedDetailsPage(ApartmentCommunityTicketModel apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new StartedDetailsPageViewModel(this.Navigation);
            viewModel.SelectedApartmentCommunityTicket = apartment;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentCommunityTicketDetailCommand.Execute(null);
        }
    }
}