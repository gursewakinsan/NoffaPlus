using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuportedLanguagesListPage : ContentPage
    {
        SuportedLanguagesListPageViewModel ViewModel;
        public SuportedLanguagesListPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new SuportedLanguagesListPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.SuportedLanguagesListCommand.Execute(null);
        }
    }
}