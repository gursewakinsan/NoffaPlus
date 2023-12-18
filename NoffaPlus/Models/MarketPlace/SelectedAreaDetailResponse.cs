using System.Collections.Generic;

namespace NoffaPlus.Models
{
    public class SelectedAreaDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "city_name")]
        public string CityName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "region_id")]
        public int RegionId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "area_list")]
        public List<AreaList> AreaList { get; set; }
    }

    public class AreaList : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

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

        [Newtonsoft.Json.JsonProperty(PropertyName = "area_name")]
        public string AreaName { get; set; }
    }
}