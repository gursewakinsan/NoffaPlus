using System;
using Xamarin.Forms;

namespace NoffaPlus
{
	public partial class App : Application
	{
		#region App Constructor.
		public App()
		{
			InitializeComponent();
			MainPage = new Views.Queue.OperatorStatusQueueListPage();
		}
		#endregion

		#region Login With Session For iOS.
		public void LoginWithSession(string session)
		{
			if (!string.IsNullOrWhiteSpace(session))
				Helper.Helper.SessionId = session;
			MainPage = new Views.LoginPage();
		}
		#endregion

		#region Login With Session For Android.
		protected override void OnAppLinkRequestReceived(Uri uri)
		{
			if (uri.Host.EndsWith("NoffaPlusApp.com", StringComparison.OrdinalIgnoreCase))
			{
				if (uri.Segments != null && uri.Segments.Length == 3)
				{
					Helper.Helper.SessionId = uri.Segments[2];
					MainPage = new Views.LoginPage();
				}
			}
			else
				MainPage = new Views.LoginPage();
			base.OnAppLinkRequestReceived(uri);
		}
		#endregion
	}
}
