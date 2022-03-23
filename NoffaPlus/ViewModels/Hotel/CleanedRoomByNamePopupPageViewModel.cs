using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.ViewModels
{
	public class CleanedRoomByNamePopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleanedRoomByNamePopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaned Room Command.
		private ICommand cleanedRoomCommand;
		public ICommand CleanedRoomCommand
		{
			get => cleanedRoomCommand ?? (cleanedRoomCommand = new Command(async () => await ExecuteCleanedRoomCommand()));
		}
		private async Task ExecuteCleanedRoomCommand()
		{
			await Navigation.PopPopupAsync();
			if (CleningStaffInfo.RoomCleaningStaffId.Equals(Helper.Helper.LoggedInUserId))
				CleningStaffInfo.CallBack.Invoke();
		}
		#endregion

		#region Properties.

		private Models.HotelBookingListForCleningStaffResponse cleningStaffInfo;
		public Models.HotelBookingListForCleningStaffResponse CleningStaffInfo
		{
			get => cleningStaffInfo;
			set
			{
				cleningStaffInfo = value;
				OnPropertyChanged("CleningStaffInfo");
			}
		}
		#endregion
	}
}
