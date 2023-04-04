namespace NoffaPlus.Models
{
    public class GetAvailableApartmentResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "office_apartment_number")]
        public int OfficeApartmentNumber { get; set; }
    }
}
