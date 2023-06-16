namespace NoffaPlus.Models
{
    public class EmployeeProfessionalServiceProposalsRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "booking_date")]
        public string BookingDate { get; set; }
    }
}
