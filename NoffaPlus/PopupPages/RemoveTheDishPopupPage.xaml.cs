using Xamarin.Forms.Xaml;
using NoffaPlus.ViewModels;
using Rg.Plugins.Popup.Pages;

namespace NoffaPlus.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemoveTheDishPopupPage : PopupPage
	{
		RemoveTheDishPopupPageViewModel viewModel;
		public RemoveTheDishPopupPage(DeleteDishItemPopupContext context)
		{
			InitializeComponent();
			BindingContext = viewModel = new RemoveTheDishPopupPageViewModel(this.Navigation);
			viewModel.DeleteDishItemPopupPageContext = context;
		}
	}
}