using Xamarin.Forms;
using NoffaPlus.Service;
using NoffaPlus.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class RegularFinishedCleaningTasksPageViewModel : BaseViewModel
    {
		#region Constructor.
		public RegularFinishedCleaningTasksPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaning To Do List Command.
		private ICommand cleaningToDoListCommand;
		public ICommand CleaningToDoListCommand
		{
			get => cleaningToDoListCommand ?? (cleaningToDoListCommand = new Command(async () => await ExecuteCleaningToDoListCommand()));
		}
		private async Task ExecuteCleaningToDoListCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			ICleaningJobService service = new CleaningJobService();
			CleaningToDoList = await service.CleaningServiceAvailableTodoDetailAsync(new Models.CleaningServiceAvailableTodoDetailRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob
			});
			DependencyService.Get<IProgressBar>().Hide();
		}
		#endregion

		#region Update Cleaning Job Done Command.
		private ICommand updateCleaningJobDoneCommand;
		public ICommand UpdateCleaningJobDoneCommand
		{
			get => updateCleaningJobDoneCommand ?? (updateCleaningJobDoneCommand = new Command(async () => await ExecuteUpdateCleaningJobDoneCommand()));
		}
		private async Task ExecuteUpdateCleaningJobDoneCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			List<int> toDoItem = new List<int>();
            foreach (var itemCleaning in CleaningToDoList)
            {
                foreach (var todo in itemCleaning.TodosInfo)
                {
					if (todo.IsSelectTodoItem)
						toDoItem.Add(todo.Id);
				}
            }
			if (toDoItem.Count > 0)
			{
				ICleaningJobService service = new CleaningJobService();
				await service.UpdateCleaningJobDoneAsync(new Models.UpdateCleaningJobDoneRequest()
				{
					CleaningJobId = Helper.Helper.SelectedCleaningJob,
					UpdatedCleaningTodos = string.Join(", ", toDoItem)
				});
				await Navigation.PushAsync(new Views.CleaningJob.CleaningJobStatusInfoPage());
				DependencyService.Get<IProgressBar>().Hide();
			}
			else
			{
				DependencyService.Get<IProgressBar>().Hide();
				await Helper.Alert.DisplayAlert("Please select tasks.");
			}
		}
		#endregion

		#region Properties.
		private List<Models.CleaningServiceAvailableTodoDetailResponse> cleaningToDoList;
		public List<Models.CleaningServiceAvailableTodoDetailResponse> CleaningToDoList
		{
			get => cleaningToDoList;
			set
			{
				cleaningToDoList = value;
				OnPropertyChanged("CleaningToDoList");
			}
		}
		#endregion
	}
}
