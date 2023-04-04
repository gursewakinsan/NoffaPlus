using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
    public class LandloardService : ILandloardService
    {
        public Task<List<Models.ApartmentConnectRequestReceivedResponse>> ApartmentConnectRequestReceivedAsync(Models.ApartmentConnectRequestReceivedRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.ApartmentConnectRequestReceivedResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentConnectRequestReceivedUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.ApartmentConnectRequestReceivedResponse>> ApartmentConnectRequestRejectedAsync(Models.ApartmentConnectRequestReceivedRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.ApartmentConnectRequestReceivedResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentConnectRequestRejectedUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.GetAvailableApartmentResponse>> GetAvailableApartmentAsync(Models.GetAvailableApartmentRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.GetAvailableApartmentResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.GetAvailableApartmentUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> RejectConnectApartmentRequestAsync(Models.ConnectApartmentRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.RejectConnectApartmentRequestUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> ApproveConnectApartmentRequestAsync(Models.ConnectApartmentRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.ApproveConnectApartmentRequestUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}
