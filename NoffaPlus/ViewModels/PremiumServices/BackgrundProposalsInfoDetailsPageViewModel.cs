using System;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
    public class BackgrundProposalsInfoDetailsPageViewModel : BaseViewModel
    {
        #region Constructor.
        public BackgrundProposalsInfoDetailsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Get Property Detail Command.
        private ICommand getPropertyDetailCommand;
        public ICommand GetPropertyDetailCommand
        {
            get => getPropertyDetailCommand ?? (getPropertyDetailCommand = new Command(async () => await ExecuteGetPropertyDetailCommand()));
        }
        private async Task ExecuteGetPropertyDetailCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IPremiumService service = new PremiumService();
            PropertyDetail = await service.PropertyDetailAsync(new Models.PropertyDetailRequest()
            {
                UserPropertyId = ProposalsInfoDetails.UserPropertyId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Update Professional Job Status Command.
        private ICommand updateProfessionalJobStatusCommand;
        public ICommand UpdateProfessionalJobStatusCommand
        {
            get => updateProfessionalJobStatusCommand ?? (updateProfessionalJobStatusCommand = new Command<string>(async (jobStatus) => await ExecuteUpdateProfessionalJobStatusCommand(jobStatus)));
        }
        private async Task ExecuteUpdateProfessionalJobStatusCommand(string jobStatus)
        {
            DependencyService.Get<IProgressBar>().Show();
            IPremiumService service = new PremiumService();
            await service.UpdateProfessionalJobStatusAsync(new Models.UpdateProfessionalJobStatusRequest()
            {
                JobId = ProposalsInfoDetails.JobId,
                JobStatus = jobStatus
            });
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private Models.EmployeeProfessionalServiceProposalsResponse proposalsInfoDetails;
        public Models.EmployeeProfessionalServiceProposalsResponse ProposalsInfoDetails
        {
            get => proposalsInfoDetails;
            set
            {
                proposalsInfoDetails = value;
                OnPropertyChanged("ProposalsInfoDetails");
            }
        }

        private Models.EmployeeProfessionalServiceProposalsDatesResponse proposalsDates;
        public Models.EmployeeProfessionalServiceProposalsDatesResponse ProposalsDates
        {
            get => proposalsDates;
            set
            {
                proposalsDates = value;
                OnPropertyChanged("ProposalsDates");
            }
        }

        private Models.PropertyDetailResponse propertyDetail;
        public Models.PropertyDetailResponse PropertyDetail
        {
            get => propertyDetail;
            set
            {
                propertyDetail = value;
                OnPropertyChanged("PropertyDetail");
            }
        }
        #endregion
    }
}
