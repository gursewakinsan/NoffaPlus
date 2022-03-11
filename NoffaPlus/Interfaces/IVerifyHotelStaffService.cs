using System.Threading.Tasks;

namespace NoffaPlus.Interfaces
{
	public interface IVerifyHotelStaffService
	{
		Task<int> VerifEmployeeInfoAsync(Models.VerifEmployeeInfoRequest request);
	}
}
