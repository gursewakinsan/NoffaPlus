using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using System;

namespace NoffaPlus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildrenMissingListPage : ContentPage
	{
		ChildrenMissingListViewModel childrenMissingListViewModel;
		public ChildrenMissingListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = childrenMissingListViewModel = new ChildrenMissingListViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			childrenMissingListViewModel.GetChildrenMissingCommand.Execute(null);
			base.OnAppearing();
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			Image image = sender as Image;
			childrenMissingListViewModel.SelectedChildrenMissingCommand.Execute(Convert.ToInt32(image.ClassId));
		}
	}
}