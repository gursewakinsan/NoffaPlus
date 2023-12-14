using System.Collections.Generic;

namespace NoffaPlus.Models
{
    public class CompanyMarketplaceServiceDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category_completed")]
        public int CategoryCompleted { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "available_at_dstrict")]
        public int AvailableAtDstrict { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "vitech_category")]
        public int VitechCategory { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory")]
        public List<CompanyMarketplaceServiceDetailSubcategory> Subcategory { get; set; }
    }

    public class CompanyMarketplaceServiceDetailSubcategory
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_selected")]
        public int IsSelected { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_name")]
        public string SubcategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "professional_subcategory_id")]
        public int ProfessionalSubcategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "price_added")]
        public int PriceAdded { get; set; }
    }
}
