﻿using Xamarin.Forms;
using Android.Content;
using NoffaPlus.Controls;
using NoffaPlus.Droid.Renderers;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace NoffaPlus.Droid.Renderers
{
	public class CustomPickerRenderer : PickerRenderer
	{
		GradientDrawable gd;
		public CustomPickerRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.Focusable = false;
				if (gd == null)
					gd = new GradientDrawable();
				gd.SetStroke(0, Android.Graphics.Color.Transparent);
				Control.SetBackgroundDrawable(gd);
			}
		}
	}
}