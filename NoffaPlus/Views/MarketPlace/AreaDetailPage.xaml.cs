using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaDetailPage : ContentPage
    {
        AreaDetailPageViewModel ViewModel;
        public AreaDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new AreaDetailPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetAreaDetailCommand.Execute(null);
        }

        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.AreaList);
        }

        private void OnStackLayoutTapped(object sender, System.EventArgs e)
        {
            StackLayout control = sender as StackLayout;
            OnItemTapped(control.BindingContext as Models.AreaList);
        }

        private void OnLabelTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.AreaList);
        }

        void OnItemTapped(Models.AreaList area)
        {
            area.IsSelected = !area.IsSelected;
            ViewModel.AreaId = area.Id;
            ViewModel.UpdateAreaDetailCommand.Execute(null);
        }
    }
}