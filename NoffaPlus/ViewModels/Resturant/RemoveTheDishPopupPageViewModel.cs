using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.ViewModels
{
	public class RemoveTheDishPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RemoveTheDishPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Delete Dish Item Command.
		private ICommand deleteDishItemCommand;
		public ICommand DeleteDishItemCommand
		{
			get => deleteDishItemCommand ?? (deleteDishItemCommand = new Command(async () => await ExecuteDeleteDishItemCommand()));
		}
		private async Task ExecuteDeleteDishItemCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IResturantService service = new ResturantService();
			await service.DeleteDishItemAsync(new Models.DeleteDishItemRequest()
			{
				AvailableDishId = DeleteDishItemPopupPageContext.AvailableDishId,
			});
			DependencyService.Get<IProgressBar>().Hide();
			await Navigation.PopPopupAsync();
			DeleteDishItemPopupPageContext.CallBack.Invoke();
		}
		#endregion

		#region Properties.
		public DeleteDishItemPopupContext DeleteDishItemPopupPageContext { get; set; }
		#endregion
	}
}
