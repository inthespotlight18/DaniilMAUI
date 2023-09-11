using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DaniilMAUI.Models.ViewModels
{
    internal partial class UsersListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<User> allUsers = new();

        [ObservableProperty]
        private User user = new();

        [RelayCommand]
        private void Add()
        {
            AllUsers.Add(User);
            User = new();
        }
        [RelayCommand]
        private void Remove()
        {
            AllUsers.Remove(User);
            User = new();
        }

    }
}
