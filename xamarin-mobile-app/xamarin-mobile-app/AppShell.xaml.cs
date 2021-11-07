using System;
using System.Collections.Generic;
using Xamarin.Forms;
using xamarin_mobile_app.ViewModels;
using xamarin_mobile_app.Views;

namespace xamarin_mobile_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddGitHubUserPage), typeof(AddGitHubUserPage));
            Routing.RegisterRoute(nameof(UpdateGitHubUserPage), typeof(UpdateGitHubUserPage));
            Routing.RegisterRoute(nameof(GitHubUserDetailPage), typeof(GitHubUserDetailPage));
        }
    }
}
