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
            viewModel.ProposalsDates = dates;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetProposalsInfoCommand.Execute(null);
        }
    }
}