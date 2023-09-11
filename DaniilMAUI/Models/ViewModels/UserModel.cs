using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaniilMAUI.Models.ViewModels
{
    internal partial class UserModel : ObservableObject
    {
        [ObservableProperty]
        private User user;

        //[ObservableProperty]
        //private string userName;

        //[ObservableProperty]
        //private string email;

        //[ObservableProperty]
        //private string password;

        //[ObservableProperty]
        //private bool primeUser;

    }
}
