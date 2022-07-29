using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class StartedPageViewModel : BaseViewModel
	{
		#region Constructor.
		public StartedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			ImageTestList = new List<ImageTest>();
			ImageTestList.Add(new ImageTest() { Url = "ErrorMessageBg.png" });
			ImageTestList.Add(new ImageTest() { Url = "appIcon.png" });
			ImageTestList.Add(new ImageTest() { Url = "ErrorMessageBg.png" });
			ImageTestList.Add(new ImageTest() { Url = "appIcon.png" });
		}
		#endregion

		#region Not Started Command.
		private ICommand notStartedCommand;
		public ICommand NotStartedCommand
		{
			get => notStartedCommand ?? (notStartedCommand = new Command( () => ExecuteNotStartedCommand()));
		}
		private void ExecuteNotStartedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.NotStartedPage());
		}
		#endregion

		#region Started Command.
		private ICommand startedCommand;
		public ICommand StartedCommand
		{
			get => startedCommand ?? (startedCommand = new Command(() => ExecuteStartedCommand()));
		}
		private void ExecuteStartedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.StartedPage());
		}
		#endregion

		#region Finished Command.
		private ICommand finishedCommand;
		public ICommand FinishedCommand
		{
			get => finishedCommand ?? (finishedCommand = new Command(() => ExecuteFinishedCommand()));
		}
		private void ExecuteFinishedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.FinishPage());
		}
		#endregion

		#region Cancelled Command.
		private ICommand cancelledCommand;
		public ICommand CancelledCommand
		{
			get => cancelledCommand ?? (cancelledCommand = new Command(() => ExecuteCancelledCommand()));
		}
		private void ExecuteCancelledCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.CancelledPage());
		}
		#endregion

		#region Properties.
		private List<ImageTest> imageTestList;
		public List<ImageTest> ImageTestList
		{
			get => imageTestList;
			set
			{
				imageTestList = value;
				OnPropertyChanged("ImageTestList");
			}
		}

		public List<ApartmentCommunityTicketModel> StartedList => Helper.Helper.ApartmentCommunityTicketInfo.StartedList;
		public int NotStartedCount => Helper.Helper.ApartmentCommunityTicketInfo.NotStartedList?.Count ?? 0;
		public int StartedCount => Helper.Helper.ApartmentCommunityTicketInfo.StartedList?.Count ?? 0;
		public int FinishCount => Helper.Helper.ApartmentCommunityTicketInfo.FinishedList?.Count ?? 0;
		public int CancelledCount => Helper.Helper.ApartmentCommunityTicketInfo.CancelledList?.Count ?? 0;
		#endregion
	}
}

public class ImageTest
{
    public string Url { get; set; }
}

