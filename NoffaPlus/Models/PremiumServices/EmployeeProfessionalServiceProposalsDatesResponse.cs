namespace NoffaPlus.Models
{
    public class EmployeeProfessionalServiceProposalsDatesResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "booking_date")]
        public int BookingDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "actual_date")]
        public string ActualDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "date_display")]
        public string DateDisplay { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "month_display")]
        public string MonthDisplay { get; set; }

        private bool isDateSelected;
        public bool IsDateSelected
        { 
            get=> isDateSelected;
            set
            {
                isDateSelected = value;
                OnPropertyChanged("IsDateSelected");
            }
        }
    }
}
