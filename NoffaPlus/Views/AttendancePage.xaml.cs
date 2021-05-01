using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttendancePage : ContentPage
	{
		AttendancePageViewModel viewModel;
		public AttendancePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AttendancePageViewModel(this.Navigation);
		}
	}
}