namespace DaniilMAUI;

using DaniilMAUI.Pages;
using System.Diagnostics;

public partial class App : Application
{
    public App()
    {
        try
        {
            InitializeComponent();

            MainPage = new NavigationPage(new UsersList());
        }
        catch(Exception ex)
        {
            Debug.WriteLine("Daniil error - " + ex.Message);
            
        }
        

        //MainPage = new NavigationPage(new MainPage());
    }
}

