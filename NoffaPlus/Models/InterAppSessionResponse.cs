﻿namespace NoffaPlus.Models
{
	public class InterAppSessionResponse
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "result")]
		public int Result { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }
	}
}
