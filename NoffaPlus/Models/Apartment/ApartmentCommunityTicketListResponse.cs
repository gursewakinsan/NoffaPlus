using System.Collections.Generic;

namespace NoffaPlus.Models
{
    public class ApartmentCommunityTicketListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "notstarted")]
        public List<ApartmentCommunityTicketModel> NotStartedList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "started")]
        public List<ApartmentCommunityTicketModel> StartedList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "finished")]
        public List<ApartmentCommunityTicketModel> FinishedList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cancelled")]
        public List<ApartmentCommunityTicketModel> CancelledList { get; set; }
    }
}

public class ApartmentCommunityTicketModel
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
}