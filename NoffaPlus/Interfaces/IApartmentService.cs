using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
    public interface IApartmentService
    {
        Task<Models.ApartmentCommunityTicketListResponse> ApartmentCommunityTicketListAsync(Models.ApartmentCommunityTicketListRequest request);
    }
}
