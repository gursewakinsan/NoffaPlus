namespace NoffaPlus.Models
{
	public class AvailableResturantResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "resturant_name")]
		public string ResturantName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_types")]
		private System.Collections.ObjectModel.ObservableCollection<ServeType> serveTypes;
		public System.Collections.ObjectModel.ObservableCollection<ServeType> ServeTypes
		{
			get => serveTypes;
			set
			{
				serveTypes = value;
				OnPropertyChanged("ServeTypes");
			}
		}

		[Newtonsoft.Json.JsonProperty(PropertyName = "num")]
		public int Num { get; set; }

		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(ResturantName, 0).ToUpper();

		private string firstLetterBg;
		public string FirstLetterBg
		{
			get => firstLetterBg;
			set
			{
				firstLetterBg = value;
				OnPropertyChanged("FirstLetterBg");
			}
		}

		private string firstLetterText;
		public string FirstLetterText
		{
			get => firstLetterText;
			set
			{
				firstLetterText = value;
				OnPropertyChanged("FirstLetterText");
			}
		}
	}

	public class ServeType : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve")]
		public string Serve { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "serve_image")]
		public string ServeImage { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "num")]
		public int? Num { get; set; }
		public bool IsSelectedServe { get; set; } = false;

		private Xamarin.Forms.Color serveBg;
		public Xamarin.Forms.Color ServeBg
		{
			get => serveBg;
			set
			{
				serveBg = value;
				OnPropertyChanged("ServeBg");
			}
		}

		private double serveWidth;
		public double ServeWidth
		{
			get => serveWidth;
			set
			{
				serveWidth = value;
				OnPropertyChanged("ServeWidth");
			}
		}
	}
}
