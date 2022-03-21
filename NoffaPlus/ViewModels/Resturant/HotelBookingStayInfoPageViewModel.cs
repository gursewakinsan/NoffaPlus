using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class HotelBookingStayInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public HotelBookingStayInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Check-in flow Command.
		private ICommand checkInFlowCommand;
		public ICommand CheckInFlowCommand
		{
			get => checkInFlowCommand ?? (checkInFlowCommand = new Command(async () => await ExecuteCheckInFlowCommand()));
		}
		private async Task ExecuteCheckInFlowCommand()
		{
			await Navigation.PushAsync(new Views.Resturant.CheckInGuestPage());
		}
		#endregion

		#region Key-in flow Command.
		private ICommand keyInFlowCommand;
		public ICommand KeyInFlowCommand
		{
			get => keyInFlowCommand ?? (keyInFlowCommand = new Command(async () => await ExecuteKeyInFlowCommand()));
		}
		private async Task ExecuteKeyInFlowCommand()
		{
			await Navigation.PushAsync(new Views.Resturant.HandOverkeyPage());
		}
		#endregion
	}
}
