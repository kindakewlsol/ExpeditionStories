using ExpeditionStories.AppConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExpeditionStories.ViewModels.Common
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public BaseViewModel()
        {
            CheckNetwork();
        }

        /// <summary>
        /// Checks the network.
        /// </summary>
        public void CheckNetwork()
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(() => {
                    ShowAlert("", Constants.No_network_connection);
                    IsBusy = false;
                    return;
                });
            }
        }

        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="msg">Message.</param>
        public void ShowAlert(string title, string msg)
        {
            GetVibrate(1);
            Application.Current.MainPage.DisplayAlert(title, msg, "OK");
        }

        #region Json
        /// <summary>
        /// Serializes to json.
        /// </summary>
        /// <returns>The to json.</returns>
        /// <param name="obj">Object.</param>
        //public static string SerializeToJson(object obj)
        //{
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(obj);
        //        return json;
        //    }
        //    catch (Exception ex) { ex.ToString(); return null; }
        //}
        /// <summary>
        /// Deserializes from json.
        /// </summary>
        /// <returns>The from json.</returns>
        /// <param name="jsonObj">Json object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        //public static T DeserializeFromJson<T>(string jsonObj)
        //{
        //    try
        //    {
        //        var result = JsonConvert.DeserializeObject<T>(jsonObj);
        //        return result;
        //    }
        //    catch (Exception ex) { ex.ToString(); throw; }
        //}
        #endregion

        /// <summary>
        /// Shows the loader.
        /// </summary>
        public void ShowLoader()
        {

        }

        /// <summary>
        /// Gets the vibrate.
        /// </summary>
        /// <param name="time">Time.</param>
        public void GetVibrate(int time)
        {
            try
            {
                Vibration.Vibrate();

                var duration = TimeSpan.FromSeconds(time);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex) { ex.ToString(); }
            catch (Exception ex) { ex.ToString(); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region validator
        public bool CheckEmailId(string text)
        {
            bool returnValue = false;
            if (!(string.IsNullOrEmpty(text)))
            {
                var pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                var isValidPassword = Regex.Match(text, pattern);
                return returnValue = isValidPassword.Value == string.Empty ? false : true;
            }
            return returnValue;
        }
        #endregion
    }
}
