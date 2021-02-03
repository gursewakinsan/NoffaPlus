using System.ComponentModel;

namespace NoffaPlus.Models
{
	public class Children : INotifyPropertyChanged
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
		public string LastName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "social_number")]
		public string SocialNumber { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "child_image_path")]
		public string ChildImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public string Enc { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(FirstName, 0);
		public string DisplayName => $"{FirstName} {LastName}";

		private bool isSelected;
		public bool IsSelected
		{
			get { return isSelected; }
			set
			{
				if (isSelected != value)
				{
					isSelected = value;
					OnPropertyChanged("IsSelected");
					OnPropertyChanged("IsSelectImageUrl");
				}
			}
		}
		public string IsSelectImageUrl => IsSelected ? "iconTickRed.png" : "iconTickGray.png";

		public event PropertyChangedEventHandler PropertyChanged;
		public virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
