using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.Service
{
	public class AtendenceService : IAtendenceService
	{
		public Task<int> EmployeeAtendenceAsync(Models.EmployeeAtendenceRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.EmployeeAtendenceUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateAttendenceAsync(Models.EmployeeAtendenceRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateAttendenceUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<Models.EmployeeAtendenceResponse> CheckEmployeeTimeAsync(Models.EmployeeAtendenceRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<Models.EmployeeAtendenceResponse>(HttpWebRequest.Create(string.Format(EndPointsList.CheckEmployeeTimeUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateExitAsync(Models.UpdateExitRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateExitUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateLeaveAsync(Models.UpdateLeaveRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateLeaveUrl)), string.Empty, request.ToJson());
				return res;
			});
		}

		public Task<int> UpdateVacationInfoAsync(Models.UpdateVacationRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.UpdateVacationInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
