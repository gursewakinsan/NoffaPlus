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
	}
}