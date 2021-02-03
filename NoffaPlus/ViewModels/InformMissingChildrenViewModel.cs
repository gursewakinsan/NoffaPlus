using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class InformMissingChildrenViewModel : BaseViewModel
	{
		#region Constructor.
		public InformMissingChildrenViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Inform To Employees.
		private ICommand informToEmployeesCommand;
		public ICommand InformToEmployeesCommand
		{
			get => informToEmployeesCommand ?? (informToEmployeesCommand = new Command(async () => await ExecuteInformToEmployeesCommand()));
		}
		private async Task ExecuteInformToEmployeesCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IChildrenService service = new ChildrenService();
			var response = await service.InformToEmployeesForMissingChildrenAsync(Helper.Helper.CompanyId);
			var _lastPage = Navigation.NavigationStack.LastOrDefault();
			Navigation.RemovePage(_lastPage);
			DependencyService.Get<IProgressBar>().Hide();
			await Navigation.PopAsync();
		}
		#endregion
	}
}
