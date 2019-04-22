using ExpeditionStories.ViewModels.Users;
using ExpeditionStories.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpeditionStories.Views.Users
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BaseContentPage
    {
        private LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            this.BindingContext = viewModel;
        }

        void UserNameCompleted(object sender, System.EventArgs e)
        {
            EntryPassword.Focus();
        }
    }
}