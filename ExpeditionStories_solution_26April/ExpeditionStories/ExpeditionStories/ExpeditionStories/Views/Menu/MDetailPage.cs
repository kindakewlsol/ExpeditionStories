using ExpeditionStories.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ExpeditionStories.Views.Menu
{
	public class MDetailPage : MasterDetailPage
    {
        #region properties
        MenuPage masterPage;
        DashboardPage detailPage;
        #endregion 
        public MDetailPage ()
		{
            MasterBehavior = MasterBehavior.Popover;

            // menu area
            masterPage = new MenuPage();
            Master = masterPage;

            // detail area
            detailPage = new DashboardPage();
            Detail = new NavigationPage(detailPage)
            {
                BarBackgroundColor = Color.BlueViolet,
                BarTextColor = Color.White,
            };
        }
	}
}