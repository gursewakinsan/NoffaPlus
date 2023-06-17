using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class ServiceHomePageViewModel : BaseViewModel
	{
		#region Constructor.
		public ServiceHomePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaning Page Command.
		private ICommand cleaningPageCommand;
		public ICommand CleaningPageCommand
		{
			get => cleaningPageCommand ?? (cleaningPageCommand = new Command(async () => await ExecuteCleaningPageCommand()));
		}
		private async Task ExecuteCleaningPageCommand()
		{
			await Navigation.PushAsync(new Views.CleaningJob.CleaningJobsPage());
		}
		#endregion

		#region Repair Page Command.
		private ICommand repairPageCommand;
		public ICommand RepairPageCommand
		{
			get => repairPageCommand ?? (repairPageCommand = new Command(async () => await ExecuteRepairPageCommand()));
		}
		private async Task ExecuteRepairPageCommand()
		{
			await Navigation.PushAsync(new Views.Apartment.SupportPage());
		}
		#endregion

		#region House Inspection Page Command.
		private ICommand houseInspectionPageCommand;
		public ICommand HouseInspectionPageCommand
		{
			get => houseInspectionPageCommand ?? (houseInspectionPageCommand = new Command(async () => await ExecuteHouseInspectionPageCommand()));
		}
		private async Task ExecuteHouseInspectionPageCommand()
		{
			await Task.CompletedTask;
		}
        #endregion

        #region Premium Services Command.
        private ICommand premiumServicesCommand;
        public ICommand PremiumServicesCommand
        {
            get => premiumServicesCommand ?? (premiumServicesCommand = new Command(async () => await ExecutePremiumServicesCommand()));
        }
        private async Task ExecutePremiumServicesCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IPremiumService service = new PremiumService();
            var responses = await service.EmployeeProfessionalServiceProposalsDatesAsync(new Models.EmployeeProfessionalServiceProposalsDatesRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                UserId = Helper.Helper.LoggedInUserId,
            });
			if (responses?.Count > 0)
			{
				Helper.Helper.ProposalsDates = responses;
                await Navigation.PushAsync(new Views.PremiumServices.CreateNewJobPage(responses));
			}
			else
				await Navigation.PushAsync(new Views.PremiumServices.NoJobPage());
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion
    }
}
