namespace NoffaPlus.Models
{
	public class CompanyDownloadedAppsResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_permission")]
		public int IsPermission { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "app_name")]
		public string AppName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "is_downloaded")]
		public bool IsDownloaded { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
		public string Enc { get; set; }
	}
}
