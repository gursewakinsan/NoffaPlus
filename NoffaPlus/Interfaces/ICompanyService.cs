using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
	public interface ICompanyService
	{
		Task<Models.VerifyAdminResponse> VerifyAdminAsync(Models.VerifyAdminRequest request);
		Task<List<Models.CompanyDownloadedAppsResponse>> CompanyDownloadedAppsAsync(Models.CompanyDownloadedAppsRequest request);
	}
}
