using ExpeditionStories.AppConstants;
using ExpeditionStories.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpeditionStories.Views.Common
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseContentPage : ContentPage
    {
        #region propertites
        private bool SecondClick = false;
        private string isDowntime;
        private bool isDowntimebool = false;
        #endregion

        public BaseContentPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
            }
            catch (Exception ex) { ex.ToString(); }
        }



        protected override bool OnBackButtonPressed()
        {
            //base.OnBackButtonPressed();
            if (!(SecondClick))
            {
                SecondClick = true;
                DependencyService.Get<IToast>().Show(Constants.MSG_BackAgain);
                return true;
            }
            else
            {
                SecondClick = false;
                return false;
            }
        }
    }
}