using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class AdminService : IAdminService
	{
		public Task<List<Models.CountryCodeListResponse>> CountryCodeListAsync()
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CountryCodeListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CountryCodeUrl)), string.Empty, null);
				return res;
			});
		}

		public Task<int> InviteVisitorAsync(Models.InviteVisitorRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.InviteVisitorUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
