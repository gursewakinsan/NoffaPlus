using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using NoffaPlus.Controls;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardPage : ContentPage
	{
		DashboardViewModel dashboardViewModel;
		public DashboardPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = dashboardViewModel = new DashboardViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			dashboardViewModel.GetCompaniesCommand.Execute(null);
			base.OnAppearing();
		}

		private void OnCompanyItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.Company company = e.Item as Models.Company;
			listCompany.SelectedItem = null;
			Helper.Helper.CompanyName = company.CompanyName;
			dashboardViewModel.GoToChildrenMissingCommand.Execute(company.CompanyId);
		}

		private void OnImageButtonClicked(object sender, System.EventArgs e)
		{
			ImageButton button = sender as ImageButton;
			Models.Company company = button.BindingContext as Models.Company;
			Helper.Helper.CompanyName = company.CompanyName;
			dashboardViewModel.GoToChildrenMissingCommand.Execute(company.CompanyId);
		}
	}
}