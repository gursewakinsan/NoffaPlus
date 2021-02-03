using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportMissingPage : ContentPage
	{
		ReportMissingViewModel reportMissingViewModel;
		public ReportMissingPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = reportMissingViewModel = new ReportMissingViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			reportMissingViewModel.ReportMissingChildrenCommand.Execute(null);
			base.OnAppearing();
		}

		private void OnReportMissingChildrenItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.Children children = e.Item as Models.Children;
			children.IsSelected = !children.IsSelected;
			listReportMissingChildren.SelectedItem = null;
			reportMissingViewModel.SelectReportMissingChildren(children.Id);
		}
	}
}