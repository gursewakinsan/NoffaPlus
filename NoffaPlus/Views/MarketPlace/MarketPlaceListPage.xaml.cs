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
    }
}