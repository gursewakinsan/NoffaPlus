using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
    public class PremiumService : IPremiumService
    {
        public Task<List<Models.EmployeeProfessionalServiceProposalsDatesResponse>> EmployeeProfessionalServiceProposalsDatesAsync(Models.EmployeeProfessionalServiceProposalsDatesRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.EmployeeProfessionalServiceProposalsDatesResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.EmployeeProfessionalServiceProposalsDatesUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<List<Models.EmployeeProfessionalServiceProposalsResponse>> EmployeeProfessionalServiceProposalsAsync(Models.EmployeeProfessionalServiceProposalsRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<List<Models.EmployeeProfessionalServiceProposalsResponse>>(HttpWebRequest.Create(string.Format(EndPointsList.EmployeeProfessionalServiceProposalsUrl)), string.Empty, request.ToJson());
                return res;
            });
        }

        public Task<Models.PropertyDetailResponse> PropertyDetailAsync(Models.PropertyDetailRequest request)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Post<Models.PropertyDetailResponse>(HttpWebRequest.Create(string.Format(EndPointsList.PropertyDetailUrl)), string.Empty, request.ToJson());
                return res;
            });
        }
    }
}
