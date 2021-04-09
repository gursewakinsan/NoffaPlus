using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class ContactService: IContactService
	{
		public Task<List<Models.ContactResponse>> GetContactsAsync(Models.ContactRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.ContactResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.ContactListUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
