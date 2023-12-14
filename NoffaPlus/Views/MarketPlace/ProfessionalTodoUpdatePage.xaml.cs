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

        void OnGridTapped(System.Object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnItemTapped(control.BindingContext as Models.ProfessionalTodoUpdateModel);
        }

        void OnLabelTapped(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.ProfessionalTodoUpdateModel);
        }

        async void OnItemTapped(Models.ProfessionalTodoUpdateModel model)
        {
            if (model.Name.Equals("Services"))
                await Navigation.PushAsync(new CompanyMarketplaceServiceDetailPage());
        }
    }
}