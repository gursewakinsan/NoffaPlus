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

        [Newtonsoft.Json.JsonProperty(PropertyName = "one_shared")]
        public int OneShared { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "one_shared_type")]
        public int OneSharedType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "recurring_event")]
        public int RecurringEvent { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_1")]
        public int WorkingDay1 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_1")]
        public int WorkStartTime1 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_2")]
        public int WorkingDay2 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_2")]
        public int WorkStartTime2 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_3")]
        public int WorkingDay3 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_3")]
        public int WorkStartTime3 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_4")]
        public int WorkingDay4 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_4")]
        public int WorkStartTime4 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_5")]
        public int WorkingDay5 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_5")]
        public int WorkStartTime5 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_6")]
        public int WorkingDay6 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_6")]
        public int WorkStartTime6 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "working_day_7")]
        public int WorkingDay7 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "work_start_time_7")]
        public int WorkStartTime7 { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "open_event_date")]
        public string OpenEventDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "event_start_time")]
        public int EventStartTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "open_price_per_person")]
        public int OpenPricePerPerson { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "open_total_person")]
        public int OpenTotalPerson { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "private_price")]
        public int PrivatePrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "private_max_person")]
        public int PrivateMaxPerson { get; set; }


        [Newtonsoft.Json.JsonProperty(PropertyName = "event_at_customer_place")]
        public int EventAtCustomerPlace { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tour_fee_applicable")]
        public int TourFeeApplicable { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tour_fee")]
        public int TourFee { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "total_private_events")]
        public int TotalPrivateEvents { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "more_event_on_request")]
        public int MoreEventOnRequest { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum_people_required")]
        public int MinimumPeopleRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum_time_required")]
        public int MinimumTimeRequired { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "minimum_time_period")]
        public int MinimumTimePeriod { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "more_event_extra_fee")]
        public int MoreEventExtraFee { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "extra_fee")]
        public int ExtraFee { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tax_included")]
        public int TaxIncluded { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tax_amount")]
        public int TaxAmount { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subscription_info")]
        public int SubscriptionInfo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "recurring_type")]
        public int RecurringType { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "total_time")]
        public int TotalTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "recurring_typec")]
        public int RecurringTypec { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "tax_applicable")]
        public int TaxApplicable { get; set; }
    }
}