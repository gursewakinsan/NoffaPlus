using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.Interfaces
{
	public interface IResturantService
	{
		Task<List<Models.AvailableResturantResponse>> AvailableResturantListAsync(Models.AvailableResturantRequest request);
		Task<List<Models.ResturantServeBasedMenuResponse>> ResturantServeBasedMenuAsync(Models.ResturantServeBasedMenuRequest request);
		Task<string> UpdateDishStockAsync(Models.UpdateDishStockRequest request);
		Task<string> DeleteDishItemAsync(Models.DeleteDishItemRequest request);
		Task<int> IsHotelAsync(Models.HotelBookingRequest request);
		Task<List<Models.HotelBookingListForFrontDeskCheckinResponse>> HotelBookingListForFrontDeskCheckinAsync(Models.HotelBookingRequest request);
	}
}
