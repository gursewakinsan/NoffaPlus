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
			await Navigation.PushAsync(new Views.Hotel.CheckInGuestPage());
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
			await Navigation.PushAsync(new Views.Hotel.HandOverkeyPage());
		}
		#endregion

		#region Checkout In Flow Command.
		private ICommand checkoutInFlowCommand;
		public ICommand CheckoutInFlowCommand
		{
			get => checkoutInFlowCommand ?? (checkoutInFlowCommand = new Command(async () => await ExecuteCheckoutInFlowCommand()));
		}
		private async Task ExecuteCheckoutInFlowCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.CheckOutGuestPage());
		}
		#endregion

		#region Clean In Flow Command.
		private ICommand cleanInFlowCommand;
		public ICommand CleanInFlowCommand
		{
			get => cleanInFlowCommand ?? (cleanInFlowCommand = new Command(async () => await ExecuteCleanInFlowCommand()));
		}
		private async Task ExecuteCleanInFlowCommand()
		{
			await Navigation.PushAsync(new Views.Hotel.CleanRoomPage());
		}
		#endregion
	}
}
