using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailsPage : ContentPage
	{
		ContactDetailsPageViewModel ViewModel;
		public ContactDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = ViewModel = new ContactDetailsPageViewModel(this.Navigation);
		}
	}
}