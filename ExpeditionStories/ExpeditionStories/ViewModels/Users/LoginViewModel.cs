using ExpeditionStories.ViewModels.Common;
using ExpeditionStories.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpeditionStories.ViewModels.Users
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands
        public ICommand LoginCommand
        {
            get { return new Command(() => { OnLoginCommandAsync(); }); }
        }

        public ICommand CannotAccessAccountCommand
        {
            get { return new Command(() => { OnCannotAccessCommand(); }); }
        }

        public ICommand ShowPasswordCommand
        {
            get { return new Command(() => { OnShowPasswordCommand(); }); }
        }
        #endregion

        #region properties
        private string username = string.Empty;
        public string UserName
        {
            get { return username; }
            set { username = value; OnPropertyChanged(("UserName")); }
        }

        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(("Password")); }
        }

        private string showPassword = string.Empty;
        public string ShowPassword
        {
            get { return showPassword; }
            set { showPassword = value; OnPropertyChanged(("ShowPassword")); }
        }

        private bool isPasswordVisible = true;
        public bool IsPasswordVisible
        {
            get { return isPasswordVisible; }
            set { isPasswordVisible = value; OnPropertyChanged(("IsPasswordVisible")); }
        }
        private string isShowPasswordImage = "login_showPassword.png";
        public string IsShowPasswordImage
        {
            get { return isShowPasswordImage; }
            set { isShowPasswordImage = value; OnPropertyChanged(("IsShowPasswordImage")); }
        }

        private bool isVisibleAlertLabelUserName = false;
        public bool IsVisibleAlertLabelUserName
        {
            get { return isVisibleAlertLabelUserName; }
            set { isVisibleAlertLabelUserName = value; OnPropertyChanged(("IsVisibleAlertLabelUserName")); }
        }

        private bool isVisibleAlertLabelPassword = false;
        public bool IsVisibleAlertLabelPassword
        {
            get { return isVisibleAlertLabelPassword; }
            set { isVisibleAlertLabelPassword = value; OnPropertyChanged(("IsVisibleAlertLabelPassword")); }
        }

        private bool isVisibleAlertLabel = false;
        public bool IsVisibleAlertLabel
        {
            get { return isVisibleAlertLabel; }
            set { isVisibleAlertLabel = value; OnPropertyChanged(("IsVisibleAlertLabel")); }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="T:hclengage.ViewModels.Authenticate.LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {

        }

        /// <summary>
        /// Ons the login command.
        /// </summary>
        private void OnLoginCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
            {
                IsVisibleAlertLabelUserName = IsVisibleAlertLabelPassword = true;
                IsVisibleAlertLabel = false;
                IsBusy = false;
                return;
            }
            else if (string.IsNullOrEmpty(UserName))
            {
                IsVisibleAlertLabelUserName = true;
                IsVisibleAlertLabel = false;
                IsBusy = false;
                return;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                IsVisibleAlertLabelPassword = true;
                IsVisibleAlertLabelUserName = false;
                IsVisibleAlertLabel = false;
                IsBusy = false;
                return;
            }
            else
            {
                IsVisibleAlertLabelUserName = IsVisibleAlertLabelPassword = false;
            }
            CheckNetwork();

            LoginService();
        }

        private void LoginService()
        {
            App.Current.MainPage.Navigation.PushAsync(new DashboardPage());
        }


        /// <summary>
        /// Ons the cannot access command.
        /// </summary>
        private async void OnCannotAccessCommand()
        {

        }

        /// <summary>
        /// Ons the show password command.
        /// </summary>
        private void OnShowPasswordCommand()
        {
            if (IsPasswordVisible)
            {
                IsPasswordVisible = false;
                IsShowPasswordImage = "login_hidePassword.png";
            }
            else
            {
                IsPasswordVisible = true;
                IsShowPasswordImage = "login_showPassword.png";
            }
        }
    }
}
