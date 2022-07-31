using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class NotStartedDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public NotStartedDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Start This Button Command.
		private ICommand startThisButtonCommand;
		public ICommand StartThisButtonCommand
		{
			get => startThisButtonCommand ?? (startThisButtonCommand = new Command(() => ExecuteStartThisButtonCommand()));
		}
		private void ExecuteStartThisButtonCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion
	}
}
