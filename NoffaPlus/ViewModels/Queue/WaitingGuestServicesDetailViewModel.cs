using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class WaitingGuestServicesDetailViewModel : BaseViewModel
	{
		#region Constructor.
		public WaitingGuestServicesDetailViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Queue Guest Detail Command.
		private ICommand queueGuestDetailCommand;
		public ICommand QueueGuestDetailCommand
		{
			get => queueGuestDetailCommand ?? (queueGuestDetailCommand = new Command(async () => await ExecuteQueueGuestDetailCommand()));
		}
		private async Task ExecuteQueueGuestDetailCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IQueueService service = new QueueService();
			QueueGuestDetail = await service.QueueGuestDetailAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.QueueGuestDetailResponse queueGuestDetail;
		public Models.QueueGuestDetailResponse QueueGuestDetail
		{
			get => queueGuestDetail;
			set
			{
				queueGuestDetail = value;
				OnPropertyChanged("QueueGuestDetail");
			}
		}
		#endregion
	}
}
