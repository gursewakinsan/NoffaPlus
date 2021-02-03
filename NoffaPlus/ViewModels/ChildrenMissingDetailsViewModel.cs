using Xamarin.Forms;

namespace NoffaPlus.ViewModels
{
	public class ChildrenMissingDetailsViewModel : BaseViewModel
	{
		#region Constructor.
		public ChildrenMissingDetailsViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Properties.
		public Models.Children ChildrenDetails { get; set; }
		#endregion
	}
}
