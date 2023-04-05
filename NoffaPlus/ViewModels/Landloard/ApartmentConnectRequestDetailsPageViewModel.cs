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

        #region Toggle On/Off Command.
        private ICommand toggleOnOffCommand;
        public ICommand ToggleOnOffCommand
        {
            get => toggleOnOffCommand ?? (toggleOnOffCommand = new Command( () =>  ExecuteToggleOnOffCommand()));
        }
        private void ExecuteToggleOnOffCommand()
        {
            IsToggleOn = !IsToggleOn;
        }
        #endregion

        #region Reject Connect Apartment Request Command.
        private ICommand rejectConnectApartmentRequestCommand;
        public ICommand RejectConnectApartmentRequestCommand
        {
            get => rejectConnectApartmentRequestCommand ?? (rejectConnectApartmentRequestCommand = new Command(async () => await ExecuteRejectConnectApartmentRequestCommand()));
        }
        private async Task ExecuteRejectConnectApartmentRequestCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            ILandloardService service = new LandloardService();
            await service.RejectConnectApartmentRequestAsync(new Models.ConnectApartmentRequest()
            {
                RequestId = SelectedApartmentConnectRequest.Id,
            });
            await Navigation.PopAsync();
            DependencyService.Get<IProgressBar>().Hide();
        }
        #endregion

        #region Approve Connect Apartment Request Command.
        private ICommand approveConnectApartmentRequestCommand;
        public ICommand ApproveConnectApartmentRequestCommand
        {
            get => approveConnectApartmentRequestCommand ?? (approveConnectApartmentRequestCommand = new Command(async () => await ExecuteApproveConnectApartmentRequestCommand()));
        }
        private async Task ExecuteApproveConnectApartmentRequestCommand()
        {
            if (!IsToggleOn && string.IsNullOrWhiteSpace(ApartmentNumber))
                await Helper.Alert.DisplayAlert("Apartment number is required.");
            else
            {
                DependencyService.Get<IProgressBar>().Show();
                ILandloardService service = new LandloardService();
                await service.ApproveConnectApartmentRequestAsync(new Models.ConnectApartmentRequest()
                {
                    RequestId = SelectedApartmentConnectRequest.Id,
                    CompanyId = Helper.Helper.CompanyId,
                    ApartmentAvailable = IsToggleOn ? 1 : 0,
                    ApartmentNumber = IsToggleOn ? string.Empty : ApartmentNumber,
                    ApartmentId = IsToggleOn ? SelectedAvailableApartment.Id : 0
                });
                await Navigation.PopAsync();
                DependencyService.Get<IProgressBar>().Hide();
            }
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

        private bool isToggleOn = true;
        public bool IsToggleOn
        {
            get => isToggleOn;
            set
            {
                isToggleOn = value;
                OnPropertyChanged("IsToggleOn");
            }
        }

        private string apartmentNumber;
        public string ApartmentNumber
        {
            get => apartmentNumber;
            set
            {
                apartmentNumber = value;
                OnPropertyChanged("ApartmentNumber");
            }
        }

        private Models.ApartmentConnectRequestReceivedResponse selectedApartmentConnectRequest;
        public Models.ApartmentConnectRequestReceivedResponse SelectedApartmentConnectRequest
        {
            get => selectedApartmentConnectRequest;
            set
            {
                selectedApartmentConnectRequest = value;
                OnPropertyChanged("SelectedApartmentConnectRequest");
            }
        }
        #endregion
    }
}
