using Xamarin.Forms;

namespace NoffaPlus.Models
{
	public class HotelBookingListForCleningStaffResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_name")]
		public string RoomName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_cleaning_allocated")]
		public bool RoomCleaningAllocated { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "started_by")]
		public string StartedBy { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_assigned")]
		public string NameAssigned { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_cleaning_staff_id")]
		public int? RoomCleaningStaffId { get; set; }

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

		/*
		public object passport_image { get; set; }
		public string checkin_booking_date { get; set; }
		public string checkout_booking_date { get; set; }
		public string room_cleaning_date { get; set; }
		public int room_cleaning_status { get; set; }
		
		public string user_image { get; set; }*/

		public System.Action CallBack { get; set; }
	}
}
