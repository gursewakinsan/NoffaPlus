namespace NoffaPlus.Models
{
    public class CompanyMarketplacePricingDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
        public string DishName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_bookable")]
        public bool IsBookable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
        public int DishPrice { get; set; }

        public string DisplayPrice => $"${DishPrice}";
    }
}
