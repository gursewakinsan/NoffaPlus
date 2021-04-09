using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

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

		private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
		{
			SearchBar searchBar = sender as SearchBar;
			ViewModel.SearchContactsCommand.Execute(searchBar.Text);
		}
	}
}