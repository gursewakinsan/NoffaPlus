using Xamarin.Forms;

namespace NoffaPlus.Models
{
	public class HotelCheckedOutListForHousekeepingIncepectionStaffResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "inspector_id")]
		public int InspectorId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_id")]
		public int RoomId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "inspection_work_allocatied")]
		public bool InspectionWorkAllocatied { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "room_name")]
		public int RoomName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "checkout_time_info")]
		public string CheckoutTimeInfo { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "started_by")]
		public string StartedBy { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name_assigned")]
		public string NameAssigned { get; set; }

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
