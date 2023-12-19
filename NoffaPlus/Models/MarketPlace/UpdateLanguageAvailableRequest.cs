namespace NoffaPlus.Models
{
    public class UpdateLanguageAvailableRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "domain_id")]
        public int DomainId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "language_id")]
        public int LanguageId { get; set; }
    }
}
