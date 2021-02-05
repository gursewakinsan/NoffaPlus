﻿using UIKit;
using Foundation;

namespace NoffaPlus.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			var App = (App)Xamarin.Forms.Application.Current;
			App.LoginWithSession(url.PathComponents[2]);
			return false;
		}
	}
}
