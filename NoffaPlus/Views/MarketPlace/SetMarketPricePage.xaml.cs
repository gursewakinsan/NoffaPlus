using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetMarketPricePage : ContentPage
    {
        SetMarketPricePageViewModel ViewModel;
        public SetMarketPricePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new SetMarketPricePageViewModel(this.Navigation);
        }
    }
}