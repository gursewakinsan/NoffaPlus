using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.CleaningJob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningTasksPage : ContentPage
    {
        CleaningTasksPageViewModel viewModel;
        public CleaningTasksPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CleaningTasksPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CleaningToDoListCommand.Execute(null);
        }

        void OnLabelUpDownTapped(System.Object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.CleaningServiceAvailableTodoDetailResponse response = label.BindingContext as Models.CleaningServiceAvailableTodoDetailResponse;
            response.IsVisibleTodosInfo = !response.IsVisibleTodosInfo;
        }
    }
}
