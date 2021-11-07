using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace xamarin_mobile_app.Models
{
    public class GitHubUser
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }
}
