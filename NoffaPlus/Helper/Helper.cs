namespace NoffaPlus.Helper
{
	public static class Helper
	{
		public static T FromJson<T>(this string jsonData)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
		}
		public static string ToJson(this object obj)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
		}

		public static int LoggedInUserId { get; set; }
		public static int CompanyId { get; set; }
		public static string SessionId { get; set; }
		public static string CompanyName { get; set; }
		public static Models.ContactResponse SelectedContact { get; set; }
		public static Models.OperatorQueueResponse SelectedOperatorQueue { get; set; }
		public static int QueueGuestId { get; set; }
		public static string SelectedTabQueueText { get; set; } = string.Empty;
	}
}