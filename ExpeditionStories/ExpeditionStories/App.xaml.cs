using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ExpeditionStories
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Users.LoginPage())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            if (AppConstants.Constants.IsStartTrip)
            {
                Device.StartTimer(new TimeSpan(0, 0, 10), () =>
                {
                    if (AppConstants.Constants.IsStartTrip)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
        }
    }
}
