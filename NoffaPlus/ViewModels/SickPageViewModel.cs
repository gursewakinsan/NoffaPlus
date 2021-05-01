using System;
using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;

namespace NoffaPlus.ViewModels
{
	public class SickPageViewModel : BaseViewModel
	{
		#region Constructor.
		public SickPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Sick Leave Command.
		private ICommand sickLeaveCommand;
		public ICommand SickLeaveCommand
		{
			get => sickLeaveCommand ?? (sickLeaveCommand = new Command(async () => await ExecuteSickLeaveCommand()));
		}
		private async Task ExecuteSickLeaveCommand()
		{
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private string displayCurrentTime = "00:00";
		public string DisplayCurrentTime
		{
			get => displayCurrentTime;
			set
			{
				displayCurrentTime = value;
				OnPropertyChanged("DisplayCurrentTime");
			}
		}

		private string displayCurrentDate = DateTime.Now.Date.ToString("dddd - MMMM dd");
		public string DisplayCurrentDate
		{
			get => displayCurrentDate;
			set
			{
				displayCurrentDate = value;
				OnPropertyChanged("DisplayCurrentDate");
			}
		}
		#endregion
	}
}
