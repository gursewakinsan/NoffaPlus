using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

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
            Models.CompanyMarketplaceServiceDetailSubcategory model = control.BindingContext as Models.CompanyMarketplaceServiceDetailSubcategory;
            ViewModel.UpdateCategoryServiceTodoCommand.Execute(model.Id);
        }

        private void OnStackLayoutTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnItemTapped(control.BindingContext as Models.CompanyMarketplaceServiceDetailSubcategory);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.CompanyMarketplaceServiceDetailSubcategory);
        }

        async void OnItemTapped(Models.CompanyMarketplaceServiceDetailSubcategory subcategory)
        {
            if (subcategory.IsSelected && !subcategory.PriceAdded)
            {
                //Navigate to add page
            }
            else if (subcategory.IsSelected && subcategory.PriceAdded)
            {
                Helper.Helper.ProfessionalSubcategoryId = subcategory.Id;
                await Navigation.PushAsync(new CompanyMarketplacePricingDetailPage());
            }
        }
    }
}