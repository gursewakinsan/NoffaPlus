using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
    public partial class TestPage : ContentPage
    {
        TestPageViewModel viewModel;
        public TestPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TestPageViewModel(this.Navigation);
        }
    }
}
