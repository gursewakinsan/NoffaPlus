using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class CompanyMarketplaceServiceDetailPageViewModel : BaseViewModel
    {
        #region Constructor.
        public CompanyMarketplaceServiceDetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Company Marketplace Service Detail Command.
        private ICommand companyMarketplaceServiceDetailCommand;
        public ICommand CompanyMarketplaceServiceDetailCommand
        {
            get => companyMarketplaceServiceDetailCommand ?? (companyMarketplaceServiceDetailCommand = new Command(async () => await ExecuteCompanyMarketplaceServiceDetailCommand()));
        }
        private async Task ExecuteCompanyMarketplaceServiceDetailCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IMarketPlaceService service = new MarketPlaceService();
            CompanyMarketplaceServiceDetailList = await service.CompanyMarketplaceServiceDetailAsync(new Models.CompanyMarketplaceServiceDetailRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        public List<Models.CompanyMarketplaceServiceDetailResponse> companyMarketplaceServiceDetailList;
        public List<Models.CompanyMarketplaceServiceDetailResponse> CompanyMarketplaceServiceDetailList
        {
            get => companyMarketplaceServiceDetailList;
            set
            {
                companyMarketplaceServiceDetailList = value;
                OnPropertyChanged("CompanyMarketplaceServiceDetailList");
            }
        }
        #endregion
    }
}
