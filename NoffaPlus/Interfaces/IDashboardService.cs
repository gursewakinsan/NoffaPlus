using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoffaPlus.Interfaces
{
	public interface IDashboardService
	{
		Task<List<Models.Company>> GetCompaniesByIdAsync(int id);
	}
}
