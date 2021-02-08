using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class AppStoreInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AppStoreInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			AppStoreList = new ObservableCollection<AppStoreInfo>();
			AppStoreList.Add(new AppStoreInfo() { AppName = "Visitor" });
			AppStoreList.Add(new AppStoreInfo() { AppName = "Delivery" });
			AppStoreList.Add(new AppStoreInfo() { AppName = "SafeQid" });
			AppStoreList.Add(new AppStoreInfo() { AppName = "Food & Drink" });
			AppStoreList.Add(new AppStoreInfo() { AppName = "BusinessQard" });
			AppStoreList.Add(new AppStoreInfo() { AppName = "Website" });
		}
		#endregion

		#region Properties.
		public ObservableCollection<AppStoreInfo> AppStoreList { get; set; }
		#endregion
	}
}
public class AppStoreInfo
{
	public string AppName { get; set; }
}
