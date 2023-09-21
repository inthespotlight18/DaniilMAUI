using CommunityToolkit.Maui.Alerts;
using DaniilMAUI.Models;
using DaniilMAUI.Models.ViewModels;
//using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DaniilMAUI.Pages;

public partial class UsersList : ContentPage
{
    //private GraphService graphService;
    //private Microsoft.Graph.Models.User user;


    public UsersList()
    {
        InitializeComponent();

        BindingContext = new UsersListViewModel();
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var user = (Models.User)e.Item;
        var userModel = new UserModel { User = user };
        var ViewUserInfo = new ViewUserInfo();
        ViewUserInfo.BindingContext = userModel;

        Navigation.PushAsync(ViewUserInfo);

    }

    //private async void GetUserInfoBtn_Clicked(object sender, EventArgs e)
    //{
    //    if (graphService == null)
    //    {
    //        graphService = new GraphService();
    //    }
    //    user = await graphService.GetMyDetailsAsync();


    //    HelloLabel.Text = (user != null) ? $"Hello, {user.DisplayName}!" : $"We got an error here! Something with your credentials...";

    //}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            var authService = new AuthService();
            var result = await authService.LoginAsync(CancellationToken.None);
            var token = result?.IdToken; // AccessToken also can be used
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(token);
                var claims = data.Claims.ToList();
                if (data != null)
                {
                    var stringBuilder = new StringBuilder();

                    string name = data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value;
                    string email = data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value;

                    AddCredentialsToExtUser(name, email);

                    //stringBuilder.AppendLine($"Name: {name}");
                    //stringBuilder.AppendLine($"Email: {email}");

                    //User user = new User();

                    //user.UserName = name;
                    //user.Email = email;
                    //user.Password = "xxxxxxx";
                    //user.PrimeUser = true;

                    //var userModel = new UserModel { User = user };
                    //var ViewUserInfo = new ViewUserInfo();
                    //ViewUserInfo.BindingContext = userModel;



                    await Toast.Make(stringBuilder.ToString()).Show();
                }
            }
        }
        catch (MsalClientException ex)
        {
            await Toast.Make(ex.Message).Show();
        }
    }

    /*
     * This function uses Name and Email from Microsoft account, which was pulled out by OnLoginClicked()
     */

    private async void AddCredentialsToExtUser(string name, string email)
    {
        User user = new User();

        user.UserName = name;
        user.Email = email;
        user.Password = "xxxxxxx";
        user.PrimeUser = true;

        var userModel = new UserModel { User = user };
        var ViewUserInfo = new ViewUserInfo();
        ViewUserInfo.BindingContext = userModel;

        UsersListViewModel usersListViewModel = new UsersListViewModel();
        usersListViewModel.AllUsers.Add(user);



        await Navigation.PushAsync(ViewUserInfo);
    }




}