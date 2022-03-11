using System.Net;
using NoffaPlus.Helper;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.Service
{
	public class VerifyHotelStaffService : IVerifyHotelStaffService
	{
		public Task<int> VerifEmployeeInfoAsync(Models.VerifEmployeeInfoRequest request)
		{
			return Task.Factory.StartNew(() =>
			{
				var res = RestClient.Post<int>(HttpWebRequest.Create(string.Format(EndPointsList.VerifEmployeeInfoUrl)), string.Empty, request.ToJson());
				return res;
			});
		}
	}
}
