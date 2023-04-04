using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
    public interface ILandloardService
    {
        Task<List<Models.ApartmentConnectRequestReceivedResponse>> ApartmentConnectRequestReceivedAsync(Models.ApartmentConnectRequestReceivedRequest request);
        Task<List<Models.ApartmentConnectRequestReceivedResponse>> ApartmentConnectRequestRejectedAsync(Models.ApartmentConnectRequestReceivedRequest request);
        Task<List<Models.GetAvailableApartmentResponse>> GetAvailableApartmentAsync(Models.GetAvailableApartmentRequest request);
        Task<string> RejectConnectApartmentRequestAsync(Models.ConnectApartmentRequest request);
        Task<string> ApproveConnectApartmentRequestAsync(Models.ConnectApartmentRequest request);
    }
}
