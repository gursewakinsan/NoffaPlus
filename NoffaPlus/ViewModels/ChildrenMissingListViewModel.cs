using Xamarin.Forms;
using System.Linq;
using NoffaPlus.Views;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class ChildrenMissingListViewModel : BaseViewModel
	{
		#region Constructor.
		public ChildrenMissingListViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Children Missing.
		private ICommand getChildrenMissingCommand;
		public ICommand GetChildrenMissingCommand
		{
			get => getChildrenMissingCommand ?? (getChildrenMissingCommand = new Command(async () => await ExecuteGetChildrenMissingCommand()));
		}
		private async Task ExecuteGetChildrenMissingCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			IChildrenService service = new ChildrenService();
			var response = await service.GetMissingChildrenByIdAsync(Helper.Helper.CompanyId);
			if (response.Count > 0)
				ChildrenMissingList = new ObservableCollection<Models.Children>(response);
			else
			{
				ChildrenMissingList = new ObservableCollection<Models.Children>();
				ChildrenMissingList.Add(new Models.Children()
				{
					Id = 0,
					FirstName = "No one is missing!",
					ImagePath = "https://cdn0.iconfinder.com/data/icons/baby-emoticon-filled/64/baby_emoji-03-512.png"
				});
			}
			OnPropertyChanged("ChildrenMissingList");
			DependencyService.Get<IProgressBar>().Hide();
			await Task.CompletedTask;
		}
		#endregion

		#region Selected Children Missing.
		private ICommand selectedChildrenMissingCommand;
		public ICommand SelectedChildrenMissingCommand
		{
			get => selectedChildrenMissingCommand ?? (selectedChildrenMissingCommand = new Command<int>(async (id) => await ExecuteSelectedChildrenMissingCommand(id)));
		}
		private async Task ExecuteSelectedChildrenMissingCommand(int id)
		{
			if (id == 0) return;
			Models.Children child = ChildrenMissingList.FirstOrDefault(x => x.Id.Equals(id));
			await Navigation.PushAsync(new ChildrenMissingDetailsPage(child));
			await Task.CompletedTask;
		}
		#endregion

		#region Report Missing Command.
		private ICommand reportMissingCommand;
		public ICommand ReportMissingCommand
		{
			get => reportMissingCommand ?? (reportMissingCommand = new Command(async () => await ExecuteReportMissingCommand()));
		}
		private async Task ExecuteReportMissingCommand()
		{
			await Navigation.PushAsync(new ReportMissingPage());
		}
		#endregion

		#region Properties.
		public ObservableCollection<Models.Children> ChildrenMissingList { get; set; }
		#endregion
	}
}
