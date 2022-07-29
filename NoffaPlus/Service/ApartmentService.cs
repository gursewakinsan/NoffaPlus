using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
    public class ApartmentService : IApartmentService
    {
		public Task<Models.ApartmentCommunityTicketListResponse> ApartmentCommunityTicketListAsync(Models.ApartmentCommunityTicketListRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.ApartmentCommunityTicketListResponse>(HttpWebRequest.Create(string.Format(EndPointsList.ApartmentCommunityTicketListUrl)), string.Empty, null);
				return res;
			});
		}
	}
}
