namespace NoffaPlus.Models
{
    public class SelectedAreaDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "domain_id")]
        public int DomainId { get; set; }
    }
}
