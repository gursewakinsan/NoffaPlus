using UIKit;
using Foundation;

namespace NoffaPlus.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental");
			Rg.Plugins.Popup.Popup.Init();
			global::Xamarin.Forms.Forms.Init();
			App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
			App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var App = (App)Xamarin.Forms.Application.Current;
			App.LoginWithSession(url.PathComponents[1]);
			return false;
		}
	}
}
