using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using NoffaPlus.Controls;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactListPage : ContentPage
	{
		ContactListPageViewModel ViewModel;
		public ContactListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = ViewModel = new ContactListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModel.GetContactsCommand.Execute(null);
		}

		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			iconClearText.IsVisible = string.IsNullOrEmpty(txtSearch.Text) ? false : true;
			ViewModel.SearchContactsCommand.Execute(txtSearch.Text);
		}

		private void OnClearTextClicked(object sender, System.EventArgs e)
		{
			txtSearch.Text = string.Empty;
			iconClearText.IsVisible = false;
			ViewModel.SearchContactsCommand.Execute(txtSearch.Text);
		}
	}
}