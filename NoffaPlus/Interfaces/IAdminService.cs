using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
	public interface IAdminService
	{
		Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync();
		Task<int> InviteVisitorAsync(Models.InviteVisitorRequest request);
	}
}
