using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class AppStoreInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AppStoreInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Company Downloaded Apps Command.
		private ICommand getCompanyDownloadedAppsCommand;
		public ICommand GetCompanyDownloadedAppsCommand
		{
			get => getCompanyDownloadedAppsCommand ?? (getCompanyDownloadedAppsCommand = new Command(async () => await ExecuteGetCompanyDownloadedAppsCommand()));
		}
		private async Task ExecuteGetCompanyDownloadedAppsCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			Models.CompanyDownloadedAppsRequest request = new Models.CompanyDownloadedAppsRequest()
			{
				CompanyId = Helper.Helper.CompanyId
			};
			ICompanyService service = new CompanyService();
			var response = await service.CompanyDownloadedAppsAsync(request);
			CompanyDownloadedApps = new ObservableCollection<Models.CompanyDownloadedAppsResponse>(response);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.CompanyDownloadedAppsResponse> companyDownloadedApps;
		public ObservableCollection<Models.CompanyDownloadedAppsResponse> CompanyDownloadedApps
		{
			get => companyDownloadedApps;
			set
			{
				companyDownloadedApps = value;
				OnPropertyChanged("CompanyDownloadedApps");
			}
		}
		#endregion
	}
}