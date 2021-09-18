using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Queue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OperatorQueueListPage : ContentPage
	{
		OperatorQueueListViewModel viewModel;
		public OperatorQueueListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new OperatorQueueListViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetOperatorQueueCommand.Execute(null);
		}

		private void OnOperatorQueueListItemTapped(object sender, System.EventArgs e)
		{
			Frame frameOperatorQueueListItem = sender as Frame;
			Helper.Helper.SelectedOperatorQueue = frameOperatorQueueListItem.BindingContext as Models.OperatorQueueResponse;
			viewModel.GoToOperatorStatusQueueListCommand.Execute(null);
		}
	}
}