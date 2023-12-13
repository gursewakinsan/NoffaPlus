namespace NoffaPlus.Models
{
    public class CompanyMarketplaceListResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "marketplace_name")]
        public string MarketPlaceName { get; set; }

        /*public int tax_info { get; set; }
        public int charge_on_estore { get; set; }
        public int charge_on_companies { get; set; }
        public int company_charge_info { get; set; }
        public int charge_on_buyers { get; set; }
        public int buyer_charge_info { get; set; }
        public int connection_type { get; set; }
        public int signup_type { get; set; }
        public string enc { get; set; }*/
    }
}
