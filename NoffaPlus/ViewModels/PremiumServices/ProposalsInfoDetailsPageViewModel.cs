﻿using System;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class ProposalsInfoDetailsPageViewModel : BaseViewModel
    {
        #region Constructor.
        public ProposalsInfoDetailsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Backgrund Proposals Info Details Command.
        private ICommand backgrundProposalsInfoDetailsCommand;
        public ICommand BackgrundProposalsInfoDetailsCommand
        {
            get => backgrundProposalsInfoDetailsCommand ?? (backgrundProposalsInfoDetailsCommand = new Command(async () => await ExecuteBackgrundProposalsInfoDetailsCommand()));
        }
        private async Task ExecuteBackgrundProposalsInfoDetailsCommand()
        {
            await Navigation.PushAsync(new Views.PremiumServices.BackgrundProposalsInfoDetailsPage(ProposalsInfoDetails, ProposalsDates));
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
        #endregion
    }
}