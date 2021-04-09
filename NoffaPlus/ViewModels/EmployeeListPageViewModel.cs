using Xamarin.Forms;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
	public class EmployeeListPageViewModel : BaseViewModel
	{
		#region Constructor.
		public EmployeeListPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get All Employee Command.
		private ICommand getAllEmployeeCommand;
		public ICommand GetAllEmployeeCommand
		{
			get => getAllEmployeeCommand ?? (getAllEmployeeCommand = new Command(async () => await ExecuteGetAllEmployeeCommand()));
		}
		private async Task ExecuteGetAllEmployeeCommand()
		{
			DependencyService.Get<IProgressBar>().Show();
			var sList = new AnimalList()
			{
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" }
			};
			sList.Heading = "S";

			var dList = new AnimalList()
			{
				new Animal() { Name = "Jane", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" }
			};
			dList.Heading = "D";

			var jList = new AnimalList()
			{
				new Animal() { Name = "Billy", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Sally", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "Taylor", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" },
				new Animal() { Name = "John", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzb%C3%A4r.jpg" }
			};
			jList.Heading = "J";

			var list = new List<AnimalList>()
			{
				sList,
				dList,
				jList
			};
			ListOfAnimal = list;
			DependencyService.Get<IProgressBar>().Hide();
			await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private List<AnimalList> _listOfAnimal;
		public List<AnimalList> ListOfAnimal
		{
			get { return _listOfAnimal; }
			set
			{
				_listOfAnimal = value;
				base.OnPropertyChanged();
			}
		}
		#endregion
	}
}

public class Animal
{
	public string Name { get; set; }
	public string ImageUrl { get; set; }
}

public class AnimalList : List<Animal>
{
	public string Heading { get; set; }
	public List<Animal> Animal => this;
}
