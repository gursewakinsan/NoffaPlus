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
		public const string GetAvailableRoomsUrl = "https://www.qloudid.com/user/index.php/QloudidApp/getAvailableRooms";

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
		public const string HotelCheckedOutListForCleningStaffUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelCheckedOutListForCleningStaff";
		public const string AllocateCheckedOutRoomForCleaningUrl = "https://www.qloudid.com/user/index.php/QloudidApp/allocateCheckedOutRoomForCleaning";
		public const string UpdateCheckedOutRoomCleaningUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateCheckedOutRoomCleaning";

		//Inspect
		public const string HotelCheckedOutListForHousekeepingIncepectionStaffUrl = "https://www.qloudid.com/user/index.php/QloudidApp/hotelCheckedOutListForHousekeepingIncepectionStaff";
		public const string AllocateCheckedOutRoomForInspectionUrl = "https://www.qloudid.com/user/index.php/QloudidApp/allocateCheckedOutRoomForInspection";
		public const string UpdateCheckedOutRoomInspectionUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateCheckedOutRoomInspection";

		//Admin
		public const string CountryCodeUrl = "https://www.qloudid.com/user/index.php/QloudidApp/countryCode";
		public const string InviteVisitorUrl = "https://www.qloudid.com/user/index.php/QloudidApp/inviteVisitor";

		//Apartment.
		public const string ApartmentCommunityTicketListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/apartmentCommunityTicketList";
		public const string UpdateApartmentCommunityTicketUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateApartmentCommunityTicket";
		public const string ApartmentCommunityTicketDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/apartmentCommunityTicketDetail";

		//Cleaning Jobs
		public const string TeamLeaderCleaningJobsUrl = "https://www.qloudid.com/user/index.php/QloudidApp/teamLeaderCleaningJobs";
		public const string CleaningServiceAvailableTodoDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/cleaningServiceAvailableTodoDetail";
		public const string CleanersAssignedListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/cleanersAssignedList";
		public const string StartCleaningJobUrl = "https://www.qloudid.com/user/index.php/QloudidApp/startCleaningJob";
		public const string UpdateCleaningJobDoneUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateCleaningJobDone";
		public const string CleaningJobStatusInfoUrl = "https://www.qloudid.com/user/index.php/QloudidApp/cleaningJobStatusInfo";
		public const string UpdateCleaningFinalStatusUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateCleaningFinalStatus";

		//Landloard
		public const string ApartmentConnectRequestReceivedUrl = "https://www.qloudid.com/user/index.php/QloudidApp/apartmentConnectRequestReceived";
		public const string ApartmentConnectRequestRejectedUrl = "https://www.qloudid.com/user/index.php/QloudidApp/apartmentConnectRequestRejected";
		public const string GetAvailableApartmentUrl = "https://www.qloudid.com/user/index.php/QloudidApp/getAvailableApartment";
		public const string RejectConnectApartmentRequestUrl = "https://www.qloudid.com/user/index.php/QloudidApp/rejectConnectApartmentRequest";
		public const string ApproveConnectApartmentRequestUrl = "https://www.qloudid.com/user/index.php/QloudidApp/approveConnectApartmentRequest";

        //Premium Services.
        public const string EmployeeProfessionalServiceProposalsDatesUrl = "https://www.qloudid.com/user/index.php/QloudidApp/employeeProfessionalServiceProposalsDates";
		public const string EmployeeProfessionalServiceProposalsUrl = "https://www.qloudid.com/user/index.php/QloudidApp/employeeProfessionalServiceProposals";
		public const string PropertyDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/propertyDetail";
		public const string UpdateProfessionalJobStatusUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateProfessionalJobStatus";

        //Market Place
        public const string CompanyMarketplaceListUrl = "https://www.qloudid.com/user/index.php/QloudidApp/companyMarketplaceList";
		public const string ProfessionalTodoUpdateUrl = "https://www.qloudid.com/user/index.php/QloudidApp/professionalTodoUpdate";
		public const string CompanyMarketplaceServiceDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/companyMarketplaceServiceDetail";
		public const string UpdateCategoryServiceTodoUrl = "https://www.qloudid.com/user/index.php/QloudidApp/updateCategoryServiceTodo";
		public const string CompanyMarketplacePricingDetailUrl = "https://www.qloudid.com/user/index.php/QloudidApp/companyMarketplacePricingDetail";
		public const string AddProfessionalCompanyServiceUrl = "https://www.qloudid.com/user/index.php/QloudidApp/addProfessionalCompanyService";
    }
}
