using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExpeditionStories.Helpers.Renderers
{
    public class ExtendedEntry : Entry
    {
        public static readonly BindableProperty LeftImageProperty = BindableProperty.Create(propertyName: "LeftImage",
          returnType: typeof(string),
          declaringType: typeof(ExtendedEntry),
          defaultValue: default(string));

        public static readonly BindableProperty RightImageProperty = BindableProperty.Create(propertyName: "RightImage",
              returnType: typeof(string),
                declaringType: typeof(ExtendedEntry),
              defaultValue: default(string));

        public static readonly BindableProperty PlaceHolderColorProperty = BindableProperty.Create(propertyName: "PlaceHolderColor",
                returnType: typeof(Color),
                declaringType: typeof(ExtendedEntry),
                defaultValue: Color.White);

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(propertyName: "BorderColor",
                returnType: typeof(Color),
                declaringType: typeof(ExtendedEntry),
                defaultValue: Color.White);

        public static readonly BindableProperty IsBorderLessProperty = BindableProperty.Create(propertyName: "IsBorderLess", returnType: typeof(bool),
               declaringType: typeof(ExtendedEntry),
               defaultValue: false);

        public static readonly BindableProperty SoftKeyboardEnableProperty = BindableProperty.Create(propertyName: "SoftKeyboardEnable", returnType: typeof(bool),
               declaringType: typeof(ExtendedEntry),
               defaultValue: false);

        public static readonly BindableProperty RemovePaddingProperty = BindableProperty.Create(propertyName: "RemovePadding", returnType: typeof(bool),
              declaringType: typeof(ExtendedEntry),
              defaultValue: false);
        public string LeftImage
        {
            get { return (string)base.GetValue(LeftImageProperty); }
            set { base.SetValue(LeftImageProperty, value); }
        }

        public string RightImage
        {

            get { return (string)base.GetValue(RightImageProperty); }
            set { base.SetValue(RightImageProperty, value); }

        }
        public Color PlaceHolderColor
        {
            get { return (Color)base.GetValue(PlaceHolderColorProperty); }
            set { base.SetValue(PlaceHolderColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public bool IsBorderLess
        {
            get { return (bool)GetValue(IsBorderLessProperty); }
            set { SetValue(IsBorderLessProperty, value); }
        }

        public bool RemovePadding
        {
            get { return (bool)GetValue(RemovePaddingProperty); }
            set { SetValue(RemovePaddingProperty, value); }
        }

        public bool SoftKeyboardEnable
        {
            get { return (bool)GetValue(SoftKeyboardEnableProperty); }
            set { SetValue(SoftKeyboardEnableProperty, value); }
        }
        // Need to overwrite default handler because we cant Invoke otherwise  
        public new event EventHandler Completed;

        public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create(nameof(ReturnType),
                                                                                             typeof(ReturnType), typeof(ExtendedEntry),
            ReturnType.Done, BindingMode.OneWay);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
        }
    }
    public enum ReturnType
    {
        Go,
        Next,
        Done,
        Send,
        Search
    }
}
