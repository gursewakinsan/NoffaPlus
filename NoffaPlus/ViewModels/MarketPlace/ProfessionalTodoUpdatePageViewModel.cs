using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class ProfessionalTodoUpdatePageViewModel : BaseViewModel
    {
        #region Constructor.
        public ProfessionalTodoUpdatePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ProfessionalTodoUpdateList = new List<ProfessionalTodoUpdateModel>();
            ProfessionalTodoUpdateList.Add(new ProfessionalTodoUpdateModel()
            {
                Name = "Services",
                TextIcon = Helper.NoffaPlusAppFlatIcons.CarEstate
            });
            ProfessionalTodoUpdateList.Add(new ProfessionalTodoUpdateModel()
            {
                Name = "Pricing",
                TextIcon = Helper.NoffaPlusAppFlatIcons.CartOutline
            });
            ProfessionalTodoUpdateList.Add(new ProfessionalTodoUpdateModel()
            {
                Name = "Languages",
                TextIcon = Helper.NoffaPlusAppFlatIcons.MessageOutline
            });
        }
        #endregion

        #region Professional Todo Update Command.
        private ICommand professionalTodoUpdateCommand;
        public ICommand ProfessionalTodoUpdateCommand
        {
            get => professionalTodoUpdateCommand ?? (professionalTodoUpdateCommand = new Command(async () => await ExecuteProfessionalTodoUpdateCommand()));
        }
        private async Task ExecuteProfessionalTodoUpdateCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IMarketPlaceService service = new MarketPlaceService();
            await service.ProfessionalTodoUpdateAsync(new Models.ProfessionalTodoUpdateRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = SelectedCompanyMarketplace.Id
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        public Models.CompanyMarketplaceListResponse selectedCompanyMarketplace;
        public Models.CompanyMarketplaceListResponse SelectedCompanyMarketplace
        {
            get => selectedCompanyMarketplace;
            set
            {
                selectedCompanyMarketplace = value;
                OnPropertyChanged("SelectedCompanyMarketplace");
            }
        }

        public List<ProfessionalTodoUpdateModel> professionalTodoUpdateList;
        public List<ProfessionalTodoUpdateModel> ProfessionalTodoUpdateList
        {
            get => professionalTodoUpdateList;
            set
            {
                professionalTodoUpdateList = value;
                OnPropertyChanged("ProfessionalTodoUpdateList");
            }
        }
        #endregion
    }
}

public class ProfessionalTodoUpdateModel
{
    public string TextIcon { get; set; }
    public string Name { get; set; }
}
