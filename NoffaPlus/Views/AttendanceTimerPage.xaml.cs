using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttendanceTimerPage : ContentPage
	{
		AttendanceTimerPageViewModel viewModel;
		public AttendanceTimerPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AttendanceTimerPageViewModel(this.Navigation);
		}
	}
}