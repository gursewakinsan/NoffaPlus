using System.Threading.Tasks;

namespace NoffaPlus.Interfaces
{
	public interface IAtendenceService
	{
		Task<int> EmployeeAtendenceAsync(Models.EmployeeAtendenceRequest request);
		Task<int> UpdateAttendenceAsync(Models.EmployeeAtendenceRequest request);
		Task<Models.EmployeeAtendenceResponse> CheckEmployeeTimeAsync(Models.EmployeeAtendenceRequest request);
		Task<int> UpdateExitAsync(Models.UpdateExitRequest request);
		Task<int> UpdateLeaveAsync(Models.UpdateLeaveRequest request);
		Task<int> UpdateVacationInfoAsync(Models.UpdateVacationRequest request);
	}
}
