using Xamarin.Forms;
using NoffaPlus.Interfaces;

[assembly: Dependency(typeof(NoffaPlus.iOS.Services.ProgressBar))]
namespace NoffaPlus.iOS.Services
{
	public class ProgressBar : IProgressBar
	{
		public void Hide()
		{
			BigTed.BTProgressHUD.Dismiss();
		}

		public void Show()
		{
			BigTed.BTProgressHUD.Show("Loading...", -1, BigTed.ProgressHUD.MaskType.Black);
		}
	}
}