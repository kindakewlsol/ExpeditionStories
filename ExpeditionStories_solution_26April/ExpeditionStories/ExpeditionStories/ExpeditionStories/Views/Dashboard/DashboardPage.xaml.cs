using ExpeditionStories.ViewModels.Dashboard;
using ExpeditionStories.Views.Common;
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
	public partial class DashboardPage : BaseContentPage
    {
        DashboardViewModel viewModel;
        public DashboardPage ()
		{
			InitializeComponent ();

            viewModel = new DashboardViewModel();
            this.BindingContext = viewModel;
        }
    }
}