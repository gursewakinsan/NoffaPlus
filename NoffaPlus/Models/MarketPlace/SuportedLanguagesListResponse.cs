namespace NoffaPlus.Models
{
    public class SuportedLanguagesListResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "language_name")]
        public string LanguageName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_selected")]
        private bool isSelected;
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
