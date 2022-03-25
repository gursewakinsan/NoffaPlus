using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.ViewModels
{
	public class InspectedByRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InspectedByRoomPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Inspected Room Command.
		private ICommand inspectedRoomCommand;
		public ICommand InspectedRoomCommand
		{
			get => inspectedRoomCommand ?? (inspectedRoomCommand = new Command(async () => await ExecuteInspectedRoomCommand()));
		}
		private async Task ExecuteInspectedRoomCommand()
		{
			await Navigation.PopPopupAsync();
			if (InspectedByRoomInfo.InspectorId.Equals(Helper.Helper.LoggedInUserId))
				InspectedByRoomInfo.CallBack.Invoke();
		}
		#endregion

		#region Properties.

		private Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse inspectedByRoomInfo;
		public Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse InspectedByRoomInfo
		{
			get => inspectedByRoomInfo;
			set
			{
				inspectedByRoomInfo = value;
				OnPropertyChanged("InspectedByRoomInfo");
			}
		}
		#endregion
	}
}
