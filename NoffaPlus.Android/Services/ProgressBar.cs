using AndroidHUD;
using Xamarin.Forms;
using NoffaPlus.Interfaces;

[assembly: Dependency(typeof(NoffaPlus.Droid.Services.ProgressBar))]
namespace NoffaPlus.Droid.Services
{
	public class ProgressBar : IProgressBar
	{
		public void Hide()
		{
			AndHUD.Shared.Dismiss();
		}

		public void Show()
		{
			AndHUD.Shared.Show(Forms.Context, "Loading...", -1, MaskType.Black);
		}
	}
}