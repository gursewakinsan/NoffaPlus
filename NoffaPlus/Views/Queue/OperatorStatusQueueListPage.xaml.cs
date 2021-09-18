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
	}
}