using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
    public interface ICleaningJobService
    {
        Task<List<Models.TeamLeaderCleaningJobsResponse>> TeamLeaderCleaningJobsAsync(Models.TeamLeaderCleaningJobsRequest request);
        Task<List<Models.CleaningServiceAvailableTodoDetailResponse>> CleaningServiceAvailableTodoDetailAsync(Models.CleaningServiceAvailableTodoDetailRequest request);
        Task<List<Models.CleanersAssignedListResponse>> CleanersAssignedListAsync(Models.CleanersAssignedListRequest request);
        Task<string> StartCleaningJobAsync(Models.StartCleaningJobRequest request);
        Task<string> UpdateCleaningJobDoneAsync(Models.UpdateCleaningJobDoneRequest request);
    }
}
