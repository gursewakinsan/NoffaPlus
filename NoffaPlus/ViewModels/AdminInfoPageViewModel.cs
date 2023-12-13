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
			AdminInfoList.Add(new AdminInfo() { InfoName = "Company details", InfoNameDetail = "Basic company profile details" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Offices", InfoNameDetail="Your locations in the country" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Resources", InfoNameDetail = "Your employees & customers" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Products", InfoNameDetail = "Products you are selling" });
			AdminInfoList.Add(new AdminInfo() { InfoName = "Appstore", InfoNameDetail = "This is where you can find apps" });
            AdminInfoList.Add(new AdminInfo() { InfoName = "Market place", InfoNameDetail = "Your approved market places" });
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
    public string InfoNameDetail { get; set; }
}
