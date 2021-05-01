using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class VacationPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VacationPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Sick Command.
		private ICommand goToSickPageCommand;
		public ICommand GoToSickPageCommand
		{
			get => goToSickPageCommand ?? (goToSickPageCommand = new Command(async () => await ExecuteGoToSickPageCommand()));
		}
		private async Task ExecuteGoToSickPageCommand()
		{
			await Navigation.PushAsync(new Views.SickPage());
		}
		#endregion

		#region Properties.
		#endregion
	}
}
