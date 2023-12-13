using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class MarketPlaceListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public MarketPlaceListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Company Market place List Command.
        private ICommand companyMarketplaceListCommand;
        public ICommand CompanyMarketplaceListCommand
        {
            get => companyMarketplaceListCommand ?? (companyMarketplaceListCommand = new Command(async () => await ExecuteCompanyMarketplaceListCommand()));
        }
        private async Task ExecuteCompanyMarketplaceListCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IMarketPlaceService service = new MarketPlaceService();
            CompanyMarketplaceList = await service.CompanyMarketplaceListAsync(new Models.CompanyMarketplaceListRequest()
            {
                CompanyId = Helper.Helper.CompanyId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        public List<Models.CompanyMarketplaceListResponse> companyMarketplaceList;
        public List<Models.CompanyMarketplaceListResponse> CompanyMarketplaceList
        {
            get => companyMarketplaceList;
            set
            {
                companyMarketplaceList = value;
                OnPropertyChanged("CompanyMarketplaceList");
            }
        }
        #endregion
    }
}
