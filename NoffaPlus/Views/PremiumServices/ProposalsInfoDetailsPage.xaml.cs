using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.PremiumServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProposalsInfoDetailsPage : ContentPage
    {
        ProposalsInfoDetailsPageViewModel viewModel;
        public ProposalsInfoDetailsPage(Models.EmployeeProfessionalServiceProposalsResponse proposalsInfo, Models.EmployeeProfessionalServiceProposalsDatesResponse dates)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ProposalsInfoDetailsPageViewModel(this.Navigation);
            viewModel.ProposalsInfoDetails = proposalsInfo;
            viewModel.ProposalsDates = dates;
        }
    }
}