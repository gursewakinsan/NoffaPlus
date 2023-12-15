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
            var responses = await service.CompanyMarketplaceServiceDetailAsync(new Models.CompanyMarketplaceServiceDetailRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId
            });
            foreach (var category in responses)
            {
                foreach (var subcategory in category.Subcategory)
                {
                    if (!subcategory.IsSelected && !subcategory.PriceAdded)
                        subcategory.IsBlackCard = true;
                    else if (subcategory.IsSelected && !subcategory.PriceAdded)
                        subcategory.IsOrangeCard = true;
                    else if (subcategory.IsSelected && subcategory.PriceAdded)
                        subcategory.IsGreenCard = true;
                }
            }
            CompanyMarketplaceServiceDetailList = responses;
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
