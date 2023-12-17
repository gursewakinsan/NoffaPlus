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

        [Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
        public string DishName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
        public int DishPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "product_information")]
        public string ProductInformation { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "time_required")]
        public int TimeRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "preparation_time")]
        public int PreparationTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "post_production_time")]
        public int PostProductionTime { get; set; }


        



        [Newtonsoft.Json.JsonProperty(PropertyName = "is_bookable")]
        public int IsBookable { get; set; }
    }
}
