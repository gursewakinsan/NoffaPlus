using Xamarin.Forms;
using NoffaPlus.Helper;
using System.Windows.Input;
using System.Threading.Tasks;
using NoffaPlus.Interfaces;
using NoffaPlus.Service;
using System;

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

		#region Properties.
		public string Username { get; set; } //= "qloudsuperagent1@qloudid.com";
		public string Password { get; set; } //= "av#ng3rs";
		#endregion
	}
}
