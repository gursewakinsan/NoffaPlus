using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NoffaPlus.ViewModels
{
    public class SetMarketPricePageViewModel : BaseViewModel
    {
        #region Constructor.
        public SetMarketPricePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            MinimumTime = new List<Models.MinimumTimeModel>()
            {
                new Models.MinimumTimeModel(){ Id =1, MinimumTime="15 minutes"},
                new Models.MinimumTimeModel(){ Id =2, MinimumTime="30 minutes"},
                new Models.MinimumTimeModel(){ Id =3, MinimumTime="45 minutes"},
                new Models.MinimumTimeModel(){ Id =4, MinimumTime="60 minutes"}
            };
            SelectedMinimumTime = MinimumTime[0];

            PreparationTime = new List<Models.PreparationTimeModel>()
            {
                new Models.PreparationTimeModel(){ Id =0, PreparationTime="0 minutes"},
                new Models.PreparationTimeModel(){ Id =1, PreparationTime="15 minutes"},
                new Models.PreparationTimeModel(){ Id =2, PreparationTime="30 minutes"},
                new Models.PreparationTimeModel(){ Id =3, PreparationTime="45 minutes"},
                new Models.PreparationTimeModel(){ Id =4, PreparationTime="60 minutes"}
            };
            SelectedPreparationTime = PreparationTime[0];


            PostProductionTime = new List<Models.PostProductionTimeModel>()
            {
                new Models.PostProductionTimeModel(){ Id =0, PostProductionTime="0 minutes"},
                new Models.PostProductionTimeModel(){ Id =1, PostProductionTime="15 minutes"},
                new Models.PostProductionTimeModel(){ Id =2, PostProductionTime="30 minutes"},
                new Models.PostProductionTimeModel(){ Id =3, PostProductionTime="45 minutes"},
                new Models.PostProductionTimeModel(){ Id =4, PostProductionTime="60 minutes"}
            };
            SelectedPostProductionTime = PostProductionTime[0];

            BookingTypeModel = new List<Models.BookingTypeModel>()
            {
                new Models.BookingTypeModel(){Id =1, BookingType ="One to one"},
                new Models.BookingTypeModel(){Id =2, BookingType ="Shared"}
            };
            SelectedBookingTypeModel = BookingTypeModel[0];

            SharedTypeModel = new List<Models.SharedTypeModel>()
            {
                new Models.SharedTypeModel(){Id =1, SharedType="Open"},
                new Models.SharedTypeModel(){Id =2, SharedType="Private"},
                new Models.SharedTypeModel(){Id =3, SharedType="Both"}
            };
            SelectedSharedTypeModel = SharedTypeModel[0];
        }
        #endregion

        #region Is Bookable Service Command.
        private ICommand isBookableServiceCommand;
        public ICommand IsBookableServiceCommand
        {
            get => isBookableServiceCommand ?? (isBookableServiceCommand = new Command( () =>  ExecuteIsBookableServiceCommand()));
        }
        private void ExecuteIsBookableServiceCommand()
        {
            IsBookableService = !IsBookableService;
        }
        #endregion

        #region Is Recurring Event Command.
        private ICommand isRecurringEventCommand;
        public ICommand IsRecurringEventCommand
        {
            get => isRecurringEventCommand ?? (isRecurringEventCommand = new Command(() => ExecuteIsRecurringEventCommand()));
        }
        private void ExecuteIsRecurringEventCommand()
        {
            IsRecurringEvent = !IsRecurringEvent;
        }
        #endregion

        #region Weekdays Command.
        private ICommand weekdaysCommand;
        public ICommand WeekdaysCommand
        {
            get => weekdaysCommand ?? (weekdaysCommand = new Command<string>((day) => ExecuteWeekdaysCommand(day)));
        }
        private void ExecuteWeekdaysCommand(string day)
        {
            switch (day)
            {
                case "Monday":
                    {
                        IsMonday = !IsMonday;
                        break;
                    }
                case "Tuesday":
                    {
                        IsTuesday = !IsTuesday;
                        break;
                    }
                case "Wednesday":
                    {
                        IsWednesday = !IsWednesday;
                        break;
                    }
                case "Thursday":
                    {
                        IsThursday = !IsThursday;
                        break;
                    }
                case "Friday":
                    {
                        IsFriday = !IsFriday;
                        break;
                    }
                case "Saturday":
                    {
                        IsSaturday = !IsSaturday;
                        break;
                    }
                case "Sunday":
                    {
                        IsSunday = !IsSunday;
                        break;
                    }
            }
        }
        #endregion

        #region Properties.
        public string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string price;
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string descriptions;
        public string Descriptions
        {
            get => descriptions;
            set
            {
                descriptions = value;
                OnPropertyChanged("Descriptions");
            }
        }

        public bool isBookableService;
        public bool IsBookableService
        {
            get => isBookableService;
            set
            {
                isBookableService = value;
                OnPropertyChanged("IsBookableService");
            }
        }

        public bool isRecurringEvent;
        public bool IsRecurringEvent
        {
            get => isRecurringEvent;
            set
            {
                isRecurringEvent = value;
                OnPropertyChanged("IsRecurringEvent");
            }
        }

        public bool isMonday;
        public bool IsMonday
        {
            get => isMonday;
            set
            {
                isMonday = value;
                OnPropertyChanged("IsMonday");
            }
        }

        public bool isTuesday;
        public bool IsTuesday
        {
            get => isTuesday;
            set
            {
                isTuesday = value;
                OnPropertyChanged("IsTuesday");
            }
        }

        public bool isWednesday;
        public bool IsWednesday
        {
            get => isWednesday;
            set
            {
                isWednesday = value;
                OnPropertyChanged("IsWednesday");
            }
        }

        public bool isThursday;
        public bool IsThursday
        {
            get => isThursday;
            set
            {
                isThursday = value;
                OnPropertyChanged("IsThursday");
            }
        }

        public bool isFriday;
        public bool IsFriday
        {
            get => isFriday;
            set
            {
                isFriday = value;
                OnPropertyChanged("IsFriday");
            }
        }

        public bool isSaturday;
        public bool IsSaturday
        {
            get => isSaturday;
            set
            {
                isSaturday = value;
                OnPropertyChanged("IsSaturday");
            }
        }

        public bool isSunday;
        public bool IsSunday
        {
            get => isSunday;
            set
            {
                isSunday = value;
                OnPropertyChanged("IsSunday");
            }
        }

        private List<Models.MinimumTimeModel> minimumTime;
        public List<Models.MinimumTimeModel> MinimumTime
        {
            get => minimumTime;
            set
            {
                minimumTime = value;
                OnPropertyChanged("MinimumTime");
            }
        }

        private Models.MinimumTimeModel selectedMinimumTime;
        public Models.MinimumTimeModel SelectedMinimumTime
        {
            get => selectedMinimumTime;
            set
            {
                selectedMinimumTime = value;
                OnPropertyChanged("SelectedMinimumTime");
            }
        }

        private List<Models.PreparationTimeModel> preparationTime;
        public List<Models.PreparationTimeModel> PreparationTime
        {
            get => preparationTime;
            set
            {
                preparationTime = value;
                OnPropertyChanged("PreparationTime");
            }
        }

        private Models.PreparationTimeModel selectedPreparationTime;
        public Models.PreparationTimeModel SelectedPreparationTime
        {
            get => selectedPreparationTime;
            set
            {
                selectedPreparationTime = value;
                OnPropertyChanged("SelectedPreparationTime");
            }
        }

        private List<Models.PostProductionTimeModel> postProductionTime;
        public List<Models.PostProductionTimeModel> PostProductionTime
        {
            get => postProductionTime;
            set
            {
                postProductionTime = value;
                OnPropertyChanged("PostProductionTime");
            }
        }

        private Models.PostProductionTimeModel selectedPostProductionTime;
        public Models.PostProductionTimeModel SelectedPostProductionTime
        {
            get => selectedPostProductionTime;
            set
            {
                selectedPostProductionTime = value;
                OnPropertyChanged("SelectedPostProductionTime");
            }
        }

        private List<Models.BookingTypeModel> bookingTypeModel;
        public List<Models.BookingTypeModel> BookingTypeModel
        {
            get => bookingTypeModel;
            set
            {
                bookingTypeModel = value;
                OnPropertyChanged("BookingTypeModel");
            }
        }

        private Models.BookingTypeModel selectedBookingTypeModel;
        public Models.BookingTypeModel SelectedBookingTypeModel
        {
            get => selectedBookingTypeModel;
            set
            {
                selectedBookingTypeModel = value;
                OnPropertyChanged("SelectedBookingTypeModel");
            }
        }

        private List<Models.SharedTypeModel> sharedTypeModel;
        public List<Models.SharedTypeModel> SharedTypeModel
        {
            get => sharedTypeModel;
            set
            {
                sharedTypeModel = value;
                OnPropertyChanged("SharedTypeModel");
            }
        }

        private Models.SharedTypeModel selectedSharedTypeModel;
        public Models.SharedTypeModel SelectedSharedTypeModel
        {
            get => selectedSharedTypeModel;
            set
            {
                selectedSharedTypeModel = value;
                OnPropertyChanged("SelectedSharedTypeModel");
            }
        }
        #endregion
    }
}

