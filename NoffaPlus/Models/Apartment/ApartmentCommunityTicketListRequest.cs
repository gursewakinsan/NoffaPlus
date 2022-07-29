namespace NoffaPlus.Models
{
    public class ApartmentCommunityTicketListRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public string ApartmentId { get; set; }
    }
}
