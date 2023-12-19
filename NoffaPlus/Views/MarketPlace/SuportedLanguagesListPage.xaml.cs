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

        void OnButtonTapped(System.Object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.SuportedLanguagesListResponse);
        }

        void OnLabelTapped(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.SuportedLanguagesListResponse);
        }

        void OnItemTapped(Models.SuportedLanguagesListResponse suported)
        {
            suported.IsSelected = !suported.IsSelected;
            ViewModel.LanguageId = suported.Id;
            ViewModel.UpdateLanguageAvailableCommand.Execute(null);
        }
    }
}