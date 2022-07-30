using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class NotStartedPageViewModel : BaseViewModel
	{
		#region Constructor.
		public NotStartedPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Not Started Command.
		private ICommand notStartedCommand;
		public ICommand NotStartedCommand
		{
			get => notStartedCommand ?? (notStartedCommand = new Command(() => ExecuteNotStartedCommand()));
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

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Properties.
		public string DisplayApartmentName => Helper.Helper.ApartmentCommunityTicketInfo.ApartmentName;
		public List<ApartmentCommunityTicketModel> NotStartedList => Helper.Helper.ApartmentCommunityTicketInfo.NotStartedList;
		public int NotStartedCount => Helper.Helper.ApartmentCommunityTicketInfo.NotStartedList?.Count ?? 0;
		public int StartedCount => Helper.Helper.ApartmentCommunityTicketInfo.StartedList?.Count ?? 0;
		public int FinishCount => Helper.Helper.ApartmentCommunityTicketInfo.FinishedList?.Count ?? 0;
		public int CancelledCount => Helper.Helper.ApartmentCommunityTicketInfo.CancelledList?.Count ?? 0;
		#endregion
	}
}
