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
			//listCompany.SelectedItem = null;
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

        void OnFrameTapped(System.Object sender, System.EventArgs e)
        {
			Frame control = sender as Frame;
			OnItemTapped(control.BindingContext as Models.Company);
		}

        void OnGridTapped(System.Object sender, System.EventArgs e)
        {
			Grid control = sender as Grid;
			OnItemTapped(control.BindingContext as Models.Company);
		}

        void OnButtonTapped(System.Object sender, System.EventArgs e)
        {
			Button control = sender as Button;
			OnItemTapped(control.BindingContext as Models.Company);
		}

        void OnStackLayoutTapped(System.Object sender, System.EventArgs e)
        {
			StackLayout control = sender as StackLayout;
			OnItemTapped(control.BindingContext as Models.Company);
		}

        void OnLabelTapped(System.Object sender, System.EventArgs e)
        {
			Label control = sender as Label;
			OnItemTapped(control.BindingContext as Models.Company);
		}

		void OnItemTapped(Models.Company company)
		{
			Helper.Helper.CompanyName = company.CompanyName;
			dashboardViewModel.GoToChildrenMissingCommand.Execute(company.CompanyId);
		}
    }
}