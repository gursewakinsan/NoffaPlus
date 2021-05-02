namespace NoffaPlus.Models
{
	public class EmployeeAtendenceResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "eid")]
		public int Eid { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "diffh")]
		public int DiffHr { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "diffm")]
		public int DiffM { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "diffs")]
		public int DiffS { get; set; }
	}
}
