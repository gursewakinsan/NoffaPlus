namespace NoffaPlus.Models
{
    public class ConnectApartmentRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "request_id")]
        public int RequestId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_available")]
        public int ApartmentAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_number")]
        public string ApartmentNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }
    }
}
