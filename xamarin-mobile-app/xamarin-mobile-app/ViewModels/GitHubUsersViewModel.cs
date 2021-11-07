using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin_mobile_app.Models;
using xamarin_mobile_app.Services;
using xamarin_mobile_app.Views;
using xamarin_mobile_app.ExtantionClasses;

namespace xamarin_mobile_app.ViewModels
{
    [Xamarin.Forms.QueryProperty(nameof(Operation), nameof(Operation)),
        Xamarin.Forms.QueryProperty(nameof(JsonUser), nameof(JsonUser))]
    public class GitHubUsersViewModel : BaseViewModel
    {
        private readonly IGitHubUserService service;

        public ICommand LoadDataCommand { get; }
        public ICommand FindUserCommand { get; }
        public ICommand AddUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand FilterUsersCollectionCommand { get; }

        public ObservableRangeCollection<GitHubUser> UsersView { get; }
        public ObservableRangeCollection<GitHubUser> Users { get; }

        private bool isLoadDataButtonVisible = true;
        public bool IsLoadDataButtonVisible
        {
            get => isLoadDataButtonVisible;
            set => SetProperty(ref isLoadDataButtonVisible, value);
        }

        private string finderText;
        public string FinderText
        {
            get => finderText;
            set
            {
                SetProperty(ref finderText, value);
            }
        }


        private GitHubUser selectedUser;
        public GitHubUser SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                if (value != null)
                {
                    string jsonUser = selectedUser.ConvertToEscapedString();
                    Xamarin.Forms.Shell.Current.GoToAsync($"{nameof(GitHubUserDetailPage)}?JsonUser={jsonUser}");
                    value = null;
                }
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        public GitHubUsersViewModel()
        {
            Title = "Users";
            service = new GitHubUserService();
            UsersView = new ObservableRangeCollection<GitHubUser>();
            Users = new ObservableRangeCollection<GitHubUser>();

            LoadDataCommand = new AsyncCommand(LoadData);
            FindUserCommand = new AsyncCommand(FindUser);
            AddUserCommand = new AsyncCommand(AddUser);
            DeleteUserCommand = new Command<GitHubUser>(DeleteUser);
            UpdateUserCommand = new AsyncCommand<GitHubUser>(UpdateUser);
            FilterUsersCollectionCommand = new AsyncCommand<string>(FilterUsersCollection);
        }
        public async Task LoadData()
        {
            var users = await service.Get();
            UsersView.Clear();
            Users.Clear();
            Users.AddRange(users);
            UsersView.AddRange(users);
            IsLoadDataButtonVisible = false;
        }

        private async Task FindUser()
        {
            var user = await service.Get(finderText);
            if (user != null)
            {
                Users.Add(user);
                UsersView.Add(user);
            }
            else
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Not Found", "No GitHub User With This Login.", "Ok");
            }
        }

        public string Operation { get; set; }
        private string jsonUser;
        public string JsonUser
        {
            get => jsonUser;
            set
            {
                jsonUser = value;
                var user = jsonUser.ConvertFromEscapedString<GitHubUser>();

                switch (Operation)
                {
                    case "Update":
                        service.Update(user);
                        break;
                    case "Add":
                        if (Users.Where(u => u.Login == user.Login).FirstOrDefault() == null)
                        {
                            service.Add(user);
                            Users.Add(user);
                            UsersView.Add(user);
                        }
                        break;
                }

            }
        }

        private async Task AddUser()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync(nameof(AddGitHubUserPage));
        }

        private void DeleteUser(GitHubUser gitHubUser)
        {
            GitHubUser user = service.Delete(gitHubUser.Login);
            Users.Remove(gitHubUser);
            UsersView.Remove(gitHubUser);
        }

        private async Task UpdateUser(GitHubUser user)
        {
            string jsonUser = user.ConvertToEscapedString();
            await Xamarin.Forms.Shell.Current.GoToAsync($"{nameof(UpdateGitHubUserPage)}?JsonUser={jsonUser}");
        }

        private async Task FilterUsersCollection(string filter)
        {
            await Task.Run(() =>
            {
                UsersView.Clear();
                UsersView.AddRange(Users.Where(user => user.Login.ToLower().Contains(filter.ToLower())));
            });
        }
    }
}
