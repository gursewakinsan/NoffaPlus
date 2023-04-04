using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.CleaningJob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningJobStatusInfoPage : ContentPage
    {
        CleaningJobStatusInfoPageViewModel viewModel;
        public CleaningJobStatusInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CleaningJobStatusInfoPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CleaningJobStatusInfoCommand.Execute(null);
        }

        void CustomPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Controls.CustomPicker picker = sender as Controls.CustomPicker;
            if (picker.SelectedIndex == -1)
                return;
            else if (viewModel != null)
                viewModel.IsRentable = picker.SelectedIndex;
        }
    }
}
