using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyDetailsPage : ContentPage
	{
		CompanyDetailsViewModel companyDetailsViewModel;
		int carouselViewPosition = 0;
		public CompanyDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = companyDetailsViewModel = new CompanyDetailsViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			companyDetailsViewModel.VerifyAdminCommand.Execute(null);
			base.OnAppearing();
		}

		private void OnGestureRecognizerTapped(object sender, EventArgs e)
		{
			StackLayout layout = sender as StackLayout;
			int id = Convert.ToInt32(layout.ClassId);
			if (id == 0)
				companyDetailsViewModel.AttendanceCommand.Execute(null);
		}

		private void GridOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Grid layout = sender as Grid;
			int id = Convert.ToInt32(layout.ClassId);
			if (id == 0)
				companyDetailsViewModel.AttendanceCommand.Execute(null);
		}

		private void LabelOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Label layout = sender as Label;
			int id = Convert.ToInt32(layout.ClassId);
			if (id == 0)
				companyDetailsViewModel.AttendanceCommand.Execute(null);
		}

		private void OnCarouselViewPositionChanged(object sender, PositionChangedEventArgs e)
		{
			carouselViewPosition = e.CurrentPosition;
			Color color = companyDetailsViewModel.DaycareList[carouselViewPosition].IconColor;
			indicatorView.SelectedIndicatorColor = color;
			btnLearnMore.TextColor = color;
		}

		private void OnLearnMoreButtonClicked(object sender, EventArgs e)
		{
			if (carouselViewPosition == 0)
				companyDetailsViewModel.AttendanceCommand.Execute(null);
		}
	}
}