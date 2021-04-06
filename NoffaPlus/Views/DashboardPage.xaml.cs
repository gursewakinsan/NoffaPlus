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

		/*private void OnPickerCompanySelectedIndexChanged(object sender, System.EventArgs e)
		{
			CustomPicker picker = sender as CustomPicker;
			if (picker == null) return;
			if (picker.SelectedIndex != -1)
			{
				Models.Company company = picker.SelectedItem as Models.Company;
				dashboardViewModel.GoToChildrenMissingCommand.Execute(company.CompanyId);
			}
		}*/
	}
}