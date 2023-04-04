using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
    public class CleaningJobStatusInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public CleaningJobStatusInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaning Job Status Info Command.
		private ICommand cleaningJobStatusInfoCommand;
		public ICommand CleaningJobStatusInfoCommand
		{
			get => cleaningJobStatusInfoCommand ?? (cleaningJobStatusInfoCommand = new Command(async () => await ExecuteCleaningJobStatusInfoCommand()));
		}
		private async Task ExecuteCleaningJobStatusInfoCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICleaningJobService service = new CleaningJobService();
			CleaningJobStatusInfo = await service.CleaningJobStatusInfoAsync(new Models.CleaningJobStatusInfoRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Cleaning Final Status Command.
		private ICommand updateCleaningFinalStatusCommand;
		public ICommand UpdateCleaningFinalStatusCommand
		{
			get => updateCleaningFinalStatusCommand ?? (updateCleaningFinalStatusCommand = new Command(async () => await ExecuteUpdateCleaningFinalStatusCommand()));
		}
		private async Task ExecuteUpdateCleaningFinalStatusCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICleaningJobService service = new CleaningJobService();
			await service.UpdateCleaningFinalStatusAsync(new Models.UpdateCleaningFinalStatusRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob,
				IfRentable = IsRentable
			});
			Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.CleaningJobStatusInfoResponse cleaningJobStatusInfo;
		public Models.CleaningJobStatusInfoResponse CleaningJobStatusInfo
		{
			get => cleaningJobStatusInfo;
			set
			{
				cleaningJobStatusInfo = value;
				OnPropertyChanged("CleaningJobStatusInfo");
			}
		}

        public int IsRentable { get; set; }
        #endregion
    }
}
