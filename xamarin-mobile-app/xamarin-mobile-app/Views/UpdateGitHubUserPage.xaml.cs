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
    public partial class UpdateGitHubUserPage : ContentPage
    {
        public UpdateGitHubUserPage()
        {
            InitializeComponent();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (width > height)
            {
                MainStackLayout.Orientation = StackOrientation.Horizontal;
                MainStackLayout.VerticalOptions = LayoutOptions.Center;
                Picture.HeightRequest = 150;
                Picture.WidthRequest = 150;
            }
            else
            {
                MainStackLayout.Orientation = StackOrientation.Vertical;
                MainStackLayout.VerticalOptions = LayoutOptions.Start;
                Picture.HeightRequest = 250;
                Picture.WidthRequest = 250;
            }
        }
    }
}