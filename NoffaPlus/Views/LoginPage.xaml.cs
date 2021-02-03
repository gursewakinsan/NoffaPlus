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
			loginViewModel.IsAlreadyLoginCommand.Execute(null);
			base.OnAppearing();
		}
		private void OnTapRememberMeGestureRecognizer(object sender, EventArgs e)
		{
		}
	}
}