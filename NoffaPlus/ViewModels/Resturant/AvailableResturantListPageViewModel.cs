using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class AvailableResturantListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AvailableResturantListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Available Resturant List Command.
		private ICommand availableResturantListCommand;
		public ICommand AvailableResturantListCommand
		{
			get => availableResturantListCommand ?? (availableResturantListCommand = new Command(async () => await ExecuteAvailableResturantListCommand()));
		}
		private async Task ExecuteAvailableResturantListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			var responseResturant = await service.AvailableResturantListAsync(new Models.AvailableResturantRequest()
			{
				CompanyId = Helper.Helper.CompanyId
			});
			int index = 0;
			foreach (var resturant in responseResturant)
			{
				resturant.FirstLetterBg = Helper.Helper.ListIconBgColorList[index];
				resturant.FirstLetterText = Helper.Helper.ListIconTextColorList[index];
				index = index + 1;
			}
			AvailableResturants = responseResturant;
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Properties.
		private List<Models.AvailableResturantResponse> availableResturants;
		public List<Models.AvailableResturantResponse> AvailableResturants
		{
			get => availableResturants;
			set
			{
				availableResturants = value;
				OnPropertyChanged("AvailableResturants");
			}
		}
		#endregion
	}
}
