using Xamarin.Forms;
using Android.Widget;
using Android.Content;
using NoffaPlus.Controls;
using NoffaPlus.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace NoffaPlus.Droid.Renderers
{
	public class CustomSearchBarRenderer : SearchBarRenderer
	{
		public CustomSearchBarRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
				var icon = Control.FindViewById(Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null));
				ImageView image = icon as ImageView;
				if (image != null)
					image.SetColorFilter(Android.Graphics.Color.White);
			}
		}
	}
}