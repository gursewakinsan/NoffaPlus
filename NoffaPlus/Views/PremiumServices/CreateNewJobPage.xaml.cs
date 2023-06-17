using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using System.Collections.Generic;

namespace NoffaPlus.Views.PremiumServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNewJobPage : ContentPage
    {
        CreateNewJobPageViewModel viewModel;
        public CreateNewJobPage(List<Models.EmployeeProfessionalServiceProposalsDatesResponse> dates)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CreateNewJobPageViewModel(this.Navigation);
            dates[0].IsDateSelected = true;
            viewModel.ProposalsDates = dates;
            viewModel.BookingDate = dates[0].BookingDate;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetProposalsInfoCommand.Execute(null);
        }

        #region On Proposals Dates Tapped
        private void OnGridProposalsDatesTapped(object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnProposalsDatesTapped(control.BindingContext as Models.EmployeeProfessionalServiceProposalsDatesResponse);
        }

        private void OnFrameProposalsDatesTapped(object sender, System.EventArgs e)
        {
            Frame control = sender as Frame;
            OnProposalsDatesTapped(control.BindingContext as Models.EmployeeProfessionalServiceProposalsDatesResponse);
        }

        private void OnLabelProposalsDatesTapped(object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnProposalsDatesTapped(control.BindingContext as Models.EmployeeProfessionalServiceProposalsDatesResponse);
        }

        private void OnBoxViewProposalsDatesTapped(object sender, System.EventArgs e)
        {
            BoxView control = sender as BoxView;
            OnProposalsDatesTapped(control.BindingContext as Models.EmployeeProfessionalServiceProposalsDatesResponse);
        }

        void OnProposalsDatesTapped(Models.EmployeeProfessionalServiceProposalsDatesResponse dates)
        { 
            foreach (var item in viewModel.ProposalsDates) 
            {
                if(item.BookingDate == dates.BookingDate)
                    item.IsDateSelected = true;
                else
                    item.IsDateSelected = false;
            }
            viewModel.BookingDate = dates.BookingDate;
            viewModel.GetProposalsInfoCommand.Execute(null);
        }
        #endregion
    }
}