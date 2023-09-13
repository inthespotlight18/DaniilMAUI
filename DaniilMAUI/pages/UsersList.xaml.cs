using DaniilMAUI.Models.ViewModels;


namespace DaniilMAUI.Pages;

public partial class UsersList : ContentPage
{
    private GraphService graphService;
    private Microsoft.Graph.Models.User user;


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

    private async void GetUserInfoBtn_Clicked(object sender, EventArgs e)
    {
        if (graphService == null)
        {
            graphService = new GraphService();
        }
        user = await graphService.GetMyDetailsAsync();


        HelloLabel.Text = (user != null) ? $"Hello, {user.DisplayName}!" : $"We got an error here! Something with your credentials...";

    }

}