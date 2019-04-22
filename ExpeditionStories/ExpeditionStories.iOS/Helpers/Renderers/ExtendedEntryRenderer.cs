using System.ComponentModel;
using CoreGraphics;
using ExpeditionStories.Helpers.Renderers;
using ExpeditionStories.iOS.Helpers.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), target: typeof(ExtendedEntryRenderer))]
namespace ExpeditionStories.iOS.Helpers.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            Control.EndEditing(true);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.AutocorrectionType = UITextAutocorrectionType.No;
                Control.SpellCheckingType = UITextSpellCheckingType.No;
                Control.AutocapitalizationType = UITextAutocapitalizationType.None;

                var view = (Element as ExtendedEntry);
                if (view != null)
                {
                    //DrawBorder(view);
                    if (!string.IsNullOrEmpty(view.LeftImage))
                        SetImage(view);

                    if (!string.IsNullOrEmpty(view.RightImage))
                        SetImageRight(view);
                    //SetFontSize(view);
                    SetPlaceholderTextColor(view);
                    SetTextColor(view);
                    //
                    if (this.Element.Keyboard == Keyboard.Numeric)
                    {
                        var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));

                        toolbar.Items = new[]
                        {
                            new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                            new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
                                Control.ResignFirstResponder();
                                ((IEntryController)Element).SendCompleted();
                            })
                        };

                        this.Control.InputAccessoryView = toolbar;
                    }


                    SetReturnType(view as ExtendedEntry);
                    Control.ShouldReturn += (UITextField tf) =>
                    {
                        view.InvokeCompleted();
                        return true;
                    };

                    //ADDED
                    if (view.SoftKeyboardEnable)
                    {
                    }
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (ExtendedEntry)Element;

            if (e.PropertyName.Equals(view.BorderColor))
                if (e.PropertyName.Equals(view.LeftImage))
                    SetImage(view);

            if (e.PropertyName.Equals(view.RightImage))
                SetImageRight(view);

            if (e.PropertyName.Equals(view.PlaceholderColor))
                SetPlaceholderTextColor(view);
            SetTextColor(view);

            //Hide border
            if (view.IsBorderLess)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }

        void SetImage(ExtendedEntry view)
        {
            UIImage image;
            image = UIImage.FromFile(view.LeftImage.ToLower() + ".png");
            UIImageView imageView = new UIImageView(new CoreGraphics.CGRect(0, 0, image.Size.Width + 20f, image.Size.Height + 5f));
            imageView.Image = image;
            imageView.ContentMode = UIViewContentMode.Center;
            imageView.Frame = new CoreGraphics.CGRect(0, 0, imageView.Image.Size.Width + 20f, imageView.Image.Size.Height + 5f);

            Control.LeftViewMode = UITextFieldViewMode.Always;
            Control.LeftView = imageView;
        }

        void SetImageRight(ExtendedEntry view)
        {
            UIImage image;
            image = UIImage.FromFile(view.RightImage.ToLower() + ".png");
            UIImageView imageView = new UIImageView(new CoreGraphics.CGRect(0, 0, image.Size.Width + 10f, image.Size.Height + 5f));
            imageView.Image = image;
            // imageView.BackgroundColor = UIColor.Blue();
            imageView.ContentMode = UIViewContentMode.Center;
            imageView.Frame = new CoreGraphics.CGRect(0, 0, imageView.Image.Size.Width + 10f, imageView.Image.Size.Height + 5f);
            Control.RightViewMode = UITextFieldViewMode.Always;
            Control.RightView = imageView;
        }

        void SetPlaceholderTextColor(ExtendedEntry view)
        {
            //Use default placeholder if IsBorderLess is true
            if (view.IsBorderLess)
            {
                return;
            }
            if (string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceHolderColor != Color.Default)
            {
                var placeholderString = new NSAttributedString(view.Placeholder,
                                                               new UIStringAttributes { ForegroundColor = view.PlaceHolderColor.ToUIColor(), Font = UIFont.SystemFontOfSize(15) });
                Control.AttributedPlaceholder = placeholderString;

            }

        }

        void SetTextColor(ExtendedEntry view)
        {
            //if (view.TextColor == null || view.TextColor == Color.Default)
            //    Control.TextColor = Color.Default.ToUIColor();
            //else
            //Control.TextColor = view.TextColor.ToUIColor();

        }

        /// <summary>
        /// Sets the type of the return.
        /// </summary>
        /// <param name="entry">Entry.</param>
        private void SetReturnType(ExtendedEntry entry)
        {
            Xamarin.Forms.ReturnType type = (Xamarin.Forms.ReturnType)entry.ReturnType;

            switch (type)
            {
                case Xamarin.Forms.ReturnType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;
                case Xamarin.Forms.ReturnType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;
                case Xamarin.Forms.ReturnType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;
                case Xamarin.Forms.ReturnType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;
                case Xamarin.Forms.ReturnType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;
                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;
            }
        }
    }
}