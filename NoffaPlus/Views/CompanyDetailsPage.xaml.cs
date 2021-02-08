using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyDetailsPage : ContentPage
	{
		CompanyDetailsViewModel companyDetailsViewModel;
		public CompanyDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = companyDetailsViewModel = new CompanyDetailsViewModel(this.Navigation);
		}
	}
}