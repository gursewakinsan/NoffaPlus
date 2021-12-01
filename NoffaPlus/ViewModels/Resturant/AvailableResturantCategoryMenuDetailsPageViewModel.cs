using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;

namespace NoffaPlus.ViewModels
{
	public class AvailableResturantCategoryMenuDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AvailableResturantCategoryMenuDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Item In Stock Command.
		private ICommand itemInStockCommand;
		public ICommand ItemInStockCommand
		{
			get => itemInStockCommand ?? (itemInStockCommand = new Command(async () => await ExecuteItemInStockCommand()));
		}
		private async Task ExecuteItemInStockCommand()
		{
			ItemOutOfStockPopupContext context = new ItemOutOfStockPopupContext()
			{
				AvailableDishId = DishDetailsInfo.Id,
				CallBack = ItemOutOfStockPopupCallBack
			};
			await Navigation.PushPopupAsync(new PopupPages.ItemOutOfStockPopupPage(context));
		}

		private async void ItemOutOfStockPopupCallBack()
		{
			await Navigation.PopAsync();
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
				AvailableDishId = DishDetailsInfo.Id,
				InStock = 1
			});
			DependencyService.Get<IProgressBar>().Hide();
			IsItemInStock = true;
			await Navigation.PopAsync();
		}
		#endregion

		#region Remove this dish Command.
		private ICommand removeThisDishCommand;
		public ICommand RemoveThisDishCommand
		{
			get => removeThisDishCommand ?? (removeThisDishCommand = new Command(async () => await ExecuteRemoveThisDishCommand()));
		}
		private async Task ExecuteRemoveThisDishCommand()
		{
			DeleteDishItemPopupContext context = new DeleteDishItemPopupContext()
			{
				AvailableDishId = DishDetailsInfo.Id,
				CallBack = DeleteDishItemPopupCallBack
			};
			await Navigation.PushPopupAsync(new PopupPages.RemoveTheDishPopupPage(context));
		}

		private async void DeleteDishItemPopupCallBack()
		{
			await Navigation.PopAsync();
		}
		#endregion

		#region Properties.
		private Models.Dish dishDetailsInfo;
		public Models.Dish DishDetailsInfo
		{
			get => dishDetailsInfo;
			set
			{
				dishDetailsInfo = value;
				OnPropertyChanged("DishDetailsInfo");
			}
		}

		private bool isItemInStock;
		public bool IsItemInStock
		{
			get => isItemInStock;
			set
			{
				isItemInStock = value;
				OnPropertyChanged("IsItemInStock");
			}
		}
		#endregion
	}
}
