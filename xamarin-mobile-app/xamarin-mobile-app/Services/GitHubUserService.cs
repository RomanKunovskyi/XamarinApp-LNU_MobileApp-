using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using xamarin_mobile_app.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace xamarin_mobile_app.Services
{
    public class GitHubUserService : IGitHubUserService
    {
        private readonly List<GitHubUser> gitHubUsers;
        private readonly HttpClient _client;
        public GitHubUserService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders = { UserAgent = { ProductInfoHeaderValue.Parse("RomanKunovskyi") } }
            };
            gitHubUsers = new List<GitHubUser>();
        }

        private readonly string defoultImgUrl = "https://agile.yakubovsky.com/wp-content/plugins/all-in-one-seo-pack/images/default-user-image.png";
        public GitHubUser Add(GitHubUser user)
        {
            if (user.AvatarUrl == null)
            {
                user.AvatarUrl = defoultImgUrl;
            }
            gitHubUsers.Add(user);
            return user;
        }

        public GitHubUser Delete(string login)
        {
            GitHubUser gitHubUser = gitHubUsers.FirstOrDefault(u => u.Login == login);
            gitHubUsers.Remove(gitHubUser);
            return gitHubUser;
        }

        public async Task<GitHubUser> Get(string login)
        {
            GitHubUser gitHubUser = gitHubUsers.FirstOrDefault(u => u.Login == login);

            if (gitHubUser == null)
            {
                try
                {
                    string jsonResponse = await _client.GetStringAsync($"/users/{login}");
                    gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(jsonResponse);
                }
                catch
                {
                    return null;
                }
                gitHubUsers.Add(gitHubUser);
            }
            return gitHubUser;
        }

        public async Task<IEnumerable<GitHubUser>> Get()
        {
            if (gitHubUsers.Count < 30)
            {
                string jsonResponse = await _client.GetStringAsync($"/users");
                gitHubUsers.AddRange(JsonConvert.DeserializeObject<List<GitHubUser>>(jsonResponse));
            }

            return gitHubUsers;
        }

        public GitHubUser Update(GitHubUser user)
        {
            GitHubUser gitHubUser = gitHubUsers.FirstOrDefault(u => u.Login == user.Login);
            if (gitHubUser == null)
            {
                return null;
            }
            gitHubUsers.FirstOrDefault(u => u.Login == user.Login).AvatarUrl = user.AvatarUrl;
            return gitHubUser;
        }
    }
}