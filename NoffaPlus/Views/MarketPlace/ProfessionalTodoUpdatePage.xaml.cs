using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfessionalTodoUpdatePage : ContentPage
    {
        ProfessionalTodoUpdatePageViewModel ViewModel;
        public ProfessionalTodoUpdatePage(Models.CompanyMarketplaceListResponse model)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new ProfessionalTodoUpdatePageViewModel(this.Navigation);
            Helper.Helper.DomainId = model.Id;
            ViewModel.SelectedCompanyMarketplace = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ProfessionalTodoUpdateCommand.Execute(null);
        }
    }
}