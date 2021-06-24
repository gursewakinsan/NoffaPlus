using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class ContactDetailsPageViewModel: BaseViewModel
	{
		#region Constructor.
		public ContactDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			List<MyBasicInfo> basicInfo = new List<MyBasicInfo>();
			basicInfo.Add(new MyBasicInfo() 
			{ 
				IconSource = Helper.NoffaPlusAppFlatIcons.TagTextOutline, 
				Name = "156 cm" 
			});
			basicInfo.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.WeightLifter,
				Name = "Active"
			});
			basicInfo.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.Redhat,
				Name = "Undergraduate degree"
			});
			basicInfo.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.Search,
				Name = "Don't know yet"
			});
			basicInfo.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.BabyBottleOutline,
				Name = "Want someday"
			});
			basicInfo.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.Graphql,
				Name = "Libra"
			});
			MyBasicInfoList = basicInfo;

			List<MyBasicInfo> myInterests = new List<MyBasicInfo>();
			myInterests.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.RunFast,
				Name = "Running"
			});
			myInterests.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.WeightLifter,
				Name = "Gym"
			});
			myInterests.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.Star,
				Name = "Festivals"
			});
			myInterests.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.GlassMugVariant,
				Name = "Pubs"
			});
			myInterests.Add(new MyBasicInfo()
			{
				IconSource = Helper.NoffaPlusAppFlatIcons.Leaf,
				Name = "Gardening"
			});
			MyInterestsList = myInterests;
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
		
		private List<MyBasicInfo> _myBasicInfoList;
		public List<MyBasicInfo> MyBasicInfoList
		{
			get { return _myBasicInfoList; }
			set
			{
				_myBasicInfoList = value;
				base.OnPropertyChanged();
			}
		}

		private List<MyBasicInfo> _myInterestsList;
		public List<MyBasicInfo> MyInterestsList
		{
			get { return _myInterestsList; }
			set
			{
				_myInterestsList = value;
				base.OnPropertyChanged();
			}
		}
		#endregion
	}
}

public class MyBasicInfo
{
	public string IconSource { get; set; }
	public string Name { get; set; }
}
