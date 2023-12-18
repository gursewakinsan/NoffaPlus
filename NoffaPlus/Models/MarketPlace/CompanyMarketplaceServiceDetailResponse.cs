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

    public class CompanyMarketplaceServiceDetailSubcategory : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_selected")]
        public bool IsSelected { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_name")]
        public string SubcategoryName { get; set; }
        
        [Newtonsoft.Json.JsonProperty(PropertyName = "professional_subcategory_id")]
        public int ProfessionalSubcategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "price_added")]
        public bool PriceAdded { get; set; }

        private bool isGreenCard;
        public bool IsGreenCard
        {
            get => isGreenCard;
            set
            {
                isGreenCard = value;
                OnPropertyChanged("IsGreenCard");
            }
        }

        private bool isOrangeCard;
        public bool IsOrangeCard
        {
            get => isOrangeCard;
            set
            {
                isOrangeCard = value;
                OnPropertyChanged("IsOrangeCard");
            }
        }

        private bool isBlackCard;
        public bool IsBlackCard
        {
            get => isBlackCard;
            set
            {
                isBlackCard = value;
                OnPropertyChanged("IsBlackCard");
            }
        }


        private bool isRightArrow;
        public bool IsRightArrow
        {
            get => isRightArrow;
            set
            {
                isRightArrow = value;
                OnPropertyChanged("IsRightArrow");
            }
        }

        private bool isAddButton;
        public bool IsAddButton
        {
            get => isAddButton;
            set
            {
                isAddButton = value;
                OnPropertyChanged("IsAddButton");
            }
        }
    }
}
