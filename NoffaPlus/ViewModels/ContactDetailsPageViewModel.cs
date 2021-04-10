using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class ContactDetailsPageViewModel: BaseViewModel
	{
		#region Constructor.
		public ContactDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
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

		#region Properties.
		public Models.ContactResponse ContactDetails => Helper.Helper.SelectedContact;
		#endregion
	}
}
