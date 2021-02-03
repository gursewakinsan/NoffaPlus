using System.Linq;
using Xamarin.Forms;
using NoffaPlus.Views;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class ReportMissingViewModel : BaseViewModel
	{
		#region Constructor.
		public ReportMissingViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Report Missing Children.
		private ICommand reportMissingChildrenCommand;
		public ICommand ReportMissingChildrenCommand
		{
			get => reportMissingChildrenCommand ?? (reportMissingChildrenCommand = new Command(async () => await ExecuteReportMissingChildrenCommand()));
		}
		private async Task ExecuteReportMissingChildrenCommand()
		{
			IsShowMsg = IsShowList = false;
			DependencyService.Get<IProgressBar>().Show();
			IChildrenService service = new ChildrenService();
			var response = await service.ReportMissingChildrenByIdAsync(Helper.Helper.CompanyId);
			if (response.Count > 0)
			{
				IsShowList = true;
				ReportMissingChildrenList = new ObservableCollection<Models.Children>(response);
			}
			else
				IsShowMsg = true;
			OnPropertyChanged("ReportMissingChildrenList");
			OnPropertyChanged("IsShowList");
			OnPropertyChanged("IsShowMsg");
			DependencyService.Get<IProgressBar>().Hide();
			await Task.CompletedTask;
		}
		#endregion

		#region Select Report Missing Children.
		public void SelectReportMissingChildren(int id)
		{
			if (ReportMissingList == null)
				ReportMissingList = new List<Models.ReportMissing>();
			var child = ReportMissingList.FirstOrDefault(x => x.ChildId.Equals(id));
			if (child == null)
				ReportMissingList.Add(new Models.ReportMissing() { CompanyId = Helper.Helper.CompanyId, ChildId = id });
			else
				ReportMissingList.Remove(child);
		}
		#endregion

		#region Submit Report Missing Children.
		private ICommand submitReportMissingChildrenCommand;
		public ICommand SubmitReportMissingChildrenCommand
		{
			get => submitReportMissingChildrenCommand ?? (submitReportMissingChildrenCommand = new Command(async () => await ExecuteSubmitReportMissingChildrenCommand()));
		}
		private async Task ExecuteSubmitReportMissingChildrenCommand()
		{
			if (ReportMissingList?.Count > 0)
			{
				DependencyService.Get<IProgressBar>().Show();
				IChildrenService service = new ChildrenService();
				var response = await service.SubmitReportMissingChildrenAsync(ReportMissingList);
				await Navigation.PushAsync(new InformMissingChildrenPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
				await Helper.Alert.DisplayAlert("Please select atlest one child for report submit.");
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		public ObservableCollection<Models.Children> ReportMissingChildrenList { get; set; }
		public List<Models.ReportMissing> ReportMissingList { get; set; }
		public bool IsShowMsg { get; set; }
		public bool IsShowList { get; set; }
		#endregion
	}
}

