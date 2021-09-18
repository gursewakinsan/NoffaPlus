namespace NoffaPlus.Models
{
	public class OperatorQueueListRequest
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "queue_id")]
		public int QueueId { get; set; }
	}
}
