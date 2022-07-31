using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using System.Collections.Generic;

namespace NoffaPlus.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartedDetailsPage : ContentPage
    {
        StartedDetailsPageViewModel viewModel;
        public StartedDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new StartedDetailsPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            int deviceWidth = App.ScreenWidth - 56;
            int imgWidth = deviceWidth * 25 / 100;

            List<DemoData> demos = new List<DemoData>();
            for (int i = 0; i < 3; i++)
            {
                demos.Add(new DemoData { ItemWidth = imgWidth });
            }

            BindableLayout.SetItemsSource(layoutImages, demos);
        }
    }
}