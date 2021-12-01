using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

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
			IsItemInStock = false;
			await Task.CompletedTask;
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
			IsItemInStock = true;
			await Task.CompletedTask;
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
