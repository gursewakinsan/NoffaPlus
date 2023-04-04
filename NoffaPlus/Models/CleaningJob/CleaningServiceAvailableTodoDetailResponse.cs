using System.Collections.Generic;

namespace NoffaPlus.Models
{
    public class CleaningServiceAvailableTodoDetailResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "cleaning_category_id")]
        public int CleaningCategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "subcategory_name")]
        public string SubcategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "todos")]
        public List<Todo> TodosInfo { get; set; }

        private bool isVisibleTodosInfo;
        public bool IsVisibleTodosInfo
        {
            get => isVisibleTodosInfo;
            set
            {
                isVisibleTodosInfo = value;
                OnPropertyChanged("IsVisibleTodosInfo");
            }
        }

        private bool isSelectAllTodoItems;
        public bool IsSelectAllTodoItems
        {
            get => isSelectAllTodoItems;
            set
            {
                isSelectAllTodoItems = value;
                OnPropertyChanged("IsSelectAllTodoItems");
            }
        }
    }

    public class Todo : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "is_selected")]
        public int IsSelected { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "todo_name")]
        public string TodoName { get; set; }

        private bool isSelectTodoItem;
        public bool IsSelectTodoItem
        {
            get => isSelectTodoItem;
            set
            {
                isSelectTodoItem = value;
                OnPropertyChanged("IsSelectTodoItem");
            }
        }
    }
}
