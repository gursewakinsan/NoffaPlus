using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
    public class CleaningJobService : ICleaningJobService
    {
		public Task<List<Models.TeamLeaderCleaningJobsResponse>> TeamLeaderCleaningJobsAsync(Models.TeamLeaderCleaningJobsRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.TeamLeaderCleaningJobsResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.TeamLeaderCleaningJobsUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CleaningServiceAvailableTodoDetailResponse>> CleaningServiceAvailableTodoDetailAsync(Models.CleaningServiceAvailableTodoDetailRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CleaningServiceAvailableTodoDetailResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CleaningServiceAvailableTodoDetailUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CleanersAssignedListResponse>> CleanersAssignedListAsync(Models.CleanersAssignedListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CleanersAssignedListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CleanersAssignedListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> StartCleaningJobAsync(Models.StartCleaningJobRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.StartCleaningJobUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<string> UpdateCleaningJobDoneAsync(Models.UpdateCleaningJobDoneRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCleaningJobDoneUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
