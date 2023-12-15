namespace NoffaPlus.Models
{
    public class CompanyMarketplacePricingDetailRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "domain_id")]
        public int DomainId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "professional_subcategory_id")]
        public int ProfessionalSubcategoryId { get; set; }
    }
}
