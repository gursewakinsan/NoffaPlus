using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class ResturantService : IResturantService
	{
		public Task<List<Models.AvailableResturantResponse>> AvailableResturantListAsync(Models.AvailableResturantRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.AvailableResturantResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.AvailableResturantListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.ResturantServeBasedMenuResponse>> ResturantServeBasedMenuAsync(Models.ResturantServeBasedMenuRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ResturantServeBasedMenuResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ResturantServeBasedMenuUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> UpdateDishStockAsync(Models.UpdateDishStockRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateDishStockUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> DeleteDishItemAsync(Models.DeleteDishItemRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.DeleteDishItemUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> IsHotelAsync(Models.HotelBookingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.IsHotelUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelBookingListForFrontDeskCheckinResponse>> HotelBookingListForFrontDeskCheckinAsync(Models.HotelBookingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingListForFrontDeskCheckinResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingListForFrontDeskCheckinUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelBookingListForFrontDeskKeyHandlingResponse>> HotelBookingListForFrontDeskKeyHandlingAsync(Models.HotelBookingListForFrontDeskKeyHandlingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingListForFrontDeskKeyHandlingResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingListForFrontDeskKeyHandlingUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelBookingListForFrontDeskKeyHandlingResponse>> HotelBookingListForFrontDeskReceivedKeyAsync(Models.HotelBookingListForFrontDeskKeyHandlingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingListForFrontDeskKeyHandlingResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingListForFrontDeskReceivedKeyUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> HandOverKeyAsync(Models.HandoverKeyRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.HandoverKeyUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelBookingListForFrontDeskCheckoutResponse>> HotelBookingListForFrontDeskCheckoutAsync(Models.HotelBookingListForFrontDeskKeyHandlingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingListForFrontDeskCheckoutResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingListForFrontDeskCheckoutUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> CheckOutGuestAsync(Models.HandoverKeyRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.CheckOutGuestUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}