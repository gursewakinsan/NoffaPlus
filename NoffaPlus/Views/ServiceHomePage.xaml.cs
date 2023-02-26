using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceHomePage : ContentPage
    {
        ServiceHomePageViewModel viewModel;
        public ServiceHomePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ServiceHomePageViewModel(this.Navigation);
        }
    }
}
