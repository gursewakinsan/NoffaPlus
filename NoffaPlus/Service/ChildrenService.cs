using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Service
{
	public class ChildrenService : IChildrenService
	{
		public Task<List<Models.Children>> GetMissingChildrenByIdAsync(int id)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<List<Models.Children>>(HttpWebRequest.Create(string.Format(EndPointsList.MissingChildrenUrl, id)));
				return res;
			});
		}

		public Task<List<Models.Children>> ReportMissingChildrenByIdAsync(int id)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<List<Models.Children>>(HttpWebRequest.Create(string.Format(EndPointsList.ReportMissingChildrenUrl, id)));
				return res;
			});
		}

		public Task<string> SubmitReportMissingChildrenAsync(List<Models.ReportMissing> reportMissings)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<string>(HttpWebRequest.Create(string.Format(EndPointsList.SubmitReportMissingChildrenUrl)), string.Empty, reportMissings.ToJson());
				return res;
			});
		}

		public Task<string> InformToEmployeesForMissingChildrenAsync(int id)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Get<string>(HttpWebRequest.Create(string.Format(EndPointsList.InformToEmployeesUrl, id)));
				return res;
			});
		}
	}
}
