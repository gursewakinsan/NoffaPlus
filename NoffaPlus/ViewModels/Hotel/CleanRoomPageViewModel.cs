using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class CleanRoomPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleanRoomPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
	}
}
