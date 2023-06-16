using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
    public interface IPremiumService
    {
        Task<List<Models.EmployeeProfessionalServiceProposalsDatesResponse>> EmployeeProfessionalServiceProposalsDatesAsync(Models.EmployeeProfessionalServiceProposalsDatesRequest request);
        Task<List<Models.EmployeeProfessionalServiceProposalsResponse>> EmployeeProfessionalServiceProposalsAsync(Models.EmployeeProfessionalServiceProposalsRequest request);
        Task<Models.PropertyDetailResponse> PropertyDetailAsync(Models.PropertyDetailRequest request);
    }
}
