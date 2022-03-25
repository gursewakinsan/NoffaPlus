using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectRoomPage : ContentPage
	{
		InspectRoomPageViewModel viewModel;
		public InspectRoomPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InspectRoomPageViewModel(this.Navigation);
		}

		#region On Appearing
		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.IncepectionStaffCommand.Execute(null);
		}
		#endregion

		#region On Inspect Room Item Tapped
		private void OnInspectRoomItemTapped(object sender, ItemTappedEventArgs e)
		{
			Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse incepectionStaff = e.Item as Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse;
			listInspectRoom.SelectedItem = null;
			viewModel.SelectedIncepectionStaff = incepectionStaff;
			if (!incepectionStaff.InspectionWorkAllocatied)
				viewModel.GoToInspectRoomPopupPageCommand.Execute(null);
			else
				viewModel.GoToInspectedRoomPopupPageCommand.Execute(null);
		}
		#endregion
	}
}