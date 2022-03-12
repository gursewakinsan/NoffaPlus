using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class VerifyHotelStaffService : IVerifyHotelStaffService
	{
		public Task<int> VerifEmployeeInfoAsync(Models.VerifEmployeeInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.VerifEmployeeInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelBookingListForKeyGenerationResponse>> HotelBookingListForKeyGenerationAsync(Models.HotelBookingListForKeyGenerationRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingListForKeyGenerationResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingListForKeyGenerationUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.HotelBookingInstaBoxListForKeyGenerationResponse>> HotelBookingInstaBoxListForKeyGenerationAsync(Models.HotelBookingInstaBoxListForKeyGenerationRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.HotelBookingInstaBoxListForKeyGenerationResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.HotelBookingInstaBoxListForKeyGenerationUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> GenerateKeyForInstaBoxAsync(Models.GenerateKeyForInstaBoxRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.GenerateKeyForInstaBoxUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> ReleaseHotelInstaboxAsync(Models.HotelBookingInstaBoxListForKeyGenerationRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.ReleaseHotelInstaboxUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
