using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarketPlaceListPage : ContentPage
    {
        MarketPlaceListPageViewModel ViewModel;
        public MarketPlaceListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new MarketPlaceListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.CompanyMarketplaceListCommand.Execute(null);
        }

        void OnFrameTapped(System.Object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            OnItemTapped(control.BindingContext as Models.CompanyMarketplaceListResponse);
        }

        void OnGridTapped(System.Object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnItemTapped(control.BindingContext as Models.CompanyMarketplaceListResponse);
        }

        void OnLabelTapped(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.CompanyMarketplaceListResponse);
        }

        async void OnItemTapped(Models.CompanyMarketplaceListResponse model)
        {
            await Navigation.PushAsync(new ProfessionalTodoUpdatePage(model));
        }
    }
}