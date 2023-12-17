﻿using Xamarin.Forms;
using NoffaPlus.Service;
using System.Windows.Input;
using NoffaPlus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ZXing.QrCode.Internal;

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

            SubscriptionType = new List<Models.SubscriptionTypeModel>()
            {
                new Models.SubscriptionTypeModel(){Id=1, SubscriptionType ="Hourly"},
                new Models.SubscriptionTypeModel(){Id=2, SubscriptionType ="Daily"},
                new Models.SubscriptionTypeModel(){Id=3, SubscriptionType ="Weekly"},
                new Models.SubscriptionTypeModel(){Id=4, SubscriptionType ="Monthly"},
                new Models.SubscriptionTypeModel(){Id=5, SubscriptionType ="Every 3 Month"},
                new Models.SubscriptionTypeModel(){Id=6, SubscriptionType ="Every 6 Month"},
                new Models.SubscriptionTypeModel(){Id=7, SubscriptionType ="Yearly"},
                new Models.SubscriptionTypeModel(){Id=8, SubscriptionType ="Custom"}
            };
            SelectedSubscriptionType = SubscriptionType[0];

            CustomSubscriptionType = new List<Models.CustomSubscriptionTypeModel>()
            {
                new Models.CustomSubscriptionTypeModel(){Id=1, CustomSubscriptionType ="Hourly"},
                new Models.CustomSubscriptionTypeModel(){Id=2, CustomSubscriptionType ="Daily"},
                new Models.CustomSubscriptionTypeModel(){Id=3, CustomSubscriptionType ="Weekly"},
                new Models.CustomSubscriptionTypeModel(){Id=4, CustomSubscriptionType ="Monthly"},
                new Models.CustomSubscriptionTypeModel(){Id=5, CustomSubscriptionType ="Yearly"}
            };
            SelectedCustomSubscriptionType = CustomSubscriptionType[0];
        }
        #endregion

        #region Is Bookable Service Command.
        private ICommand isBookableServiceCommand;
        public ICommand IsBookableServiceCommand
        {
            get => isBookableServiceCommand ?? (isBookableServiceCommand = new Command(() => ExecuteIsBookableServiceCommand()));
        }
        private void ExecuteIsBookableServiceCommand()
        {
            IsBookableService = !IsBookableService;
            if(IsBookableService) 
                SelectedBookingTypeModel = BookingTypeModel[0];
            if (!IsBookableService)
                IsThisSubscriptionControl = true;
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
            if (IsRecurringEvent)
            {
                IsMondayControl = true;
                IsTuesdayControl = true;
                IsWednesdayControl = true;
                IsThursdayControl = true;
                IsFridayControl = true;
                IsSaturdayControl = true;
                IsSundayControl = true;
                IsPricePerX = true;
                IsEventDateControl = false;
                IsEventStartTimeControl = false;
            }
            else
            {
                IsMondayControl = false;
                IsTuesdayControl = false;
                IsWednesdayControl = false;
                IsThursdayControl = false;
                IsFridayControl = false;
                IsSaturdayControl = false;
                IsSundayControl = false;
                IsPricePerX = true;
                IsEventDateControl = true;
                IsEventStartTimeControl = true;
            }
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

        #region Extra Fee Applicable Command.
        private ICommand extraFeeApplicableCommand;
        public ICommand ExtraFeeApplicableCommand
        {
            get => extraFeeApplicableCommand ?? (extraFeeApplicableCommand = new Command(() => ExecuteExtraFeeApplicableCommand()));
        }
        private void ExecuteExtraFeeApplicableCommand()
        {
            IsExtraFeeControl = !IsExtraFeeControl;
        }
        #endregion

        #region More Events Upon Request Command.
        private ICommand moreEventsUponRequestCommand;
        public ICommand MoreEventsUponRequestCommand
        {
            get => moreEventsUponRequestCommand ?? (moreEventsUponRequestCommand = new Command(() => ExecuteMoreEventsUponRequestCommand()));
        }
        private void ExecuteMoreEventsUponRequestCommand()
        {
            IsMoreEventsUponRequest = !IsMoreEventsUponRequest;
        }
        #endregion

        #region At Customer Location Command.
        private ICommand atCustomerLocationCommand;
        public ICommand AtCustomerLocationCommand
        {
            get => atCustomerLocationCommand ?? (atCustomerLocationCommand = new Command(() => ExecuteAtCustomerLocationCommand()));
        }
        private void ExecuteAtCustomerLocationCommand()
        {
            IsAtCustomerLocation = !IsAtCustomerLocation;
        }
        #endregion

        #region Tour Fee Applicable Command.
        private ICommand tourFeeApplicableCommand;
        public ICommand TourFeeApplicableCommand
        {
            get => tourFeeApplicableCommand ?? (tourFeeApplicableCommand = new Command(() => ExecuteTourFeeApplicableCommand()));
        }
        private void ExecuteTourFeeApplicableCommand()
        {
            IsTourFeeApplicable = !IsTourFeeApplicable;
        }
        #endregion

        #region Is This Subscription Command.
        private ICommand isThisSubscriptionCommand;
        public ICommand IsThisSubscriptionCommand
        {
            get => isThisSubscriptionCommand ?? (isThisSubscriptionCommand = new Command(() => ExecuteIsThisSubscriptionCommand()));
        }
        private void ExecuteIsThisSubscriptionCommand()
        {
            IsThisSubscription = !IsThisSubscription;
        }
        #endregion

        #region Tax Included In Price Command.
        private ICommand taxIncludedInPriceCommand;
        public ICommand TaxIncludedInPriceCommand
        {
            get => taxIncludedInPriceCommand ?? (taxIncludedInPriceCommand = new Command(() => ExecuteIsTaxIncludedInPriceCommand()));
        }
        private void ExecuteIsTaxIncludedInPriceCommand()
        {
            IsTaxIsIncludedInPrice = !IsTaxIsIncludedInPrice;
        }
        #endregion

        #region Add Professional Company Service Command.
        private ICommand addProfessionalCompanyServiceCommand;
        public ICommand AddProfessionalCompanyServiceCommand
        {
            get => addProfessionalCompanyServiceCommand ?? (addProfessionalCompanyServiceCommand = new Command(async () => await ExecuteAddProfessionalCompanyServiceCommand()));
        }
        private async Task ExecuteAddProfessionalCompanyServiceCommand()
        {
            DependencyService.Get<IProgressBar>().Show();
            IMarketPlaceService service = new MarketPlaceService();
            if (string.IsNullOrEmpty(Title))
                await Helper.Alert.DisplayAlert("Title is required.");
            else if (Price ==0)
                await Helper.Alert.DisplayAlert("Price cannot be zero");
            if (string.IsNullOrEmpty(Descriptions))
                await Helper.Alert.DisplayAlert("Descriptions is required.");



            await service.AddProfessionalCompanyServiceAsync(new Models.AddProfessionalCompanyServiceRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId,
                //CategoryId
                SubcategoryId= Helper.Helper.ProfessionalSubcategoryId,
                DishName = Title,
                DishPrice = Price,
                ProductInformation = Descriptions,
                TimeRequired = SelectedMinimumTime.Id,
                PreparationTime = SelectedPreparationTime.Id,
                PostProductionTime = SelectedPostProductionTime.Id,
                IsBookable = IsBookableService?1:0
            });
            DependencyService.Get<IProgressBar>().Hide();
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

        public int price = 1;
        public int Price
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

        public bool isBookableService = false;
        public bool IsBookableService
        {
            get => isBookableService;
            set
            {
                isBookableService = value;
                OnPropertyChanged("IsBookableService");
                ShowHideOnBookableService(isBookableService);
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
                ShowHideOnBookingType(selectedBookingTypeModel.BookingType);
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
                OnSharedTypeSelected(selectedSharedTypeModel.SharedType);
            }
        }

        private List<Models.SubscriptionTypeModel> subscriptionType;
        public List<Models.SubscriptionTypeModel> SubscriptionType
        {
            get => subscriptionType;
            set
            {
                subscriptionType = value;
                OnPropertyChanged("SubscriptionType");
            }
        }

        private Models.SubscriptionTypeModel selectedSubscriptionType;
        public Models.SubscriptionTypeModel SelectedSubscriptionType
        {
            get => selectedSubscriptionType;
            set
            {
                selectedSubscriptionType = value;
                OnPropertyChanged("SelectedSubscriptionType");
                if (selectedSubscriptionType.SubscriptionType.Equals("Custom"))
                    IsSubscriptionTypeCustom = true;
                else
                    IsSubscriptionTypeCustom = false;
            }
        }


        private List<Models.CustomSubscriptionTypeModel> customSubscriptionType;
        public List<Models.CustomSubscriptionTypeModel> CustomSubscriptionType
        {
            get => customSubscriptionType;
            set
            {
                customSubscriptionType = value;
                OnPropertyChanged("CustomSubscriptionType");
            }
        }

        private Models.CustomSubscriptionTypeModel selectedCustomSubscriptionType;
        public Models.CustomSubscriptionTypeModel SelectedCustomSubscriptionType
        {
            get => selectedCustomSubscriptionType;
            set
            {
                selectedCustomSubscriptionType = value;
                OnPropertyChanged("SelectedCustomSubscriptionType");
            }
        }

        private bool isSubscriptionTypeCustom;
        public bool IsSubscriptionTypeCustom
        {
            get => isSubscriptionTypeCustom;
            set
            {
                isSubscriptionTypeCustom = value;
                OnPropertyChanged("IsSubscriptionTypeCustom");
            }
        }

        private bool isPricePerX;
        public bool IsPricePerX
        {
            get => isPricePerX;
            set
            {
                isPricePerX = value;
                OnPropertyChanged("IsPricePerX");
            }
        }

        private bool isPricePerY;
        public bool IsPricePerY
        {
            get => isPricePerY;
            set
            {
                isPricePerY = value;
                OnPropertyChanged("IsPricePerY");
            }
        }

        private bool isAtCustomerLocation;
        public bool IsAtCustomerLocation
        {
            get => isAtCustomerLocation;
            set
            {
                isAtCustomerLocation = value;
                OnPropertyChanged("IsAtCustomerLocation");
                IsTourFeeApplicableControl = isAtCustomerLocation;
                IsTravelFeeControl = IsTourFeeApplicable;
            }
        }

        private bool isTravelFeeControl;
        public bool IsTravelFeeControl
        {
            get => isTravelFeeControl;
            set
            {
                isTravelFeeControl = value;
                OnPropertyChanged("IsTravelFeeControl");
            }
        }

        private bool isMoreEventsUponRequest = true;
        public bool IsMoreEventsUponRequest
        {
            get => isMoreEventsUponRequest;
            set
            {
                isMoreEventsUponRequest = value;
                OnPropertyChanged("IsMoreEventsUponRequest");
                IsMinimumPersonRequiredControl = isMoreEventsUponRequest;
                IsRequestPeriodControl = isMoreEventsUponRequest;
                IsTimeControl = isMoreEventsUponRequest;
                IsExtraFeeApplicableControl= isMoreEventsUponRequest;
                IsExtraFeeControl= isMoreEventsUponRequest;
            }
        }

        private bool isBookingTypeControl;
        public bool IsBookingTypeControl
        {
            get => isBookingTypeControl;
            set
            {
                isBookingTypeControl = value;
                OnPropertyChanged("IsBookingTypeControl");
            }
        }

        private bool isSharedTypeControl;
        public bool IsSharedTypeControl
        {
            get => isSharedTypeControl;
            set
            {
                isSharedTypeControl = value;
                OnPropertyChanged("IsSharedTypeControl");
            }
        }

        private bool isRecurringEventControl;
        public bool IsRecurringEventControl
        {
            get => isRecurringEventControl;
            set
            {
                isRecurringEventControl = value;
                OnPropertyChanged("IsRecurringEventControl");
                ShowHideOnRecurringEventControl(isRecurringEventControl);
            }
        }

        void ShowHideOnRecurringEventControl(bool status)
        {
            if(status) 
            {
                IsMondayControl = true;
                IsTuesdayControl = true;
                IsWednesdayControl = true;
                IsThursdayControl = true;
                IsFridayControl = true;
                IsSaturdayControl = true;
                IsSundayControl = true;
                IsEventDateControl = false;
                IsEventStartTimeControl = false;
            }
            else 
            {
                IsMondayControl = false;
                IsTuesdayControl = false;
                IsWednesdayControl = false;
                IsThursdayControl = false;
                IsFridayControl = false;
                IsSaturdayControl = false;
                IsSundayControl = false;
                if (SelectedSharedTypeModel !=null && SelectedSharedTypeModel.SharedType.Equals("Private"))
                {
                    IsEventDateControl = true;
                    IsEventStartTimeControl = true;
                }
            }
        }

        private bool isEventDateControl;
        public bool IsEventDateControl
        {
            get => isEventDateControl;
            set
            {
                isEventDateControl = value;
                OnPropertyChanged("IsEventDateControl");
            }
        }

        private bool isEventStartTimeControl;
        public bool IsEventStartTimeControl
        {
            get => isEventStartTimeControl;
            set
            {
                isEventStartTimeControl = value;
                OnPropertyChanged("IsEventStartTimeControl");
            }
        }

        private bool isMondayControl;
        public bool IsMondayControl
        {
            get => isMondayControl;
            set
            {
                isMondayControl = value;
                OnPropertyChanged("IsMondayControl");
            }
        }

        private bool isTuesdayControl;
        public bool IsTuesdayControl
        {
            get => isTuesdayControl;
            set
            {
                isTuesdayControl = value;
                OnPropertyChanged("IsTuesdayControl");
            }
        }

        private bool isWednesdayControl;
        public bool IsWednesdayControl
        {
            get => isWednesdayControl;
            set
            {
                isWednesdayControl = value;
                OnPropertyChanged("IsWednesdayControl");
            }
        }

        private bool isThursdayControl;
        public bool IsThursdayControl
        {
            get => isThursdayControl;
            set
            {
                isThursdayControl = value;
                OnPropertyChanged("IsThursdayControl");
            }
        }

        private bool isFridayControl;
        public bool IsFridayControl
        {
            get => isFridayControl;
            set
            {
                isFridayControl = value;
                OnPropertyChanged("IsFridayControl");
            }
        }

        private bool isSaturdayControl;
        public bool IsSaturdayControl
        {
            get => isSaturdayControl;
            set
            {
                isSaturdayControl = value;
                OnPropertyChanged("IsSaturdayControl");
            }
        }

        private bool isSundayControl;
        public bool IsSundayControl
        {
            get => isSundayControl;
            set
            {
                isSundayControl = value;
                OnPropertyChanged("IsSundayControl");
            }
        }

        private bool isAtCustomerLocationControl;
        public bool IsAtCustomerLocationControl
        {
            get => isAtCustomerLocationControl;
            set
            {
                isAtCustomerLocationControl = value;
                OnPropertyChanged("IsAtCustomerLocationControl");
            }
        }

        private bool isMaximumEventsPerDay;
        public bool IsMaximumEventsPerDay
        {
            get => isMaximumEventsPerDay;
            set
            {
                isMaximumEventsPerDay = value;
                OnPropertyChanged("IsMaximumEventsPerDay");
            }
        }

        private bool isMoreEventsUponRequestControl;
        public bool IsMoreEventsUponRequestControl
        {
            get => isMoreEventsUponRequestControl;
            set
            {
                isMoreEventsUponRequestControl = value;
                OnPropertyChanged("IsMoreEventsUponRequestControl");
            }
        }

        private bool isMinimumPersonRequiredControl;
        public bool IsMinimumPersonRequiredControl
        {
            get => isMinimumPersonRequiredControl;
            set
            {
                isMinimumPersonRequiredControl = value;
                OnPropertyChanged("IsMinimumPersonRequiredControl");
            }
        }

        private bool isRequestPeriodControl;
        public bool IsRequestPeriodControl
        {
            get => isRequestPeriodControl;
            set
            {
                isRequestPeriodControl = value;
                OnPropertyChanged("IsRequestPeriodControl");
            }
        }

        private bool isTimeControl;
        public bool IsTimeControl
        {
            get => isTimeControl;
            set
            {
                isTimeControl = value;
                OnPropertyChanged("IsTimeControl");
            }
        }

        private bool isExtraFeeApplicableControl;
        public bool IsExtraFeeApplicableControl
        {
            get => isExtraFeeApplicableControl;
            set
            {
                isExtraFeeApplicableControl = value;
                OnPropertyChanged("IsExtraFeeApplicableControl");
            }
        }

        private bool isExtraFeeControl;
        public bool IsExtraFeeControl
        {
            get => isExtraFeeControl;
            set
            {
                isExtraFeeControl = value;
                OnPropertyChanged("IsExtraFeeControl");
                IsExtraFeeApplicable = isExtraFeeControl;
            }
        }

        private bool isExtraFeeApplicable;
        public bool IsExtraFeeApplicable
        {
            get => isExtraFeeApplicable;
            set
            {
                isExtraFeeApplicable = value;
                OnPropertyChanged("IsExtraFeeApplicable");
            }
        }
        

        private int maximumEventsPerDay=1;
        public int MaximumEventsPerDay
        {
            get => maximumEventsPerDay;
            set
            {
                maximumEventsPerDay = value;
                OnPropertyChanged("MaximumEventsPerDay");
            }
        }

        private int travelFee = 1;
        public int TravelFee
        {
            get => travelFee;
            set
            {
                travelFee = value;
                OnPropertyChanged("TravelFee");
            }
        }

        private bool isTourFeeApplicableControl;
        public bool IsTourFeeApplicableControl
        {
            get => isTourFeeApplicableControl;
            set
            {
                isTourFeeApplicableControl = value;
                OnPropertyChanged("IsTourFeeApplicableControl");
            }
        }

        private bool isTourFeeApplicable;
        public bool IsTourFeeApplicable
        {
            get => isTourFeeApplicable;
            set
            {
                isTourFeeApplicable = value;
                OnPropertyChanged("IsTourFeeApplicable");
                IsTravelFeeControl = isTourFeeApplicable;
            }
        }

        private bool isThisSubscription = false;
        public bool IsThisSubscription
        {
            get => isThisSubscription;
            set
            {
                isThisSubscription = value;
                OnPropertyChanged("IsThisSubscription");
            }
        }

        private bool isThisSubscriptionControl = false;
        public bool IsThisSubscriptionControl
        {
            get => isThisSubscriptionControl;
            set
            {
                isThisSubscriptionControl = value;
                OnPropertyChanged("IsThisSubscriptionControl");
            }
        }

        private bool isTaxIsIncludedInPrice = true;
        public bool IsTaxIsIncludedInPrice
        {
            get => isTaxIsIncludedInPrice;
            set
            {
                isTaxIsIncludedInPrice = value;
                OnPropertyChanged("IsTaxIsIncludedInPrice");
            }
        }

        private int taxIncludedInPrice=1;
        public int TaxIncludedInPrice
        {
            get => taxIncludedInPrice;
            set
            {
                taxIncludedInPrice = value;
                OnPropertyChanged("TaxIncludedInPrice");
            }
        }
        #endregion

        #region Methods.
        void ShowHideOnBookableService(bool status)
        {
            if (!status)
            {
                IsBookingTypeControl = false;
                IsSharedTypeControl = false;
                IsRecurringEventControl = false;
                IsMondayControl = false;
                IsTuesdayControl = false;
                IsWednesdayControl = false;
                IsThursdayControl = false;
                IsFridayControl = false;
                IsSaturdayControl = false;
                IsSundayControl = false;
                IsPricePerX = false;
                IsPricePerY = false;
                IsAtCustomerLocationControl = false;
                IsMaximumEventsPerDay = false;
                IsMoreEventsUponRequestControl = false;
                IsMinimumPersonRequiredControl = false;
                IsRequestPeriodControl = false;
                IsTimeControl = false;
                IsExtraFeeApplicableControl = false;
                IsExtraFeeControl = false;
            }
            else
            {
                IsBookingTypeControl = true;
            }
        }

        void ShowHideOnBookingType(string bookingType)
        {
            if (bookingType.Equals("Shared"))
            {
                IsRecurringEvent = true;
                IsSharedTypeControl = true;
                IsRecurringEventControl = true;
                IsMondayControl = true;
                IsTuesdayControl = true;
                IsWednesdayControl = true;
                IsThursdayControl = true;
                IsFridayControl = true;
                IsSaturdayControl = true;
                IsSundayControl = true;
                IsPricePerX = true;
                IsPricePerY = false;
                IsAtCustomerLocationControl = false;
                IsMaximumEventsPerDay = false;
                IsMoreEventsUponRequestControl = false;
                IsMinimumPersonRequiredControl = false;
                IsRequestPeriodControl = false;
                IsTimeControl = false;
                IsExtraFeeApplicableControl = false;
                IsExtraFeeControl = false;
                IsThisSubscriptionControl = false;
            }
            else
            {
                IsRecurringEvent = false;
                IsSharedTypeControl = false;
                IsRecurringEventControl = false;
                IsMondayControl = false;
                IsTuesdayControl = false;
                IsWednesdayControl = false;
                IsThursdayControl = false;
                IsFridayControl = false;
                IsSaturdayControl = false;
                IsSundayControl = false;
                IsPricePerX = false;
                IsPricePerY = false;
                IsAtCustomerLocationControl = false;
                IsMaximumEventsPerDay = false;
                IsMoreEventsUponRequestControl = false;
                IsMinimumPersonRequiredControl = false;
                IsRequestPeriodControl = false;
                IsTimeControl = false;
                IsExtraFeeApplicableControl = false;
                IsExtraFeeControl = false;
                IsThisSubscriptionControl = true;
            }
        }

        void OnSharedTypeSelected(string sharedType)
        {
            if (sharedType.Equals("Open"))
            {
                if (IsBookableService)
                {
                    IsRecurringEventControl = true;
                    IsEventDateControl = false;
                    IsEventStartTimeControl = false;
                    ShowHideRecurringEvent(true);
                    IsPricePerX = true;

                    IsPricePerY = false;
                    IsAtCustomerLocationControl = false;
                    IsMaximumEventsPerDay = false;
                    IsMoreEventsUponRequestControl = false;
                    IsMinimumPersonRequiredControl = false;
                    IsRequestPeriodControl = false;
                    IsTimeControl = false;
                    IsExtraFeeApplicableControl = false;
                    IsExtraFeeControl = false;
                }
            }
            else if (sharedType.Equals("Private"))
            {
                IsRecurringEventControl = false;
                IsEventDateControl = false;
                IsEventStartTimeControl = false;
                IsPricePerX = false;
                ShowHideRecurringEvent(false);
                IsPricePerY = true;
                IsAtCustomerLocationControl = true;
                IsMaximumEventsPerDay = true;
                IsMoreEventsUponRequestControl = true;
                IsMinimumPersonRequiredControl = true;
                IsRequestPeriodControl = true;
                IsTimeControl = true;
                IsExtraFeeApplicableControl = true;
                IsExtraFeeControl = true;
            }
            else if (sharedType.Equals("Both"))
            {
                IsEventDateControl = false;
                IsEventStartTimeControl = false;
                IsRecurringEventControl = false;
                ShowHideRecurringEvent(true);
                IsPricePerX = true;
                IsPricePerY = true;
                IsAtCustomerLocationControl = true;
                IsMaximumEventsPerDay = true;
                IsMoreEventsUponRequestControl = true;
                IsMinimumPersonRequiredControl = true;
                IsRequestPeriodControl = true;
                IsTimeControl = true;
                IsExtraFeeApplicableControl = true;
                IsExtraFeeControl = true;
            }
        }

        void ShowHideRecurringEvent(bool status)
        {
            IsRecurringEvent = status;
            IsMondayControl = status;
            IsTuesdayControl = status;
            IsWednesdayControl = status;
            IsThursdayControl = status;
            IsFridayControl = status;
            IsSaturdayControl = status;
            IsSundayControl = status;
           // IsPricePerX = status;
            
        }
        #endregion
    }
}