using Xamarin.Forms;
using NoffaPlus.Helper;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class CompanyDetailsViewModel : BaseViewModel
	{
		#region Constructor.
		public CompanyDetailsViewModel(INavigation navigation)
		{
			Navigation = navigation;
			
		}
		#endregion

		#region Admin Command.
		private ICommand adminCommand;
		public ICommand AdminCommand
		{
			get => adminCommand ?? (adminCommand = new Command(async () => await ExecuteAdminCommand()));
		}
		private async Task ExecuteAdminCommand()
		{
			await Navigation.PushAsync(new Views.AdminInfoPage());
		}
		#endregion

		#region Verify Admin Command.
		private ICommand verifyAdminCommand;
		public ICommand VerifyAdminCommand
		{
			get => verifyAdminCommand ?? (verifyAdminCommand = new Command(async () => await ExecuteVerifyAdminCommand()));
		}
		private async Task ExecuteVerifyAdminCommand()
		{
			if (CompanyDetail != null) return;
			DependencyService.Get<IProgressBar>().Show();
			Models.VerifyAdminRequest request = new Models.VerifyAdminRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			};
			ICompanyService service = new CompanyService();

			Models.DaycareResponse response = await service.DaycareRequestCountAsync(new Models.DaycareRequest()
			{
				CompanyId = Helper.Helper.CompanyId
			});

			DaycareList = new List<Daycare>();
			DaycareList.Add(new Daycare() { Id = 0, Heading = "Time", HeadingIcon = NoffaPlusAppFlatIcons.AlarmNote, SubHeading = "Stamp when you start and get off work" });
			DaycareList.Add(new Daycare() { Id = 1, Heading = "SafeQid", HeadingIcon = NoffaPlusAppFlatIcons.HumanCapacityIncrease, SubHeading = "Confirm presence of a checked-in child" });
			DaycareList.Add(new Daycare() { Id = 2, Heading = "SafeQid", HeadingIcon = NoffaPlusAppFlatIcons.HumanCapacityIncrease, SubHeading = "Confirm pick up request/s" });

			if (response.Inactive == 0)
				DaycareList.Add(new Daycare() { Id = 3, Heading = "SafeQid", HeadingIcon = NoffaPlusAppFlatIcons.HumanCapacityIncrease, SubHeading = "Register parents to children" });
			else
				DaycareList.Add(new Daycare() { Id = 3, Heading = "SafeQid", HeadingIcon = NoffaPlusAppFlatIcons.HumanCapacityIncrease, SubHeading = $"Register parents to {response.Inactive} children" });

			if (response.DunsIsApproved == 0)
				DaycareList.Add(new Daycare() { Id = 4, Heading = "DUNS number", HeadingIcon = NoffaPlusAppFlatIcons.AccountGroup, SubHeading = "Register DUNS for verification" });
			else
				DaycareList.Add(new Daycare() { Id = 4, Heading = "DUNS number", HeadingIcon = NoffaPlusAppFlatIcons.AccountGroup, SubHeading = "DUNS already verified" });
			OnPropertyChanged("DaycareList");

			CompanyDetail = await service.VerifyAdminAsync(request);
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Children Missing Command.
		private ICommand childrenMissingCommand;
		public ICommand ChildrenMissingCommand
		{
			get => childrenMissingCommand ?? (childrenMissingCommand = new Command(async () => await ExecuteChildrenMissingCommand()));
		}
		private async Task ExecuteChildrenMissingCommand()
		{
			await Navigation.PushAsync(new Views.ChildrenMissingListPage());
		}
		#endregion

		#region Attendance Command.
		private ICommand attendanceCommand;
		public ICommand AttendanceCommand
		{
			get => attendanceCommand ?? (attendanceCommand = new Command(async () => await ExecuteAttendanceCommand()));
		}
		private async Task ExecuteAttendanceCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IAtendenceService service = new AtendenceService();
			int response = await service.EmployeeAtendenceAsync(new Models.EmployeeAtendenceRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			});
			if (response == 0)
				await Navigation.PushAsync(new Views.AttendancePage());
			else if (response == 1)
				await Navigation.PushAsync(new Views.AttendanceTimerPage());
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private Models.VerifyAdminResponse companyDetail;
		public Models.VerifyAdminResponse CompanyDetail
		{
			get => companyDetail;
			set
			{
				companyDetail = value;
				OnPropertyChanged("CompanyDetail");
			}
		}

		public string DisplayCompanyName => Helper.Helper.CompanyName;

		public List<Daycare> daycareList;
		public List<Daycare> DaycareList
		{
			get => daycareList;
			set
			{
				daycareList = value;
				OnPropertyChanged("DaycareList");
			}
		}
		#endregion
	}
}

public class Daycare
{
	public int Id { get; set; }
	public string Heading { get; set; }
	public string SubHeading { get; set; }
	public string HeadingIcon { get; set; }
}