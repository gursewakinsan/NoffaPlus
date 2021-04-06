using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class CompanyDetailsViewModel : BaseViewModel
	{
		#region Constructor.
		public CompanyDetailsViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Admin Command.
		private ICommand adminCommand;
		public ICommand AdminCommand
		{
			get => adminCommand ?? (adminCommand = new Command(async () => await ExecuteAdminCommand()));
		}
		private async Task ExecuteAdminCommand()
		{
			await Navigation.PushAsync(new Views.AdminInfoPage());
		}
		#endregion

		#region Verify Admin Command.
		private ICommand verifyAdminCommand;
		public ICommand VerifyAdminCommand
		{
			get => verifyAdminCommand ?? (verifyAdminCommand = new Command(async () => await ExecuteVerifyAdminCommand()));
		}
		private async Task ExecuteVerifyAdminCommand()
		{
			if (CompanyDetail != null) return;
			DependencyService.Get<IProgressBar>().Show();
			Models.VerifyAdminRequest request = new Models.VerifyAdminRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			};
			ICompanyService service = new CompanyService();
			CompanyDetail = await service.VerifyAdminAsync(request);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Children Missing Command.
		private ICommand childrenMissingCommand;
		public ICommand ChildrenMissingCommand
		{
			get => childrenMissingCommand ?? (childrenMissingCommand = new Command(async () => await ExecuteChildrenMissingCommand()));
		}
		private async Task ExecuteChildrenMissingCommand()
		{
			await Navigation.PushAsync(new Views.ChildrenMissingListPage());
		}
		#endregion

		#region Properties.
		private Models.VerifyAdminResponse companyDetail;
		public Models.VerifyAdminResponse CompanyDetail
		{
			get => companyDetail;
			set
			{
				companyDetail = value;
				OnPropertyChanged("CompanyDetail");
			}
		}

		public string DisplayCompanyName => Helper.Helper.CompanyName;
		#endregion
	}
}
