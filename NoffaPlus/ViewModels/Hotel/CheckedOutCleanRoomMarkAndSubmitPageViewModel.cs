using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class CheckedOutCleanRoomMarkAndSubmitPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckedOutCleanRoomMarkAndSubmitPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			var _lastPage = Navigation.NavigationStack.LastOrDefault();
			Navigation.RemovePage(_lastPage);
			await Navigation.PopAsync();
		}
		#endregion

		#region Update Room Cleaning Command.
		private ICommand updateRoomCleaningCommand;
		public ICommand UpdateRoomCleaningCommand
		{
			get => updateRoomCleaningCommand ?? (updateRoomCleaningCommand = new Command(async () => await ExecuteUpdateRoomCleaningCommand()));
		}
		private async Task ExecuteUpdateRoomCleaningCommand()
		{
			if (IsInspection && isCleanRoom && IsMinibar)
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				await service.UpdateCheckedOutRoomCleaningAsync(new Models.UpdateCheckedOutRoomCleaningRequest()
				{
					RoomId = CheckedOutCleningStaffInfo.RoomId
				});
				DependencyService.Get<IProgressBar>().Hide();
				var _lastPage = Navigation.NavigationStack.LastOrDefault();
				Navigation.RemovePage(_lastPage);
				await Navigation.PopAsync();
			}
		}
		#endregion

		#region Selected Room Cleaning Option Command.
		private ICommand selectedRoomCleaningOptionCommand;
		public ICommand SelectedRoomCleaningOptionCommand
		{
			get => selectedRoomCleaningOptionCommand ?? (selectedRoomCleaningOptionCommand = new Command<string>((selectedOption) => ExecuteSelectedRoomCleaningOptionCommand(selectedOption)));
		}
		private void ExecuteSelectedRoomCleaningOptionCommand(string selectedOption)
		{
			switch (selectedOption)
			{
				case "Inspection":
					if (IsInspection)
					{
						IsInspection = false;
						InspectionColor = Color.FromHex("#2A2A31");
					}
					else
					{
						IsInspection = true;
						InspectionColor = Color.FromHex("#45C366");
					}
					break;
				case "Clean room":
					if (IsCleanRoom)
					{
						IsCleanRoom = false;
						CleanRoomColor = Color.FromHex("#2A2A31");
					}
					else
					{
						IsCleanRoom = true;
						CleanRoomColor = Color.FromHex("#45C366");
					}
					break;
				case "Minibar":
					if (IsMinibar)
					{
						IsMinibar = false;
						MinibarColor = Color.FromHex("#2A2A31");
					}
					else
					{
						IsMinibar = true;
						MinibarColor = Color.FromHex("#45C366");
					}
					break;
			}
			if (IsInspection && isCleanRoom && IsMinibar)
			{
				SubmitButtonBgColor = Color.FromHex("#625FDA");
				SubmitButtonBorderColor = Color.FromHex("#625FDA");
			}
			else
			{
				SubmitButtonBgColor = Color.Transparent;
				SubmitButtonBorderColor = Color.FromHex("#2A2A31");
			}
		}
		#endregion

		#region Properties.
		private Models.HotelCheckedOutListForCleningStaffResponse checkedOutCleningStaffInfo;
		public Models.HotelCheckedOutListForCleningStaffResponse CheckedOutCleningStaffInfo
		{
			get => checkedOutCleningStaffInfo;
			set
			{
				checkedOutCleningStaffInfo = value;
				OnPropertyChanged("CheckedOutCleningStaffInfo");
			}
		}

		private bool isInspection = false;
		public bool IsInspection
		{
			get => isInspection;
			set
			{
				isInspection = value;
				OnPropertyChanged("IsInspection");
			}
		}

		private Color inspectionColor = Color.FromHex("#2A2A31");
		public Color InspectionColor
		{
			get => inspectionColor;
			set
			{
				inspectionColor = value;
				OnPropertyChanged("InspectionColor");
			}
		}

		private bool isCleanRoom = false;
		public bool IsCleanRoom
		{
			get => isCleanRoom;
			set
			{
				isCleanRoom = value;
				OnPropertyChanged("IsCleanRoom");
			}
		}

		private Color cleanRoomColor = Color.FromHex("#2A2A31");
		public Color CleanRoomColor
		{
			get => cleanRoomColor;
			set
			{
				cleanRoomColor = value;
				OnPropertyChanged("CleanRoomColor");
			}
		}

		private bool isMinibar = false;
		public bool IsMinibar
		{
			get => isMinibar;
			set
			{
				isMinibar = value;
				OnPropertyChanged("IsMinibar");
			}
		}

		private Color minibarColor = Color.FromHex("#2A2A31");
		public Color MinibarColor
		{
			get => minibarColor;
			set
			{
				minibarColor = value;
				OnPropertyChanged("MinibarColor");
			}
		}

		private Color submitButtonBgColor = Color.Transparent;
		public Color SubmitButtonBgColor
		{
			get => submitButtonBgColor;
			set
			{
				submitButtonBgColor = value;
				OnPropertyChanged("SubmitButtonBgColor");
			}
		}

		private Color submitButtonBorderColor = Color.FromHex("#2A2A31");
		public Color SubmitButtonBorderColor
		{
			get => submitButtonBorderColor;
			set
			{
				submitButtonBorderColor = value;
				OnPropertyChanged("SubmitButtonBorderColor");
			}
		}
		#endregion
	}
}
