using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
    public class StartedDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public StartedDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Finished Button Command.
		private ICommand finishedButtonCommand;
		public ICommand FinishedButtonCommand
		{
			get => finishedButtonCommand ?? (finishedButtonCommand = new Command(() => ExecuteFinishedButtonCommand()));
		}
		private void ExecuteFinishedButtonCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Cancel Button Command.
		private ICommand cancelButtonCommand;
		public ICommand CancelButtonCommand
		{
			get => cancelButtonCommand ?? (cancelButtonCommand = new Command(() => ExecuteCancelButtonCommand()));
		}
		private void ExecuteCancelButtonCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Finished Command.
		private ICommand finishedCommand;
		public ICommand FinishedCommand
		{
			get => finishedCommand ?? (finishedCommand = new Command(() => ExecuteFinishedCommand()));
		}
		private void ExecuteFinishedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.FinishPage());
		}
		#endregion

		#region Cancelled Command.
		private ICommand cancelledCommand;
		public ICommand CancelledCommand
		{
			get => cancelledCommand ?? (cancelledCommand = new Command(() => ExecuteCancelledCommand()));
		}
		private void ExecuteCancelledCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.CancelledPage());
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
