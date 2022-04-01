using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Welqome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MeetingInvitationPage : ContentPage
	{
		MeetingInvitationPageViewModel viewModel;
		public MeetingInvitationPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new MeetingInvitationPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.GetAllCountryCodeCommand.Execute(null);
		}

		private void MobileNumberTextChanged(object sender, TextChangedEventArgs args)
		{
			if (!string.IsNullOrWhiteSpace(args.NewTextValue))
			{
				bool isValid = args.NewTextValue.ToCharArray().All(char.IsDigit);
				((Controls.CustomFloatingLabelEntry)sender).Text = isValid ? args.NewTextValue : args.OldTextValue;
			}
		}

		private void OnCountryCodeIndexChanged(object sender, System.EventArgs e)
		{
			Controls.CustomPicker picker = sender as Controls.CustomPicker;
			if (picker.SelectedIndex == -1)
				return;
		}
	}
}