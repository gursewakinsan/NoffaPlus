﻿using System;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class CreateNewJobPageViewModel : BaseViewModel
    {
        #region Constructor.
        public CreateNewJobPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Get Proposals Info Command.
        private ICommand getProposalsInfoCommand;
        public ICommand GetProposalsInfoCommand
        {
            get => getProposalsInfoCommand ?? (getProposalsInfoCommand = new Command(async () => await ExecuteGetProposalsInfoCommand()));
        }
        private async Task ExecuteGetProposalsInfoCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IPremiumService service = new PremiumService();
            var responses = await service.EmployeeProfessionalServiceProposalsAsync(new Models.EmployeeProfessionalServiceProposalsRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                UserId = Helper.Helper.LoggedInUserId,
                BookingDate = BookingDate
            });
            if (responses?.Count > 0)
            {
                foreach (var item in responses)
                {
                    if(item.JobStatus ==0)
                        item.IsJobStart = true;
                    else if (item.JobStatus == 1)
                        item.IsJobFinesh = true;
                    else if (item.JobStatus == 2)
                        item.IsJobDone = true;
                }
            }
            ProposalsInfo = responses;
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.EmployeeProfessionalServiceProposalsResponse> proposalsInfo;
        public List<Models.EmployeeProfessionalServiceProposalsResponse> ProposalsInfo
        {
            get => proposalsInfo;
            set
            {
                proposalsInfo = value;
                OnPropertyChanged("ProposalsInfo");
            }
        }

        private List<Models.EmployeeProfessionalServiceProposalsDatesResponse> proposalsDates;
        public List<Models.EmployeeProfessionalServiceProposalsDatesResponse> ProposalsDates
        {
            get => proposalsDates;
            set
            {
                proposalsDates = value;
                OnPropertyChanged("ProposalsDates");
            }
        }

        public int BookingDate { get; set; }
        #endregion
    }
}
