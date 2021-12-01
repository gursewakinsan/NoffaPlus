using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Resturant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvailableResturantDetailsPage : ContentPage
	{
		AvailableResturantDetailsPageViewModel viewModel;
		public AvailableResturantDetailsPage(Models.AvailableResturantResponse availableResturantDetails)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			lblEatAndDrink.Text = "Eat & Drink";
			BindingContext = viewModel = new AvailableResturantDetailsPageViewModel(this.Navigation);
			viewModel.AvailableResturantDetails = availableResturantDetails;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ResturantServeBasedMenuCommand.Execute(null);
		}

		private async void OnDishImageClicked(object sender, System.EventArgs e)
		{
			ImageButton image = sender as ImageButton;
			Models.Dish dish = image.BindingContext as Models.Dish;
			await Navigation.PushAsync(new AvailableResturantCategoryMenuDetailsPage(dish));
		}

		private void OnServeButtonClicked(object sender, System.EventArgs e)
		{
			Button button = sender as Button;
			Models.ServeType serveType = button.BindingContext as Models.ServeType;
			foreach (var serve in viewModel.AvailableResturantDetails.ServeTypes)
			{
				serve.IsSelectedServe = false;
				serve.ServeBg = Color.FromHex("#2A2A31");
			}
			serveType.IsSelectedServe = true;
			serveType.ServeBg = Color.FromHex("#6263ED");
			viewModel.ResturantServeBasedMenuCommand.Execute(null);
		}
	}
}