using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class SuportedLanguagesListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public SuportedLanguagesListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Suported Languages List Command.
        private ICommand suportedLanguagesListCommand;
        public ICommand SuportedLanguagesListCommand
        {
            get => suportedLanguagesListCommand ?? (suportedLanguagesListCommand = new Command(async () => await ExecuteSuportedLanguagesListCommand()));
        }
        private async Task ExecuteSuportedLanguagesListCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IMarketPlaceService service = new MarketPlaceService();
            SuportedLanguagesList = await service.SuportedLanguagesListAsync(new Models.SuportedLanguagesListRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Update Language Available Command.
        private ICommand updateLanguageAvailableCommand;
        public ICommand UpdateLanguageAvailableCommand
        {
            get => updateLanguageAvailableCommand ?? (updateLanguageAvailableCommand = new Command(async () => await ExecuteUpdateLanguageAvailableCommand()));
        }
        private async Task ExecuteUpdateLanguageAvailableCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IMarketPlaceService service = new MarketPlaceService();
            await service.UpdateLanguageAvailableAsync(new Models.UpdateLanguageAvailableRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId,
                LanguageId = LanguageId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        public int LanguageId { get; set; }
        public List<Models.SuportedLanguagesListResponse> suportedLanguagesList;
        public List<Models.SuportedLanguagesListResponse> SuportedLanguagesList
        {
            get => suportedLanguagesList;
            set
            {
                suportedLanguagesList = value;
                OnPropertyChanged("SuportedLanguagesList");
            }
        }
        #endregion
    }
}
