using System.Collections.Generic;

namespace NoffaPlus.Models
{
    public class ApartmentCommunityTicketDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "problem_description")]
        public string ProblemDescription { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_type")]
        public int TicketType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_title")]
        public string TicketTitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "ticket_subtitle")]
        public string TicketSubtitle { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public List<ApartmentCommunityTicketDetailImage> Images { get; set; }
    }
}

public class ApartmentCommunityTicketDetailImage
{
    [Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
    public string ImagePath { get; set; }
    public int ItemWidth { get; set; }
}

