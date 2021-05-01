using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VacationPage : ContentPage
	{
		VacationPageViewModel viewModel;
		public VacationPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VacationPageViewModel(this.Navigation);
		}
	}
}