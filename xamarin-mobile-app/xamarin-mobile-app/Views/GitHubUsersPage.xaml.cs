using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_mobile_app.ViewModels;

namespace xamarin_mobile_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GitHubUsersPage : ContentPage
    {
        public GitHubUsersPage()
        {
            InitializeComponent();
            var vm = new GitHubUsersViewModel();
            BindingContext = vm;
            this.Appearing += (s, e) => vm.LoadData();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (width > height)
            {
                gridItemLayout.Span = 3;
            }
            else
            {
                gridItemLayout.Span = 2;
            }
        }
    }
}