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
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.TabSelectedCommand.Execute(Helper.Helper.SelectedTabQueueText);
		}

		private async void OnGridWaitingListTapped(object sender, System.EventArgs e)
		{
			Grid gridWaitingList = sender as Grid;
			Models.OperatorQueueListResponse response = gridWaitingList.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new WaitingGuestServicesDetailPage());
		}

		private async void OnFrameWaitingListTapped(object sender, System.EventArgs e)
		{
			Frame frameWaitingList = sender as Frame;
			Models.OperatorQueueListResponse response = frameWaitingList.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new WaitingGuestServicesDetailPage());
		}

		private async void OnWaitingListButtonClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.OperatorQueueListResponse response = button.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new WaitingGuestServicesDetailPage());
		}

		private async void OnGridInserviceInfoTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.OperatorQueueListResponse response = grid.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new InServicesGuestDetailPage());
		}

		private async void OnFrameInserviceInfoTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.OperatorQueueListResponse response = frame.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new InServicesGuestDetailPage());
		}
		
		private async void OnInserviceInfoButtonClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.OperatorQueueListResponse response = button.BindingContext as Models.OperatorQueueListResponse;
			Helper.Helper.QueueGuestId = response.Id;
			await Navigation.PushAsync(new InServicesGuestDetailPage());
		}
	}
}