using Xamarin.Forms;

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

		#region Properties.
		public Models.ContactResponse ContactDetails => Helper.Helper.SelectedContact;
		#endregion
	}
}
