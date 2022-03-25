using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class HotelService : IHotelService
	{
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

		public Task<List<Models.HotelBookingListForCleningStaffResponse>> HotelBookingListForCleningStaffAsync(Models.HotelBookingListForCleningStaffRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingListForCleningStaffResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingListForCleningStaffUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AllocateRoomForCleaningAsync(Models.AllocateRoomForCleaningRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AllocateRoomForCleaningUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateRoomCleaningAsync(Models.UpdateRoomCleaningRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateRoomCleaningUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelCheckedOutListForCleningStaffResponse>> HotelCheckedOutListForCleningStaffAsync(Models.HotelCheckedOutListForCleningStaffRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelCheckedOutListForCleningStaffResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelCheckedOutListForCleningStaffUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AllocateCheckedOutRoomForCleaningAsync(Models.AllocateCheckedOutRoomForCleaningRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AllocateCheckedOutRoomForCleaningUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCheckedOutRoomCleaningAsync(Models.UpdateCheckedOutRoomCleaningRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCheckedOutRoomCleaningUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		//Inspect
		public Task<List<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse>> HotelCheckedOutListForHousekeepingIncepectionStaffAsync(Models.HotelCheckedOutListForHousekeepingIncepectionStaffRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelCheckedOutListForHousekeepingIncepectionStaffUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AllocateCheckedOutRoomForInspectionAsync(Models.AllocateCheckedOutRoomForInspectionRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AllocateCheckedOutRoomForInspectionUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCheckedOutRoomInspectionAsync(Models.UpdateCheckedOutRoomInspectionRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCheckedOutRoomInspectionUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}



