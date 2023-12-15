using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using NoffaPlus.Models;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyMarketplaceServiceDetailPage : ContentPage
    {
        CompanyMarketplaceServiceDetailPageViewModel ViewModel;
        public CompanyMarketplaceServiceDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new CompanyMarketplaceServiceDetailPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.CompanyMarketplaceServiceDetailCommand.Execute(null);
        }

        private void OnGridTapped(object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnItemTapped(control.BindingContext as CompanyMarketplaceServiceDetailSubcategory);
        }

        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as CompanyMarketplaceServiceDetailSubcategory);
        }

        private void OnStackLayoutTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnItemTapped(control.BindingContext as CompanyMarketplaceServiceDetailSubcategory);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as CompanyMarketplaceServiceDetailSubcategory);
        }

        void OnItemTapped(CompanyMarketplaceServiceDetailSubcategory subcategory)
        {
            
        }
    }
}