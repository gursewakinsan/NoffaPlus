using System;
using Xamarin.Forms;
using NoffaPlus.Helper;
using NoffaPlus.Service;
using Xamarin.Essentials;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		#region Constructor.
		public LoginViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Is Already Login Command.
		private ICommand isAlreadyLoginCommand;
		public ICommand IsAlreadyLoginCommand
		{
			get => isAlreadyLoginCommand ?? (isAlreadyLoginCommand = new Command(async () => await ExecuteIsAlreadyLoginCommand()));
		}
		private async Task ExecuteIsAlreadyLoginCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			if (Application.Current.Properties.ContainsKey("UserId"))
			{
				Helper.Helper.LoggedInUserId = Convert.ToInt32(Application.Current.Properties["UserId"]);
				Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Login Command.
		private ICommand loginCommand;
		public ICommand LoginCommand
		{
			get => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
		}
		private async Task ExecuteLoginCommand()
		{
			if (string.IsNullOrWhiteSpace(Username))
				await Alert.DisplayAlert("Username is required");
			else if (string.IsNullOrWhiteSpace(Password))
				await Alert.DisplayAlert("Password is required");
			else
			{
				DependencyService.Get<IProgressBar>().Show();
				Models.LoginRequest model = new Models.LoginRequest()
				{
					Username = Username,
					Password = Password
				};
				ILoginService service = new LoginService();
				var response = await service.LoginAsync(model);
				if (response.Id > 0)
				{
					Helper.Helper.LoggedInUserId = response.Id;
					if (Application.Current.Properties.ContainsKey("UserId"))
						Application.Current.Properties.Remove("UserId");
					Application.Current.Properties.Add("UserId", response.Id);
					await Application.Current.SavePropertiesAsync();
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
				}
				else
					await Alert.DisplayAlert("Invalid Username or Password.");
				DependencyService.Get<IProgressBar>().Hide();
			}
		}
		#endregion

		#region Login With Session Command.
		private ICommand loginWithSessionCommand;
		public ICommand LoginWithSessionCommand
		{
			get => loginWithSessionCommand ?? (loginWithSessionCommand = new Command(async () => await ExecuteLoginWithSessionCommand()));
		}
		private async Task ExecuteLoginWithSessionCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ILoginService service = new LoginService();
			Models.InterAppSessionResponse response = await service.LoginWithSessionAsync(new Models.InterAppSessionRequest() 
			{ 
				Session = Helper.Helper.SessionId 
			});
			if (response == null)
				await Alert.DisplayAlert("Something went wrong, Please try after some time.");
			else if (response.Result == 0)
				await Alert.DisplayAlert("You have enter wrong password, Please try again.");
			else if (response.Result == 1)
			{
				Helper.Helper.LoggedInUserId = response.UserId;
				IDashboardService dashboardService = new DashboardService();
				var companies = await dashboardService.GetCompaniesByIdAsync(Helper.Helper.LoggedInUserId);
				if (companies == null)
					Application.Current.MainPage = new NavigationPage(new Views.NoCompanyPage());
				else if (companies.Count == 0)
					Application.Current.MainPage = new NavigationPage(new Views.NoCompanyPage());
				else if (companies.Count == 1)
				{
					Helper.Helper.CompanyId = companies[0].CompanyId;
					Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
				}
				else if (companies.Count > 1)
					Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
			}
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Login With QloudId App Command.
		private ICommand loginWithQloudIdAppCommand;
		public ICommand LoginWithQloudIdAppCommand
		{
			get => loginWithQloudIdAppCommand ?? (loginWithQloudIdAppCommand = new Command(async () => await ExecuteLoginWithQloudIdAppCommand()));
		}
		private async Task ExecuteLoginWithQloudIdAppCommand()
		{
			if (Device.RuntimePlatform == Device.iOS)
			{
				//var supportsUri = await Launcher.CanOpenAsync("QloudidUrl://");
				//if (supportsUri)
					await Launcher.OpenAsync("QloudidUrl://NoffaPlusApp");
				//else
					//await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
			}
			else
			{
				var supportsUri = await Launcher.CanOpenAsync("https://qloudid.com/ip/");
				if (supportsUri)
					await Launcher.OpenAsync("https://qloudid.com/ip/");
				else
					await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
			}
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public string Username { get; set; } //= "qloudsuperagent2@qualeefy.com"; //= "qloudsuperagent1@qloudid.com";
		public string Password { get; set; } //= "av#ng3rs";
		#endregion
	}
}
