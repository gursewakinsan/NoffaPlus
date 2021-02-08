using Xamarin.Forms;
using System.Windows.Input;
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
	}
}
