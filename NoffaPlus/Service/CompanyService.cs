using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class CompanyService : ICompanyService
	{
		public Task<Models.VerifyAdminResponse> VerifyAdminAsync(Models.VerifyAdminRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.VerifyAdminResponse>(HttpWebRequest.Create(string.Format(EndPointsList.VerifyAdminUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<List<Models.CompanyDownloadedAppsResponse>> CompanyDownloadedAppsAsync(Models.CompanyDownloadedAppsRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<List<Models.CompanyDownloadedAppsResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CompanyDownloadedAppsUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
