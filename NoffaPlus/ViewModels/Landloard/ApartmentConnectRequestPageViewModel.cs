using Xamarin.Forms;
using NoffaPlus.Views;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class ApartmentConnectRequestPageViewModel : BaseViewModel
    {
        #region Constructor.
        public ApartmentConnectRequestPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Selected Tab Command.
        private ICommand selectedTabCommand;
        public ICommand SelectedTabCommand
        {
            get => selectedTabCommand ?? (selectedTabCommand = new Command<string>((selectedTab) => ExecuteSelectedTabCommand(selectedTab)));
        }
        private void ExecuteSelectedTabCommand(string selectedTab)
        {
            switch (selectedTab)
            {
                case "Received":
                    IsReceivedTabSelected = true;
                    ApartmentConnectRequestReceivedCommand.Execute(null);
                    break;
                case "Bin":
                    IsReceivedTabSelected = false;
                    ApartmentConnectRequestRejectedCommand.Execute(null);
                    break;
            }
        }
        #endregion

        #region Apartment Connect Request Received Command.
        private ICommand apartmentConnectRequestReceivedCommand;
        public ICommand ApartmentConnectRequestReceivedCommand
        {
            get => apartmentConnectRequestReceivedCommand ?? (apartmentConnectRequestReceivedCommand = new Command(async () => await ExecuteApartmentConnectRequestReceivedCommand()));
        }
        private async Task ExecuteApartmentConnectRequestReceivedCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            ILandloardService service = new LandloardService();
            ReceivedConnectRequestInfo = await service.ApartmentConnectRequestReceivedAsync(new Models.ApartmentConnectRequestReceivedRequest()
            {
                CompanyId = Helper.Helper.CompanyId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Apartment Connect Request Rejected Command.
        private ICommand apartmentConnectRequestRejectedCommand;
        public ICommand ApartmentConnectRequestRejectedCommand
        {
            get => apartmentConnectRequestRejectedCommand ?? (apartmentConnectRequestRejectedCommand = new Command(async () => await ExecuteApartmentConnectRequestRejectedCommand()));
        }
        private async Task ExecuteApartmentConnectRequestRejectedCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            ILandloardService service = new LandloardService();
            RejectedConnectRequestInfo = await service.ApartmentConnectRequestRejectedAsync(new Models.ApartmentConnectRequestReceivedRequest()
            {
                CompanyId = Helper.Helper.CompanyId
            });
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.ApartmentConnectRequestReceivedResponse> rejectedConnectRequestInfo;
        public List<Models.ApartmentConnectRequestReceivedResponse> RejectedConnectRequestInfo
        {
            get => rejectedConnectRequestInfo;
            set
            {
                rejectedConnectRequestInfo = value;
                OnPropertyChanged("RejectedConnectRequestInfo");
            }
        }

        private List<Models.ApartmentConnectRequestReceivedResponse> receivedConnectRequestInfo;
        public List<Models.ApartmentConnectRequestReceivedResponse> ReceivedConnectRequestInfo
        {
            get => receivedConnectRequestInfo;
            set
            {
                receivedConnectRequestInfo = value;
                OnPropertyChanged("ReceivedConnectRequestInfo");
            }
        }

        public bool isReceivedTabSelected;
        public bool IsReceivedTabSelected
        {
            get => isReceivedTabSelected;
            set
            {
                isReceivedTabSelected = value;
                if (isReceivedTabSelected)
                {
                    ReceivedSelectedTab = true;
                    BinSelectedTab = false;
                }
                else
                {
                    ReceivedSelectedTab = false;
                    BinSelectedTab = true;
                }
                OnPropertyChanged("IsReceivedTabSelected");
            }
        }

        public bool receivedSelectedTab;
        public bool ReceivedSelectedTab
        {
            get => receivedSelectedTab;
            set
            {
                receivedSelectedTab = value;
                OnPropertyChanged("ReceivedSelectedTab");
            }
        }

        public bool binSelectedTab;
        public bool BinSelectedTab
        {
            get => binSelectedTab;
            set
            {
                binSelectedTab = value;
                OnPropertyChanged("BinSelectedTab");
            }
        }
        #endregion
    }
}
