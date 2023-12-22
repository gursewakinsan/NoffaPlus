using Xamarin.Forms;
using NoffaPlus.Helper;
using NoffaPlus.Views;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class DashboardViewModel : BaseViewModel
	{
		#region Constructor.
		public DashboardViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Companies Command.
		private ICommand getCompaniesCommand;
		public ICommand GetCompaniesCommand
		{
			get => getCompaniesCommand ?? (getCompaniesCommand = new Command(async () => await ExecuteGetCompaniesCommand()));
		}
		private async Task ExecuteGetCompaniesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IDashboardService service = new DashboardService();
			var response = await service.GetCompaniesByIdAsync(Helper.Helper.LoggedInUserId);
			if (response != null)
			{
				CompanyList = new ObservableCollection<Models.Company>(response);
				OnPropertyChanged("CompanyList");
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Go To Children Missing.
		private ICommand goToChildrenMissingCommand;
		public ICommand GoToChildrenMissingCommand
		{
			get => goToChildrenMissingCommand ?? (goToChildrenMissingCommand = new Command<int>(async (companyId) => await ExecuteGoToChildrenMissingCommand(companyId)));
		}
		private async Task ExecuteGoToChildrenMissingCommand(int companyId)
		{
			Helper.Helper.CompanyId = companyId;
			await Navigation.PushAsync(new CompanyDetailsPage());
		}
		#endregion

		#region Logout Command.
		private ICommand logoutCommand;
		public ICommand LogoutCommand
		{
			get => logoutCommand ?? (logoutCommand = new Command(async () => await ExecuteLogoutCommand()));
		}
		private async Task ExecuteLogoutCommand()
		{
			bool status = await Alert.ShowAlertYesNo("Are you sure you want to logout?");
		}
		#endregion

		#region Properties.
		public ObservableCollection<Models.Company> CompanyList { get; set; }
		public string FirstName => Helper.Helper.FirstName;
        public string LastName => Helper.Helper.LastName;
        #endregion
    }
}
