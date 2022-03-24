using Xamarin.Forms;

namespace NoffaPlus.Models
{
	public class HotelCheckedOutListForCleningStaffResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_work_assigned")]
		public bool CleaningWorkAssigned { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_name")]
		public int RoomName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_time_info")]
		public string CheckoutTimeInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "staff_assigned_id")]
		public int StaffAssignedId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "started_by")]
		public string StartedBy { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_assigned")]
		public string NameAssigned { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_time_diff")]
		public string CheckoutTimeDiff { get; set; }

		private Color roomNameTextColor;
		public Color RoomNameTextColor
		{
			get => roomNameTextColor;
			set
			{
				roomNameTextColor = value;
				OnPropertyChanged("RoomNameTextColor");
			}
		}

		private Color roomNameBgColor;
		public Color RoomNameBgColor
		{
			get => roomNameBgColor;
			set
			{
				roomNameBgColor = value;
				OnPropertyChanged("RoomNameBgColor");
			}
		}

		private Color rowBorderColor;
		public Color RowBorderColor
		{
			get => rowBorderColor;
			set
			{
				rowBorderColor = value;
				OnPropertyChanged("RowBorderColor");
			}
		}

		public System.Action CallBack { get; set; }
	}
}
