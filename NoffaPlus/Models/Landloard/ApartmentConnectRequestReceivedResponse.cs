using System.IO;

namespace NoffaPlus.Models
{
    public class ApartmentConnectRequestReceivedResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_layout")]
        public int PropertyLayout { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "entrance_floor")]
        public int EntranceFloor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "port_number")]
        public string PortNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floors_available")]
        public int FloorsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_floor")]
        public int ApartmentFloor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_address_id")]
        public int UserAddressId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
        public string PropertyNickname { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "building_name")]
        public string BuildingName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floor_number")]
        public int FloorNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "building_id")]
        public int BuildingId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bedroomCount")]
        public int BedroomCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "bathroomCount")]
        public int BathroomCount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
        public string Enc { get; set; }

        public string DisplayName => $"{FirstName} {LastName.Substring(0, 1)}";


        /*[Newtonsoft.Json.JsonProperty(PropertyName = "request_id")]
        public int RequestId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_available")]
        public int apartmentAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_number")]
        public int ApartmentNumber { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "apartment_id")]
        public int ApartmentId { get; set; }*/
    }
}