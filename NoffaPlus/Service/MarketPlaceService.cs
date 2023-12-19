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

        public Task<List<Models.CompanyMarketplaceServiceDetailResponse>> CompanyMarketplaceServiceDetailAsync(Models.CompanyMarketplaceServiceDetailRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.CompanyMarketplaceServiceDetailResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CompanyMarketplaceServiceDetailUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> UpdateCategoryServiceTodoAsync(Models.UpdateCategoryServiceTodoRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateCategoryServiceTodoUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.CompanyMarketplacePricingDetailResponse>> CompanyMarketplacePricingDetailAsync(Models.CompanyMarketplacePricingDetailRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.CompanyMarketplacePricingDetailResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.CompanyMarketplacePricingDetailUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> AddProfessionalCompanyServiceAsync(Models.AddProfessionalCompanyServiceRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.AddProfessionalCompanyServiceUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.WorkingHrs>> GetWorkingHrsAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.WorkingHrs>>(HttpWebRequest.Create(string.Format(EndPointsList.WorkingHrsUrl)), string.Empty);
                return res;
            });
        }

        public Task<List<Models.SelectedAreaDetailResponse>> SelectedAreaDetailAsync(Models.SelectedAreaDetailRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.SelectedAreaDetailResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SelectedAreaDetailUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> UpdateAreaAsync(Models.UpdateAreaRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateAreaUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.SuportedLanguagesListResponse>> SuportedLanguagesListAsync(Models.SuportedLanguagesListRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.SuportedLanguagesListResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.SuportedLanguagesListUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<string> UpdateLanguageAvailableAsync(Models.UpdateLanguageAvailableRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateLanguageAvailableUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}