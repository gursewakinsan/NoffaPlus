using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.ViewModels
{
	public class CleanRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleanRoomPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Clean Room Command.
		private ICommand cleanRoomCommand;
		public ICommand CleanRoomCommand
		{
			get => cleanRoomCommand ?? (cleanRoomCommand = new Command(async () => await ExecuteCleanRoomCommand()));
		}
		private async Task ExecuteCleanRoomCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IHotelService service = new HotelService();
			var responses = await service.AllocateRoomForCleaningAsync(new Models.AllocateRoomForCleaningRequest()
			{
				Id = CleningStaffInfo.Id,
				UserId = Helper.Helper.LoggedInUserId
			});
			await Navigation.PopPopupAsync();
			CleningStaffInfo.CallBack.Invoke();
			DependencyService.Get<IProgressBar>().Hide();
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
