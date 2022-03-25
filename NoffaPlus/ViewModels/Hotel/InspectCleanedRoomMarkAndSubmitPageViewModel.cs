using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class InspectCleanedRoomMarkAndSubmitPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InspectCleanedRoomMarkAndSubmitPageViewModel(INavigation navigation)
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

		#region Update Room Inspection Command.
		private ICommand updateRoomInspectionCommand;
		public ICommand UpdateRoomInspectionCommand
		{
			get => updateRoomInspectionCommand ?? (updateRoomInspectionCommand = new Command(async () => await ExecuteUpdateRoomInspectionCommand()));
		}
		private async Task ExecuteUpdateRoomInspectionCommand()
		{
			if (IsApproved || IsNotApproved)
			{
				DependencyService.Get<IProgressBar>().Show();
				IHotelService service = new HotelService();
				await service.UpdateCheckedOutRoomInspectionAsync(new Models.UpdateCheckedOutRoomInspectionRequest()
				{
					Id = SelectedInspectedStaffInfo.Id,
					RoomId = SelectedInspectedStaffInfo.RoomId,
					InspectionResult = SelectedInspectedStaffInfo.InspectorId
				});
				DependencyService.Get<IProgressBar>().Hide();
				var _lastPage = Navigation.NavigationStack.LastOrDefault();
				Navigation.RemovePage(_lastPage);
				await Navigation.PopAsync();
			}
		}
		#endregion

		#region Selected Inspect Cleaned Room Command.
		private ICommand selectedInspectCleanedRoomCommand;
		public ICommand SelectedInspectCleanedRoomCommand
		{
			get => selectedInspectCleanedRoomCommand ?? (selectedInspectCleanedRoomCommand = new Command<string>((selectedOption) => ExecuteSelectedInspectCleanedRoomCommand(selectedOption)));
		}
		private void ExecuteSelectedInspectCleanedRoomCommand(string selectedOption)
		{
			switch (selectedOption)
			{
				case "Its approved":
					if (IsApproved)
					{
						IsApproved = false;
						ApprovedColor = Color.FromHex("#2A2A31");
					}
					else
					{
						IsApproved = true;
						ApprovedColor = Color.FromHex("#45C366");
					}
					break;
				case "Its not approved":
					if (IsNotApproved)
					{
						IsNotApproved = false;
						NotApprovedColor = Color.FromHex("#2A2A31");
					}
					else
					{
						IsNotApproved = true;
						NotApprovedColor = Color.FromHex("#45C366");
					}
					break;
			}
			if (IsApproved || IsNotApproved)
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
		private Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse selectedInspectedStaffInfo;
		public Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse SelectedInspectedStaffInfo
		{
			get => selectedInspectedStaffInfo;
			set
			{
				selectedInspectedStaffInfo = value;
				OnPropertyChanged("SelectedInspectedStaffInfo");
			}
		}

		private bool isApproved = false;
		public bool IsApproved
		{
			get => isApproved;
			set
			{
				isApproved = value;
				OnPropertyChanged("IsApproved");
			}
		}

		private Color approvedColor = Color.FromHex("#2A2A31");
		public Color ApprovedColor
		{
			get => approvedColor;
			set
			{
				approvedColor = value;
				OnPropertyChanged("ApprovedColor");
			}
		}

		private bool isNotApproved = false;
		public bool IsNotApproved
		{
			get => isNotApproved;
			set
			{
				isNotApproved = value;
				OnPropertyChanged("IsNotApproved");
			}
		}

		private Color notApprovedColor = Color.FromHex("#2A2A31");
		public Color NotApprovedColor
		{
			get => notApprovedColor;
			set
			{
				notApprovedColor = value;
				OnPropertyChanged("NotApprovedColor");
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
