using System;

namespace NoffaPlus.Models
{
	public class OperatorQueueResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_name")]
		public string QueueName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "total_operators")]
		public int TotalOperators { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "person_in_line")]
		public int PersonInLine { get; set; }
		public string DisplayCurrentDate => $"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}";
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(QueueName, 0);

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
}
