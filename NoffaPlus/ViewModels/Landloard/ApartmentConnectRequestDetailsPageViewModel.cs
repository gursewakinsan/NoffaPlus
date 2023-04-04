using Xamarin.Forms;
using NoffaPlus.Views;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class ApartmentConnectRequestDetailsPageViewModel : BaseViewModel
    {
        #region Constructor.
        public ApartmentConnectRequestDetailsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Get Available Apartment Command.
        private ICommand getAvailableApartmentCommand;
        public ICommand GetAvailableApartmentCommand
        {
            get => getAvailableApartmentCommand ?? (getAvailableApartmentCommand = new Command(async () => await ExecuteGetAvailableApartmentCommand()));
        }
        private async Task ExecuteGetAvailableApartmentCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            ILandloardService service = new LandloardService();
            AvailableApartmentInfo = await service.GetAvailableApartmentAsync(new Models.GetAvailableApartmentRequest()
            {
                RequestId = SelectedApartmentConnectRequest.Id
            });
            SelectedAvailableApartment = AvailableApartmentInfo[0];
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Properties.
        private List<Models.GetAvailableApartmentResponse> availableApartmentInfo;
        public List<Models.GetAvailableApartmentResponse> AvailableApartmentInfo
        {
            get => availableApartmentInfo;
            set
            {
                availableApartmentInfo = value;
                OnPropertyChanged("AvailableApartmentInfo");
            }
        }

        private Models.GetAvailableApartmentResponse selectedAvailableApartment;
        public Models.GetAvailableApartmentResponse SelectedAvailableApartment
        {
            get => selectedAvailableApartment;
            set
            {
                selectedAvailableApartment = value;
                OnPropertyChanged("SelectedAvailableApartment");
            }
        }

        public Models.ApartmentConnectRequestReceivedResponse SelectedApartmentConnectRequest { get; set; }
        #endregion
    }
}
