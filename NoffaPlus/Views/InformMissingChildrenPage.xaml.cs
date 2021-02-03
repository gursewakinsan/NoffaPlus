using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformMissingChildrenPage : ContentPage
	{
		public InformMissingChildrenPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = new InformMissingChildrenViewModel(this.Navigation);
		}
	}
}