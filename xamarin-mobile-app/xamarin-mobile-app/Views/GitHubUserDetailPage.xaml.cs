using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_mobile_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GitHubUserDetailPage : ContentPage
    {
        public GitHubUserDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (width > height)
            {
                StackLayoutMain.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                StackLayoutMain.Orientation = StackOrientation.Vertical;
            }
        }
    }
}