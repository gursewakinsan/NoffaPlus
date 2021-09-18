using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
	public interface IQueueService
	{
		Task<List<Models.OperatorQueueResponse>> GetOperatorQueueAsync(Models.OperatorQueueRequest request);
		Task<List<Models.OperatorQueueListResponse>> GetOperatorQueueWaitingListAsync(Models.OperatorQueueListRequest request);
		Task<List<Models.OperatorQueueListResponse>> GetOperatorQueueServingListAsync(Models.OperatorQueueListRequest request);
		Task<List<Models.OperatorQueueListResponse>> OperatorQueueServedListAsync(Models.OperatorQueueListRequest request);
	}
}
