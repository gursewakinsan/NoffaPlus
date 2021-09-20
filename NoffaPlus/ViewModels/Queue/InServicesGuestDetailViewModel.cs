using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class InServicesGuestDetailViewModel : BaseViewModel
	{
		#region Constructor.
		public InServicesGuestDetailViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Queue Servicing Guest Detail Command.
		private ICommand queueServicingGuestDetailCommand;
		public ICommand QueueServicingGuestDetailCommand
		{
			get => queueServicingGuestDetailCommand ?? (queueServicingGuestDetailCommand = new Command(async () => await ExecuteQueueServicingGuestDetailCommand()));
		}
		private async Task ExecuteQueueServicingGuestDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			QueueServicingGuestDetail = await service.QueueServicingGuestDetailAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});

			if (QueueServicingGuestDetail.ServingUserId.Equals(Helper.Helper.LoggedInUserId))
			{
				AddedBy = "Self";
				IsVisibleDone = true;
			}
			else
			{
				AddedBy = QueueServicingGuestDetail.UserServing;
				IsVisibleDone = false;
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Done Command.
		private ICommand doneCommand;
		public ICommand DoneCommand
		{
			get => doneCommand ?? (doneCommand = new Command(async () => await ExecuteDoneCommand()));
		}
		private async Task ExecuteDoneCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			int response = await service.UpdateCloseServiceAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});
			if (response == 1)
			{
				Helper.Helper.SelectedTabQueueText = "Serviced";
				await Navigation.PopAsync();
			}
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again.");
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.QueueServicingGuestDetailResponse queueServicingGuestDetail;
		public Models.QueueServicingGuestDetailResponse QueueServicingGuestDetail
		{
			get => queueServicingGuestDetail;
			set
			{
				queueServicingGuestDetail = value;
				OnPropertyChanged("QueueServicingGuestDetail");
			}
		}

		private bool isVisibleDone;
		public bool IsVisibleDone
		{
			get => isVisibleDone;
			set
			{
				isVisibleDone = value;
				OnPropertyChanged("IsVisibleDone");
			}
		}

		private string addedBy;
		public string AddedBy
		{
			get => addedBy;
			set
			{
				addedBy = value;
				OnPropertyChanged("AddedBy");
			}
		}
		#endregion
	}
}
