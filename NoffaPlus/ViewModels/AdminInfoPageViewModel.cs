using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class AdminInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AdminInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			AdminInfoList = new ObservableCollection<AdminInfo>();
			AdminInfoList.Add(new AdminInfo() { InfoName = "Company details" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Resources" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Products & Services" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "App store" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Developers" });
		}
		#endregion

		#region Properties.
		public ObservableCollection<AdminInfo> AdminInfoList { get; set; }
		#endregion
	}
}
public class AdminInfo
{
	public string InfoName { get; set; }
}
