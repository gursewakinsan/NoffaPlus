using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
	public interface IQueueService
	{
		Task<List<Models.OperatorQueueResponse>> GetOperatorQueueAsync(Models.OperatorQueueRequest request);
	}
}
