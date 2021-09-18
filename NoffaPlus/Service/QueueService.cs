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
	}
}
