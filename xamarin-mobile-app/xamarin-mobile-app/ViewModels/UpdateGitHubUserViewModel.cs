using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using xamarin_mobile_app.Models;
using xamarin_mobile_app.ExtantionClasses;
using System.Windows.Input;
using System.Threading.Tasks;
using MvvmHelpers.Commands;

namespace xamarin_mobile_app.ViewModels
{
    [QueryProperty(nameof(JsonUser), nameof(JsonUser))]
    public class UpdateGitHubUserViewModel : BaseViewModel
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

        public ICommand SaveCommand { get; }

        public UpdateGitHubUserViewModel()
        {
            Title = "Update";
            SaveCommand = new AsyncCommand(Save);
        }
        private readonly string defoultImgUrl = "https://agile.yakubovsky.com/wp-content/plugins/all-in-one-seo-pack/images/default-user-image.png";
        private async Task Save()
        {
            if (HtmlUrl == null)
            {
                HtmlUrl = defoultImgUrl;
            }
            var user = new GitHubUser()
            {
                Login = Login,
                AvatarUrl = AvatarUrl,
                HtmlUrl = HtmlUrl
            };
            string jsonUser = user.ConvertToEscapedString();
            await Xamarin.Forms.Shell.Current.GoToAsync($"..?JsonUser={jsonUser}&Operation=Update");
        }
    }
}
