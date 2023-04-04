using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.CleaningJob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegularFinishedCleaningTasksPage : ContentPage
    {
        RegularFinishedCleaningTasksPageViewModel viewModel;
        public RegularFinishedCleaningTasksPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new RegularFinishedCleaningTasksPageViewModel(this.Navigation);
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

        void OnSelectAllTapped(System.Object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.CleaningServiceAvailableTodoDetailResponse response = label.BindingContext as Models.CleaningServiceAvailableTodoDetailResponse;
            if (response.IsSelectAllTodoItems)
            {
                response.IsSelectAllTodoItems = false;
                foreach (var item in response.TodosInfo)
                    item.IsSelectTodoItem = false;
            }
            else
            {
                response.IsSelectAllTodoItems = true;
                foreach (var item in response.TodosInfo)
                    item.IsSelectTodoItem = true;
            }

        }

        void OnSelectedItemTapped(System.Object sender, System.EventArgs e)
        {
            Label label = sender as Label;
            Models.Todo response = label.BindingContext as Models.Todo;
            response.IsSelectTodoItem = !response.IsSelectTodoItem;
        }
    }
}
