namespace NoffaPlus.Models
{
    public class AddProfessionalCompanyServiceRequest
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "company_id")]
        public int CompanyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "domain_id")]
        public int DomainId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_id")]
        public int SubcategoryId { get; set; }
    }
}
