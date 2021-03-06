﻿using Android.OS;
using Android.App;
using Android.Runtime;
using Android.Content;
using Android.Content.PM;

namespace NoffaPlus.Droid
{
	[Activity(Label = "WORQ", Icon = "@drawable/appIcon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	[IntentFilter(new[] { Intent.ActionView },
				  DataScheme = "https",
				  DataHost = "NoffaPlusApp.com",
				  DataPathPrefix = "/session",
				  AutoVerify = true,
				  Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable })]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental");
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			
			LoadApplication(new App());
		}
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}