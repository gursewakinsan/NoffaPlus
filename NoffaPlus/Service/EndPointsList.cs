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
	}
}
