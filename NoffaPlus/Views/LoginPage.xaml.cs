using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		LoginViewModel loginViewModel;
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = loginViewModel = new LoginViewModel(this.Navigation);
		}
		protected override void OnAppearing()
		{
			if (!string.IsNullOrWhiteSpace(Helper.Helper.SessionId))
				loginViewModel.LoginWithSessionCommand.Execute(null);
			//else
				//loginViewModel.IsAlreadyLoginCommand.Execute(null);
			base.OnAppearing();
		}
		private void OnTapRememberMeGestureRecognizer(object sender, EventArgs e)
		{
		}
	}
}