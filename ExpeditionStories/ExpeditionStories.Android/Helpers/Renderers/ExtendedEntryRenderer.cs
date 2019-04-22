using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using ExpeditionStories.Droid.Helpers.Renderers;
using ExpeditionStories.Helpers.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace ExpeditionStories.Droid.Helpers.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                // Get the 'native' control
                var element = (ExtendedEntry)this.Element;
                var nativeTextField = (EditText)Control;
                GradientDrawable gd = new GradientDrawable();
                gd.SetShape(ShapeType.Line);
                nativeTextField.Gravity = Android.Views.GravityFlags.Left | Android.Views.GravityFlags.Center;
                nativeTextField.SetBackgroundColor(Android.Graphics.Color.Transparent);


                //Control.SetPadding(0, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

                if (element.PlaceHolderColor == Color.Black)
                {
                    nativeTextField.SetHintTextColor(Android.Graphics.Color.ParseColor("#333333"));
                    nativeTextField.SetTextColor(Android.Graphics.Color.ParseColor("#A0A0A0"));
                }
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, 0); // replace 0 with a Resource.Drawable.my_cursor 

                //Hide border
                if (element.IsBorderLess)
                {
                    Control.Background = null;
                }

                if (element.IsPassword == false)
                {
                    //No Suggestion
                    nativeTextField.InputType = InputTypes.TextFlagNoSuggestions;
                }
                if (element.RemovePadding)
                {
                    nativeTextField.SetPadding(0, 0, 0, 0);
                    nativeTextField.SetForegroundGravity(GravityFlags.CenterVertical);
                    nativeTextField.Gravity = GravityFlags.CenterVertical;

                }
                if (element.Keyboard == Xamarin.Forms.Keyboard.Telephone)
                {
                    nativeTextField.InputType = InputTypes.ClassPhone;
                }
                //Disable long click for clipboard
                nativeTextField.LongClickable = false;

                SetReturnType((ExtendedEntry)element);
                // Editor Action is called when the return button is pressed  
                Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                {
                    if (element.ReturnType != ExpeditionStories.Helpers.Renderers.ReturnType.Next)
                        element.Unfocus();

                    // Call all the methods attached to custom_entry event handler Completed  
                    element.InvokeCompleted();
                };

            }
        }

        /// <summary>
        /// Sets the type of the return.
        /// </summary>
        /// <param name="entry">Entry.</param>
        private void SetReturnType(ExtendedEntry entry)
        {
            ExpeditionStories.Helpers.Renderers.ReturnType type = (ExpeditionStories.Helpers.Renderers.ReturnType)entry.ReturnType;

            switch (type)
            {
                case ExpeditionStories.Helpers.Renderers.ReturnType.Go:
                    Control.ImeOptions = Android.Views.InputMethods.ImeAction.Go;
                    Control.SetImeActionLabel("Go", ImeAction.Go);
                    break;
                case ExpeditionStories.Helpers.Renderers.ReturnType.Next:
                    Control.ImeOptions = ImeAction.Next;
                    Control.SetImeActionLabel("Next", ImeAction.Next);
                    break;
                case ExpeditionStories.Helpers.Renderers.ReturnType.Send:
                    Control.ImeOptions = ImeAction.Send;
                    Control.SetImeActionLabel("Send", ImeAction.Send);
                    break;
                case ExpeditionStories.Helpers.Renderers.ReturnType.Search:
                    Control.ImeOptions = ImeAction.Search;
                    Control.SetImeActionLabel("Search", ImeAction.Search);
                    break;
                default:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Done", ImeAction.Done);
                    break;
            }
        }
    }
}