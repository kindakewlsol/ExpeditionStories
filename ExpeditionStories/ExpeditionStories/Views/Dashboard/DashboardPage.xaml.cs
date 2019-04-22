using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpeditionStories.Views.Dashboard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardPage : ContentPage
	{
		public DashboardPage ()
		{
			InitializeComponent ();
		}

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            if (AppConstants.Constants.IsStartTrip)
            {
                return;
            }
            else
            {
                AppConstants.Constants.IsStartTrip = true;
            }
        }

        private void EndButton_Clicked(object sender, EventArgs e)
        {
            if (!AppConstants.Constants.IsStartTrip)
            {
                return;
            }
            else
            {
                AppConstants.Constants.IsStartTrip = false;
            }
        }
    }
}