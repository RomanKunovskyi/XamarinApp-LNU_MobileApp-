using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamarin_mobile_app.ExtantionClasses;
using xamarin_mobile_app.Models;

namespace xamarin_mobile_app.ViewModels
{
    [QueryProperty(nameof(JsonUser), nameof(JsonUser))]
    public class GitHubUserDetailViewModel:BaseViewModel
    {
        private string jsonUser;
        public string JsonUser
        {
            get => jsonUser;
            set
            {
                jsonUser = value;
                var User = jsonUser.ConvertFromEscapedString<GitHubUser>();
                Login = User.Login;
                AvatarUrl = User.AvatarUrl;
                HtmlUrl = User.HtmlUrl;
            }
        }

        private string login;
        public string Login { get => login; set => SetProperty(ref login, value); }

        private string avatarUrl;
        public string AvatarUrl { get => avatarUrl; set => SetProperty(ref avatarUrl, value); }

        private string htmlUrl;
        public string HtmlUrl { get => htmlUrl; set => SetProperty(ref htmlUrl, value); }
        public GitHubUserDetailViewModel()
        {
            Title = "Details";
            if (AvatarUrl == null)
            {
                AvatarUrl = "https://agile.yakubovsky.com/wp-content/plugins/all-in-one-seo-pack/images/default-user-image.png";
            }
            OpenWebCommand = new AsyncCommand(OpenWeb);
        }
        public ICommand OpenWebCommand { get; }

        private async Task OpenWeb()
        {
            try
            {
                await Browser.OpenAsync(htmlUrl);
            }
            catch
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Bad Url", "I Can Not Open This Url", "Ok");

            }
        }

    }
}
