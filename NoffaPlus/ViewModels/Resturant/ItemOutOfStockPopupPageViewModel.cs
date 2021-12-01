using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.ViewModels
{
	public class ItemOutOfStockPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ItemOutOfStockPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Item Out Of Stock Command.
		private ICommand itemOutOfStockCommand;
		public ICommand ItemOutOfStockCommand
		{
			get => itemOutOfStockCommand ?? (itemOutOfStockCommand = new Command(async () => await ExecuteItemOutOfStockCommand()));
		}
		private async Task ExecuteItemOutOfStockCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			await service.UpdateDishStockAsync(new Models.UpdateDishStockRequest()
			{
				AvailableDishId = ItemOutOfStockPopupPageContext.AvailableDishId,
				InStock = 0
			});
			DependencyService.Get<IProgressBar>().Hide();
			await Navigation.PopPopupAsync();
			ItemOutOfStockPopupPageContext.CallBack.Invoke();
		}
		#endregion

		#region Properties.
		public ItemOutOfStockPopupContext ItemOutOfStockPopupPageContext { get; set; }
		#endregion
	}
}
