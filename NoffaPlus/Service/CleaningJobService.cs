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
	}
}
