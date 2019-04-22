using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExpeditionStories.Droid.Helpers.Interfaces;
using ExpeditionStories.Helpers.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]
namespace ExpeditionStories.Droid.Helpers.Interfaces
{
    public class ToastMessage : IToast
    {
        public ToastMessage()
        {
        }

        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}