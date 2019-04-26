using ExpeditionStories.Models.Dashboard;
using ExpeditionStories.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpeditionStories.ViewModels.Dashboard
{
    public class DashboardViewModel : BaseViewModel
    {
        #region Commands
        public ICommand StartButtonCommand
        {
            get { return new Command(() => { OnStartButtonCommand(); }); }
        }

        public ICommand EndButtonCommand
        {
            get { return new Command(() => { OnEndButtonCommand(); }); }
        }
        #endregion

        #region properties
        private string startTripText = "Start trip";
        public string StartTripText
        {
            get { return startTripText; }
            set { startTripText = value; OnPropertyChanged(("StartTripText")); }
        }
        private string endTripText = "End trip";
        public string EndTripText
        {
            get { return endTripText; }
            set { endTripText = value; OnPropertyChanged(("EndTripText")); }
        }

        private ObservableCollection<DashboardModel> listOfLocations;
        public ObservableCollection<DashboardModel> ListOfLocations
        {
            get { return listOfLocations; }
            set { listOfLocations = value; OnPropertyChanged(("ListOfLocations")); }
        }
        #endregion

        public DashboardViewModel()
        {
            ListOfLocations = new ObservableCollection<DashboardModel>();
            ListOfLocations.Add(new DashboardModel { count = 1 });
            ListOfLocations.Add(new DashboardModel { count = 2 });
            ListOfLocations.Add(new DashboardModel { count = 3 });
            ListOfLocations.Add(new DashboardModel { count = 4 });
            ListOfLocations.Add(new DashboardModel { count = 5 });
            ListOfLocations.Add(new DashboardModel { count = 6 });
            OnPropertyChanged("ListOfLocations");
        }

        public void OnStartButtonCommand()
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

        public void OnEndButtonCommand()
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
