using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace xamarin_mobile_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public AboutViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://docs.github.com/en/rest"));
            Title = "About";
        }

        public ICommand OpenWebCommand { get; }
    }
}