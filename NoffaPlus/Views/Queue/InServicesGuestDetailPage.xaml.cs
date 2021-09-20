using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Queue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InServicesGuestDetailPage : ContentPage
	{
		InServicesGuestDetailViewModel viewModel;
		public InServicesGuestDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InServicesGuestDetailViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.QueueServicingGuestDetailCommand.Execute(null);
		}
	}
}