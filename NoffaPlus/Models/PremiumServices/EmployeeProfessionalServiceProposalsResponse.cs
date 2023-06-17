namespace NoffaPlus.Models
{
    public class EmployeeProfessionalServiceProposalsResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "job_status")]
        public int JobStatus { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "booking_time")]
        public string BookingTime { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "user_property_id")]
        public int UserPropertyId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "product_information")]
        public string ProductInformation { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "booking_employee_id")]
        public int BookingEmployeeId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "job_id")]
        public int JobId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_name")]
        public string SubcategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "floor_area")]
        public int FloorArea { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_accepted")]
        public int IsAccepted { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "project_fee")]
        public int ProjectFee { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "am_pm")]
        public string AmPm { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "enc")]
        public string Enc { get; set; }

        public bool IsJobStart { get; set; }

        public bool IsJobFinesh { get; set; }

        public bool IsJobDone { get; set; }
    }
}
