using UIKit;
using Xamarin.Forms;
using NoffaPlus.Controls;
using NoffaPlus.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace NoffaPlus.iOS.Renderers
{
	public class CustomPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				this.Control.BorderStyle = UITextBorderStyle.None;
		}
	}
}