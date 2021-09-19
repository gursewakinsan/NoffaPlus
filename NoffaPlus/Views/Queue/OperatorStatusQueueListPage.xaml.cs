using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Queue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OperatorStatusQueueListPage : ContentPage
	{
		OperatorStatusQueueListViewModel viewModel;
		public OperatorStatusQueueListPage ()
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new OperatorStatusQueueListViewModel(this.Navigation);
			Helper.Helper.SelectedTabQueueText = "Waiting";
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.TabSelectedCommand.Execute(Helper.Helper.SelectedTabQueueText);
		}

		private async void OnWaitingListItemTapped(object sender, System.EventArgs e)
		{
			Grid gridWaitingList = sender as Grid;
			Models.OperatorQueueListResponse response = gridWaitingList.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new WaitingGuestServicesDetailPage());
		}
	}
}