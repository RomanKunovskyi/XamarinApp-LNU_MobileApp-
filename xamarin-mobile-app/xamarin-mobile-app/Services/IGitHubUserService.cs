using System.Collections.Generic;
using System.Threading.Tasks;
using xamarin_mobile_app.Models;

namespace xamarin_mobile_app.Services
{
    public interface IGitHubUserService
    {
        GitHubUser Add(GitHubUser user);
        GitHubUser Delete(string login);
        GitHubUser Update(GitHubUser user);
        Task<GitHubUser> Get(string login);
        Task<IEnumerable<GitHubUser>> Get();
    }
}
