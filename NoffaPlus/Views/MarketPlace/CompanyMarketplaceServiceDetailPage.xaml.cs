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

        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            CompanyMarketplaceServiceDetailSubcategory model = control.BindingContext as CompanyMarketplaceServiceDetailSubcategory;
            ViewModel.UpdateCategoryServiceTodoCommand.Execute(model.Id);
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
            if (subcategory.IsSelected && !subcategory.PriceAdded)
            {
                //Navigate to add page
            }
            else if (subcategory.IsSelected && subcategory.PriceAdded)
            {
                //Navigate to home all prices page
            }
        }
    }
}