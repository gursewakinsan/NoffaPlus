using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyMarketplacePricingDetailPage : ContentPage
    {
        CompanyMarketplacePricingDetailPageViewModel ViewModel;
        public CompanyMarketplacePricingDetailPage(string subCategoryName)
        {
            InitializeComponent(); 
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new CompanyMarketplacePricingDetailPageViewModel(this.Navigation);
            lblHeading.Text = subCategoryName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.CompanyMarketplacePricingDetailCommand.Execute(null);
        }
    }
}