using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.CleaningJob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignTaskToStaffPage : ContentPage
    {
        AssignTaskToStaffPageViewModel viewModel;
        public AssignTaskToStaffPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new AssignTaskToStaffPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CleanersAssignedListCommand.Execute(null);
        }

        void OnLabelTapped(System.Object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            OnTapped(label.BindingContext as Models.CleanersAssignedListResponse);
        }

        void OnGridTapped(System.Object sender, System.EventArgs e)
        {
            Grid grid = sender as Grid;
            OnTapped(grid.BindingContext as Models.CleanersAssignedListResponse);
        }

        void OnTapped(Models.CleanersAssignedListResponse cleaners)
        {
            cleaners.IsSelected = !cleaners.IsSelected;
        }

        void OnLabelAllCheckedTapped(System.Object sender, System.EventArgs e)
        {
            if (viewModel.CleanersAssignedList?.Count > 0)
            {
                if (viewModel.IsAllCheckedUnChecked)
                {
                    viewModel.IsAllCheckedUnChecked = false;
                    foreach (var item in viewModel.CleanersAssignedList)
                        item.IsSelected = false;
                }
                else
                {
                    viewModel.IsAllCheckedUnChecked = true;
                    foreach (var item in viewModel.CleanersAssignedList)
                        item.IsSelected = true;
                }
            }
        }
    }
}
