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
		Task<Models.QueueGuestDetailResponse> QueueGuestDetailAsync(Models.QueueGuestRequest request);
		Task<int> UpdateNoShowAsync(Models.QueueGuestRequest request);
		Task<int> AlertGuestAsync(Models.QueueGuestRequest request);
		Task<int> UpdateInServicingAsync(Models.UpdateInServicingRequest request);
		Task<Models.QueueServicingGuestDetailResponse> QueueServicingGuestDetailAsync(Models.QueueGuestRequest request);
	}
}

