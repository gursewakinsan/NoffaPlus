using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using System.Threading.Tasks;

namespace NoffaPlus.Views.Resturant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvailableResturantListPage : ContentPage
	{
		AvailableResturantListPageViewModel viewModel;
		public AvailableResturantListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			lblEatAndDrink.Text = "Eat & Drink";
			BindingContext = viewModel = new AvailableResturantListPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.AvailableResturantListCommand.Execute(null);
		}

		private async void OnGridAvailableResturantListTapped(object sender, System.EventArgs e)
		{
			Grid grid = sender as Grid;
			Models.AvailableResturantResponse availableResturant = grid.BindingContext as Models.AvailableResturantResponse;
			if (availableResturant.ServeTypes?.Count > 0)
				await GoToAvailableResturantDetailsPage(availableResturant);
		}

		private async void OnFrameAvailableResturantListTapped(object sender, System.EventArgs e)
		{
			Frame frame = sender as Frame;
			Models.AvailableResturantResponse availableResturant = frame.BindingContext as Models.AvailableResturantResponse;
			if (availableResturant.ServeTypes?.Count > 0)
				await GoToAvailableResturantDetailsPage(availableResturant);
		}

		private async void OnChevronRightAvailableResturantTapped(object sender, System.EventArgs e)
		{
			Label label = sender as Label;
			Models.AvailableResturantResponse availableResturant = label.BindingContext as Models.AvailableResturantResponse;
			if (availableResturant.ServeTypes?.Count > 0)
				await GoToAvailableResturantDetailsPage(availableResturant);
		}

		private async Task GoToAvailableResturantDetailsPage(Models.AvailableResturantResponse availableResturant)
		{
			int deviceWidth = App.ScreenWidth - 56;
			int w = deviceWidth * 26 / 100;
			for (int i = 0; i < availableResturant.ServeTypes.Count; i++)
			{
				availableResturant.ServeTypes[i].ServeBg = Color.FromHex("#2A2A31");
				availableResturant.ServeTypes[i].ServeWidth = w;
			}
			availableResturant.ServeTypes[0].ServeBg = Color.FromHex("#6263ED");
			availableResturant.ServeTypes[0].IsSelectedServe = true;
			await Navigation.PushAsync(new AvailableResturantDetailsPage(availableResturant));
		}
	}
}