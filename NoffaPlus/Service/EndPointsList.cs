namespace NoffaPlus.Service
{
	public class EndPointsList
	{
		public const string LoginUrl = "https://www.qloudid.com/user/index.php/LoginAccount/loginApi";
		public const string CompaniesListUrl = "https://www.qloudid.com/user/index.php/Arbetsplats/companiesList/{0}";
		public const string MissingChildrenUrl = "https://www.qloudid.com/company/index.php/NoffaAlarm/listMissingMobileApiChildren/{0}";
		public const string ReportMissingChildrenUrl = "https://www.qloudid.com/company/index.php/NoffaAlarm/listMobileApiChildren/{0}";
		public const string SubmitReportMissingChildrenUrl = "https://www.qloudid.com/company/index.php/NoffaAlarm/updateChildInfoMobileApi";
		public const string InformToEmployeesUrl = "https://www.qloudid.com/company/index.php/NoffaAlarm/informEmployeesApi/{0}";
		public const string VerifyInterAppSessionUrl = "https://www.qloudid.com/user/index.php/QloudidApp/verifyInterAppSession";
		public const string VerifyAdminUrl = "https://www.qloudid.com/user/index.php/QloudidApp/verifyAdmin";
		public const string CompanyDownloadedAppsUrl = "https://www.qloudid.com/user/index.php/QloudidApp/companyDownloadedApps";
		public const string ContactListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/contactList";
		public const string EmployeeAtendenceUrl = "https://www.qloudid.com/user/index.php/QloudidApp/employeeAtendence";
		public const string UpdateAttendenceUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateAttendence";
		public const string CheckEmployeeTimeUrl = "https://www.qloudid.com/user/index.php/QloudidApp/checkEmployeeTime";
		public const string UpdateExitUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateExit";
		public const string UpdateLeaveUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateLeave";
		public const string UpdateVacationInfoUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateVacationInfo";
		public const string DaycareRequestCountUrl = "https://www.qloudid.com/user/index.php/QloudidApp/daycareRequestCount";

		//Queue
		public const string OperatorQueueListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/operatorQueueList";
		public const string OperatorQueueWaitingListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/operatorQueueWaitingList";
		public const string OperatorQueueServingListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/operatorQueueServingList";
		public const string OperatorQueueServedListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/operatorQueueServedList";
		public const string QueueGuestDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/queueGuestDetail";
		public const string UpdateNoShowUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateNoShow";
		public const string AlertGuestUrl = "https://www.qloudid.com/user/index.php/QloudidApp/alertGuest";
		public const string UpdateInServicingUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateInServicing";
		public const string QueueServicingGuestDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/queueServicingGuestDetail";
		public const string UpdateCloseServiceUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateCloseService";
		public const string OperatorQueueWaitingCountUrl = "https://www.qloudid.com/user/index.php/QloudidApp/operatorQueueWaitingCount";

		//Resturant
		public const string AvailableResturantListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/availableResturantList";
		public const string ResturantServeBasedMenuUrl = "https://www.qloudid.com/user/index.php/QloudidApp/ResturantServeBasedMenu";
		public const string UpdateDishStockUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateDishStock";
		public const string DeleteDishItemUrl = "https://www.qloudid.com/user/index.php/QloudidApp/deleteDishItem";

		//Verify Hotel Staff
		public const string VerifEmployeeInfoUrl = "https://www.qloudid.com/user/index.php/QloudidApp/verifEmployeeInfo";
		public const string HotelBookingListForKeyGenerationUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingListForKeyGeneration";
		public const string HotelBookingInstaBoxListForKeyGenerationUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingInstaBoxListForKeyGeneration";
		public const string GenerateKeyForInstaBoxUrl = "https://www.qloudid.com/user/index.php/QloudidApp/generateKeyForInstaBox";
		public const string ReleaseHotelInstaboxUrl = "https://www.qloudid.com/user/index.php/QloudidApp/releaseHotelInstabox";

		//Hotel
		public const string IsHotelUrl = "https://www.qloudid.com/user/index.php/QloudidApp/isHotel";
		public const string HotelBookingListForFrontDeskCheckinUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingListForFrontDeskCheckin";
		public const string HotelBookingListForFrontDeskKeyHandlingUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingListForFrontDeskKeyhandling";
		public const string HandoverKeyUrl = "https://www.qloudid.com/user/index.php/QloudidApp/handoverKey";
		public const string HotelBookingListForFrontDeskReceivedKeyUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingListForFrontDeskReceivedKey";
		public const string HotelBookingListForFrontDeskCheckoutUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingListForFrontDeskCheckout";
		public const string CheckOutGuestUrl = "https://www.qloudid.com/user/index.php/QloudidApp/checkOutGuest";
		public const string HotelBookingListForCleningStaffUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelBookingListForCleningStaff";
		public const string AllocateRoomForCleaningUrl = "https://www.qloudid.com/user/index.php/QloudidApp/allocateRoomForCleaning";
		public const string UpdateRoomCleaningUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateRoomCleaning";
	}
}
