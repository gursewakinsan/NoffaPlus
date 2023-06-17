namespace NoffaPlus.Models
{
    public class PropertyDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_floor")]
        public int ApartmentFloor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "entrance_floor")]
        public int EntranceFloor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bed_count")]
        public int BedCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bath_count")]
        public int BathCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floors_available")]
        public int FloorsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_layout")]
        public string PropertyLayout { get; set; }
    }
}