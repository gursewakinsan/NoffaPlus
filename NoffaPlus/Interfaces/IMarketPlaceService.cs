using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
    public interface IMarketPlaceService
    {
        Task<List<Models.CompanyMarketplaceListResponse>> CompanyMarketplaceListAsync(Models.CompanyMarketplaceListRequest request);
        Task<string> ProfessionalTodoUpdateAsync(Models.ProfessionalTodoUpdateRequest request);
        Task<List<Models.CompanyMarketplaceServiceDetailResponse>> CompanyMarketplaceServiceDetailAsync(Models.CompanyMarketplaceServiceDetailRequest request);
        Task<string> UpdateCategoryServiceTodoAsync(Models.UpdateCategoryServiceTodoRequest request);
        Task<List<Models.CompanyMarketplacePricingDetailResponse>> CompanyMarketplacePricingDetailAsync(Models.CompanyMarketplacePricingDetailRequest request);
        Task<string> AddProfessionalCompanyServiceAsync(Models.AddProfessionalCompanyServiceRequest request);
        Task<List<Models.WorkingHrs>> GetWorkingHrsAsync();
    }
}
