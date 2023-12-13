using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
    public interface IMarketPlaceService
    {
        Task<List<Models.CompanyMarketplaceListResponse>> CompanyMarketplaceListAsync(Models.CompanyMarketplaceListRequest request);
        Task<string> ProfessionalTodoUpdateAsync(Models.ProfessionalTodoUpdateRequest request);
    }
}
