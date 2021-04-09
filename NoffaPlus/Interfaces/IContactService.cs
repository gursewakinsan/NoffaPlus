using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
	public interface IContactService
	{
		Task<List<Models.ContactResponse>> GetContactsAsync(Models.ContactRequest request);
	}
}
