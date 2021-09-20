using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class QueueService : IQueueService
	{
		public Task<List<Models.OperatorQueueResponse>> GetOperatorQueueAsync(Models.OperatorQueueRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.OperatorQueueResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.OperatorQueueListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.OperatorQueueListResponse>> GetOperatorQueueWaitingListAsync(Models.OperatorQueueListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.OperatorQueueListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.OperatorQueueWaitingListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.OperatorQueueListResponse>> GetOperatorQueueServingListAsync(Models.OperatorQueueListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.OperatorQueueListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.OperatorQueueServingListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.OperatorQueueListResponse>> OperatorQueueServedListAsync(Models.OperatorQueueListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.OperatorQueueListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.OperatorQueueServedListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.QueueGuestDetailResponse> QueueGuestDetailAsync(Models.QueueGuestRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.QueueGuestDetailResponse>(HttpWebRequest.Create(string.Format(EndPointsList.QueueGuestDetailUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateNoShowAsync(Models.QueueGuestRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateNoShowUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> AlertGuestAsync(Models.QueueGuestRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.AlertGuestUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateInServicingAsync(Models.UpdateInServicingRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateInServicingUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.QueueServicingGuestDetailResponse> QueueServicingGuestDetailAsync(Models.QueueGuestRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.QueueServicingGuestDetailResponse>(HttpWebRequest.Create(string.Format(EndPointsList.QueueServicingGuestDetailUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateCloseServiceAsync(Models.QueueGuestRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCloseServiceUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
