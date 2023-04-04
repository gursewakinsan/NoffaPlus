namespace NoffaPlus.Models
{
    public class CleanersAssignedListResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_inspector")]
        public int IsInspector { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_leader")]
        public int IsLeader { get; set; }

        public bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
}
