using UIKit;
using Xamarin.Forms;
using NoffaPlus.Controls;
using NoffaPlus.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFloatingLabelEntry), typeof(CustomFloatingLabelEntryRenderer))]
namespace NoffaPlus.iOS.Renderers
{
	public class CustomFloatingLabelEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}