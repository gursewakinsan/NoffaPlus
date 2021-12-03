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

		private void OnGridOperatorQueueTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Helper.Helper.SelectedOperatorQueue = grid.BindingContext as Models.OperatorQueueResponse;
			viewModel.GoToOperatorStatusQueueListCommand.Execute(null);
		}

		private void OnFrameOperatorQueueTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Helper.Helper.SelectedOperatorQueue = frame.BindingContext as Models.OperatorQueueResponse;
			viewModel.GoToOperatorStatusQueueListCommand.Execute(null);
		}
	}
}