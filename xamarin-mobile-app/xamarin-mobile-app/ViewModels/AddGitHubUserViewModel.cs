using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin_mobile_app.ExtantionClasses;
using xamarin_mobile_app.Models;

namespace xamarin_mobile_app.ViewModels
{
    public class AddGitHubUserViewModel : BaseViewModel
    {

        private string login;
        public string Login { get => login; set => SetProperty(ref login, value); }

        private string avatarUrl;
        public string AvatarUrl { get => avatarUrl; set => SetProperty(ref avatarUrl, value); }

        private string htmlUrl;
        public string HtmlUrl { get => htmlUrl; set => SetProperty(ref htmlUrl, value); }

        public ICommand SaveCommand { get; }

        public AddGitHubUserViewModel()
        {
            Title = "Add New User";
            SaveCommand = new AsyncCommand(Save);
        }
        private readonly string defoultImgUrl = "https://agile.yakubovsky.com/wp-content/plugins/all-in-one-seo-pack/images/default-user-image.png";

        private async Task Save()
        {
            if (AvatarUrl == null)
            {
                AvatarUrl = defoultImgUrl;
            }
            var user = new GitHubUser()
            {
                Login = Login,
                AvatarUrl = AvatarUrl,
                HtmlUrl = HtmlUrl
            };
            string jsonUser = user.ConvertToEscapedString();
            await Xamarin.Forms.Shell.Current.GoToAsync($"..?JsonUser={jsonUser}&Operation=Add");
        }
    }
}
