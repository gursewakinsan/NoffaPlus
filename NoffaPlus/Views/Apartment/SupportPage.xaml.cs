﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;

namespace NoffaPlus.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportPage : ContentPage
    {
        SupportPageViewModel viewModel;
        public SupportPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SupportPageViewModel(this.Navigation);
        }
    }
}