using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
    public class MarketPlaceService : IMarketPlaceService
    {
        public Task<List<Models.CompanyMarketplaceListResponse>> CompanyMarketplaceListAsync(Models.CompanyMarketplaceListRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.CompanyMarketplaceListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CompanyMarketplaceListUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> ProfessionalTodoUpdateAsync(Models.ProfessionalTodoUpdateRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.ProfessionalTodoUpdateUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}
