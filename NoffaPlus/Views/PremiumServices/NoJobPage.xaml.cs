using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.PremiumServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoJobPage : ContentPage
    {
        NoJobPageViewModel viewModel;
        public NoJobPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoJobPageViewModel(this.Navigation);
        }
    }
}